using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_DataAccess.Context;
using MyGalaxy_Auction_DataAccess.Models;

namespace MyGalaxy_Auction.Extensions
{
    public static class PersistenceExtensionLayer
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region Context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            return services;
        }
    }
}
