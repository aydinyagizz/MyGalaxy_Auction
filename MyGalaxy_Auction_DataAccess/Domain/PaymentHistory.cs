using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGalaxy_Auction_DataAccess.Models;

namespace MyGalaxy_Auction_DataAccess.Domain
{
    public class PaymentHistory
    {
        [Key] 
        public int PaymentId { get; set; }

       
        public bool IsActive { get; set; }
        public DateTime PayDate{ get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        // hangi araca ödeme yapıldığına dair ilişki oluşturuyoruz.
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
