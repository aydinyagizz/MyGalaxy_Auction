using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;

namespace MyGalaxy_Auction_Business.Abstraction
{
    public interface IBidService
    {
        Task<ApiResponse> CreateBid(CreateBidDTO model);
        Task<ApiResponse> UpdateBid(int bidId, UpdateBidDTO model);
        Task<ApiResponse> GetBidById(int bidId);

        //ilgili teklifi iptal etmesi için
        Task<ApiResponse> CancelBid(int bidId);
        Task<ApiResponse> AutomaticallyCreateBid(CreateBidDTO model);
        Task<ApiResponse> GetBidByVehicleId(int vehicleId);
    }
}
