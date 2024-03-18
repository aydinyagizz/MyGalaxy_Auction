﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MyGalaxy_Auction_DataAccess.Models;

namespace MyGalaxy_Auction_DataAccess.Domain
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string BrandAndModel { get; set; }
        public int ManufacturingYear { get; set; }
        public string Color { get; set; }
        public decimal EngineCapacity { get; set; }
        public decimal Price { get; set; }
        public int Millage { get; set; }
        public string PlateNumber { get; set; }
        public double AuctionPrice { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }

        // bir aracın bir satıcısı olur.
        public string SellerId { get; set; }

        [JsonIgnore]
        public ApplicationUser Seller { get; set; }

        // bir aracın birden fazla teklifi olabilir.
        public virtual List<Bid> Bids { get; set; }
    }
}
