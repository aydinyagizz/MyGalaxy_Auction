using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BidService : IBidService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private ApiResponse _response;
        public BidService(ApplicationDbContext context, IMapper mapper, ApiResponse response)
        {
            _context = context;
            _mapper = mapper;
            _response = response;
        }
        public async Task<ApiResponse> AutomaticallyCreateBid(CreateBidDTO model)
        {
            // bid ekleme işlemini otomatik şekilde yapmak için
            var isPaid = await CheckIsPaidAuction(model.UserId, model.VehicleId);
            if (!isPaid)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please before pay auction price");
                return _response;
            }

            var result = await _context.Bids.Where(x => x.VehicleId == model.VehicleId && x.Vehicle.IsActive == true)
                .OrderByDescending(x => x.BidAmount).ToListAsync();
            if (result.Count == 0)
            {
                _response.IsSuccess = false;
                return _response;
            }

            var objDTO = _mapper.Map<Bid>(model);
            // yüzde 10'luk bir ödeme yapmasını istiyoruz.
            objDTO.BidAmount = result[0].BidAmount + (result[0].BidAmount * 10) / 100;
            objDTO.BidDate = DateTime.Now;
            _context.Bids.Add(objDTO);
            await _context.SaveChangesAsync();
            _response.IsSuccess = true;
            _response.Result = result;
            return _response;
        }

        public Task<ApiResponse> CancelBid(int bidId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> CreateBid(CreateBidDTO model)
        {
            var returnValue = await CheckIsActive(model.VehicleId);
            var isPaid = await CheckIsPaidAuction(model.UserId, model.VehicleId);

            if (!isPaid)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please before pay auction price");
                return _response;
            }

            if (returnValue == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("This car is not active");
                return _response;
            }

            if (returnValue.Price >= model.BidAmount)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("You should surpass the highest bid in the placed bids");
                return _response;
            }

            if (model != null)
            {
                //verilen en son yüksek fiyatı buluyoruz.
                var topPrice = await _context.Bids.Where(x => x.VehicleId == model.VehicleId)
                    .OrderByDescending(x => x.BidAmount).ToListAsync();

                if (topPrice.Count != 0)
                {
                    if (topPrice[0].BidAmount >= model.BidAmount)
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Entry bid amount, not lower than higher price to the system; higher price is : " + topPrice[0].BidAmount);
                        return _response;
                    }
                }

                Bid bid = _mapper.Map<Bid>(model);
                bid.BidDate = DateTime.Now;
                await _context.Bids.AddAsync(bid);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSuccess = true;
                    _response.Result = model;
                    return _response;
                }
            }

            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Ooops! something went wrong");
            return _response;

        }

        public async Task<ApiResponse> GetBidById(int bidId)
        {
            var result = await _context.Bids.Include(x => x.User).Where(x => x.BidId == bidId).FirstOrDefaultAsync();
            if (result == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Bid is not found");
                return _response;
            }

            _response.IsSuccess = true;
            _response.Result = result;
            return _response;
        }

        public async Task<ApiResponse> GetBidByVehicleId(int vehicleId)
        {
            var obj = await _context.Bids.Where(x=>x.VehicleId == vehicleId).ToListAsync();
            if (obj != null)
            {
                _response.IsSuccess = true;
                _response.Result = obj;
                return _response;
            }
            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> UpdateBid(int bidId, UpdateBidDTO model)
        {
            // Update eden kullanıcı en son verdiği teklifin üzerine çıkmalıdır.
            var isPaid = await CheckIsPaidAuction(model.UserId, model.VehicleId);
            if (!isPaid)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please before pay auction price");
                return _response;
            }

            var result = await _context.Bids.FindAsync(bidId);
            if (result == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Bid is not found");
                return _response;
            }

            if (result.BidAmount < model.BidAmount && result.UserId == model.UserId)
            {
                var objDTO = _mapper.Map(model, result);
                objDTO.BidDate = DateTime.Now;
                _response.IsSuccess = true;
                _response.Result = objDTO;
                await _context.SaveChangesAsync();
                return _response;
            }
            else if (result.BidAmount >= model.BidAmount)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("You are not entry low price than your old bid amount, your older bid amount is : " + result.BidAmount);
                return _response;

            }
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Ooops! something went wrong");
            return _response;

        }




        //bu aracın aktif olup olmadığını görmek için 
        private async Task<Vehicle> CheckIsActive(int vehicleId)
        {
            var obj = await _context.Vehicles
                .Where(x => x.VehicleId == vehicleId && x.IsActive == true && x.EndTime >= DateTime.Now)
                .FirstOrDefaultAsync();
            if (obj != null)
            {
                return obj;
            }

            return null;
        }

        // araca teklif verebilmesi için ödeme yapmış mı kontrolü yapıyoruz. Yani AuctionPrice değerinin ödenmesini kontrol ediyoruz.
        private async Task<bool> CheckIsPaidAuction(string userId, int vehicleId)
        {
            var obj = await _context.PaymentHistories
                .Where(x => x.UserId == userId && x.VehicleId == vehicleId && x.IsActive == true).FirstOrDefaultAsync();
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
