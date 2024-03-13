using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGalaxy_Auction_DataAccess.Models;

namespace MyGalaxy_Auction_DataAccess.Domain
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidDate { get; set; }
        public string BidStatus { get; set; } = MyGalaxy_Auction_DataAccess.Enums.BidStatus.Pending.ToString();
        public int UserId { get; set;}

        public ApplicationUser User { get; set;}

        // bu teklif bir araca yapılabilir. Yani bir satır bir aracı ilişkilendirebilir.
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
