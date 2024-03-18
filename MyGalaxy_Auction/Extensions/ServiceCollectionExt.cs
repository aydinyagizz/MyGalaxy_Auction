using MyGalaxy_Auction_Business.Abstraction;
using MyGalaxy_Auction_Business.Concrete;
using MyGalaxy_Auction_Core.Models;

namespace MyGalaxy_Auction.Extensions
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region services
            // dependency injection ile ilgili inteface'yi tetiklediğimiz zaman hangi sınıfta bu interface metodunun override edildiğinin adresini belirtiyoruz.
            // IUserService verilirse bunun adresinin UserService içerisinde olduğunu bil diyoruz.
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped(typeof(ApiResponse));
            #endregion

            return services;
        }
    }
}
