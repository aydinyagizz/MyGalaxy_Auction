using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Business.Abstraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_DataAccess.Context;
using MyGalaxy_Auction_DataAccess.Domain;

namespace MyGalaxy_Auction_Business.Concrete
{
    public class VehicleService : IVehicleService
    {
        //veritabanı örneği (instance)
        private readonly ApplicationDbContext _context;
        //mapleme işlemi için
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public VehicleService(ApplicationDbContext context, IMapper mapper, ApiResponse response)
        {
            _context = context;
            _mapper = mapper;
            _response = response;
        }
        public async Task<ApiResponse> ChangeVehicleStatus(int vehicleId)
        {
            var result = await _context.Vehicles.FindAsync(vehicleId);
            if (result == null)
            {
                _response.IsSuccess = false;
                return _response;
            }
            result.IsActive = false;
            _response.IsSuccess = true;
            await _context.SaveChangesAsync();
            return _response;
        }

        public async Task<ApiResponse> CreateVehicle(CreateVehicleDTO model)
        {
            if (model != null)
            {
                var objDTO = _mapper.Map<Vehicle>(model);
                if (objDTO != null)
                {
                    //entityFramwork aracılığı ile ekleme işlemi
                    _context.Vehicles.Add(objDTO);

                    //bir işlemi kayıt etmişse olumlu diye geri dönüş yapacağız. 
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        _response.IsSuccess = true;
                        _response.Result = model;
                        _response.StatusCode = HttpStatusCode.Created;
                        return _response;
                    }
                }
            }

            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Ooops! Something went wrong");
            return _response;
        }

        public async Task<ApiResponse> DeleteVehicle(int vehicleId)
        {
            var result = await _context.Vehicles.FindAsync(vehicleId);
            if (result != null)
            {
                //silme işlemini gerçekleştiriyoruz.
                _context.Vehicles.Remove(result);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSuccess = true;
                    _response.Result = result;
                    return _response;

                }
            }

            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> GetVehicles()
        {
            // bu aracı kim satmış bilgisi için Include(x=> x.Seller) kullanıyoruz.
            var vehicle = await _context.Vehicles.Include(x => x.Seller).ToListAsync();
            if (vehicle != null)
            {
                _response.IsSuccess = true;
                _response.Result = vehicle;
                return _response;
            }

            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> GetVehicleById(int vehicleId)
        {
            // bu aracı kim satmış bilgisi için Include(x=> x.Seller) kullanıyoruz.
            var result = await _context.Vehicles.Include(x => x.Seller).FirstOrDefaultAsync(x => x.VehicleId == vehicleId);
            if (result != null)
            {
                _response.Result = result;
                _response.IsSuccess = true;
                return _response;
            }
            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> UpdateVehicle(int vehicleId, UpdateVehicleDTO model)
        {
            var result = await _context.Vehicles.FindAsync(vehicleId);
            if (result != null)
            {
                // Değiştirilmiş bilgiyi yani modeli veritabanındaki yani result ile güncelle diyoruz. bunu map'leme yöntemiyle yapıyoruz.
                Vehicle objDTO = _mapper.Map(model, result);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSuccess = true;
                    _response.Result = objDTO;
                    return _response;
                }
            }
            _response.IsSuccess = false;
            return _response;
        }
    }
}
