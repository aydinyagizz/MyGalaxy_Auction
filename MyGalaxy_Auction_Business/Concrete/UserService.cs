using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyGalaxy_Auction_Business.Abstraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_DataAccess.Context;
using MyGalaxy_Auction_DataAccess.Enums;
using MyGalaxy_Auction_DataAccess.Models;

namespace MyGalaxy_Auction_Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string _secretKey;
        public UserService(RoleManager<IdentityRole> roleManager, IConfiguration _configuration, 
            ApplicationDbContext context, IMapper mapper, ApiResponse response, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _secretKey = _configuration.GetValue<string>("SecretKey:jwtKey");
            _context = context;
            _mapper = mapper;
            _response = response;
            _userManager = userManager;
        }
        public async Task<ApiResponse> Login(LoginRequestDTO model)
        {
            ApplicationUser userFromDb = _context.ApplicationUsers.FirstOrDefault(u=>u.UserName.ToLower() == model.UserName.ToLower());
            if (userFromDb != null)
            {
                bool isValid = await _userManager.CheckPasswordAsync(userFromDb, model.Password);
                if (!isValid)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Your entry information is not correct");
                    _response.IsSuccess = false;
                    return _response;
                }

                var role = await _userManager.GetRolesAsync(userFromDb);

                //token fırlatmak için JwtSecurityTokenHandler kullanıyoruz
                JwtSecurityTokenHandler tokenHandler = new();
                byte[] key = Encoding.ASCII.GetBytes(_secretKey);

                //token işlemi.
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                        new Claim(ClaimTypes.Email, userFromDb.Email),
                        new Claim(ClaimTypes.Role, role.FirstOrDefault()),
                        new Claim("fullName", userFromDb.FullName)
                    }),
                    // Token süresi
                    // 1 gün geçerli olarak ayarladık
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                //token oluşturma ve fırlatma
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                LoginResponseModel _model = new LoginResponseModel()
                {
                    Email = userFromDb.Email,
                    Token = tokenHandler.WriteToken(token)
                };
                _response.Result = _model;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return _response;

            }

            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Ooops! something went wrong");
            return _response;
        }

        public async Task<ApiResponse> Register(RegisterRequestDTO model)
        {
            var userFromDb =
                _context.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower());
            if (userFromDb != null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("UserName already exist");
                return _response;
            }
            //Bunu mapping ile yapıyoruz.

            ApplicationUser newUser = new()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.UserName,
                NormalizedEmail = model.UserName.ToUpper(),
            };

            //var newUser = _mapper.Map<ApplicationUser>(model);


            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                var isTrue = _roleManager.RoleExistsAsync(UserType.Administrator.ToString()).GetAwaiter().GetResult();
                if (!_roleManager.RoleExistsAsync(UserType.Administrator.ToString()).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserType.Administrator.ToString()));
                    await _roleManager.CreateAsync(new IdentityRole(UserType.Seller.ToString()));
                    await _roleManager.CreateAsync(new IdentityRole(UserType.User.ToString()));
                }
                if (model.UserType.ToString().ToLower() == UserType.Administrator.ToString().ToLower())
                {
                    await _userManager.AddToRoleAsync(newUser, UserType.Administrator.ToString());
                }

                if (model.UserType.ToString().ToLower() == UserType.Seller.ToString().ToLower())
                {
                    await _userManager.AddToRoleAsync(newUser, UserType.Seller.ToString());
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, UserType.User.ToString());
                }

                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.IsSuccess = true;
                return _response;
            }

            foreach (var error in result.Errors)
            {
                //_response.ErrorMessages.Add(error.ToString());
                _response.ErrorMessages.Add(error.Description);
            }
            return _response;
        }
    }
}
