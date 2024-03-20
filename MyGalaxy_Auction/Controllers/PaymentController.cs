using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Common;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_DataAccess.Context;
using Stripe;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private ApiResponse _response;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private StripeSettings _stripeSettings;

        public PaymentController(ApiResponse response, IConfiguration configuration, ApplicationDbContext context, IOptions<StripeSettings> options)
        {
            _response = response;
            _configuration = configuration;
            _context = context;
            _stripeSettings = options.Value;
        }


        [HttpPost("Pay")]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId, int vehicleId)
        {
            //eski yöntem buydu. artık bunuCore katmanında Common/StripeSettings, Api katmanında Extensions/OptionsExt içerisinde daha düzenli yazdık.
            // StripeConfiguration.ApiKey = _configuration.GetValue<string>("StripeSettings:SecretKey");

            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            //ödenecek miktar
            var amountToBePaid = await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == vehicleId);

            var options = new PaymentIntentCreateOptions
            {
                Amount = (int)(amountToBePaid.AuctionPrice * 100),
                Currency = "usd",
                //ödeme tipi
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var response = service.Create(options);

            CreatePaymentHistoryDTO model = new()
            {
                ClientSecret = response.ClientSecret,
                StripePaymentIntentId = response.Id,
                UserId = userId,
                VehicleId = vehicleId
            };

            _response.Result = model;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
    }
}
