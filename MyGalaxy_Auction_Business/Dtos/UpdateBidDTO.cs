﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Business.Dtos
{
    public class UpdateBidDTO
    {
        public decimal BidAmount { get; set; }
        public DateTime BidDate { get; set; }
        public string BidStatus { get; set; }
        public string? UserId { get; set; }

        // bu teklif bir araca yapılabilir. Yani bir satır bir aracı ilişkilendirebilir.
        public int VehicleId { get; set; }
    }
}
