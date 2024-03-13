using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyGalaxy_Auction_DataAccess.Domain;

namespace MyGalaxy_Auction_DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }      
        public string? ProfilePicture { get; set; }      
        public DateTime DateOfBirth { get; set; }

        //ICollection ile bire çok ilişki veriyoruz. Yani ilgili kullanıcı birden fazla PaymentHistory'e sahip olabilir.
        //Yani bir kullanıcı birden fazla açık arttırmaya ön ödeme yapıp dahil olmuş olabilir anlamında.
        public ICollection<PaymentHistory> PaymentHistories { get; set; }

        //Aynı zamanda birden fazla olabilir.
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Bid> Bids { get; set; }
    }
}
