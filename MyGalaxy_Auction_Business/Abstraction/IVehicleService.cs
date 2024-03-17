using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;

namespace MyGalaxy_Auction_Business.Abstraction
{
    public interface IVehicleService
    {
        //ekleme yapacağımız method
        Task<ApiResponse> CreateVehicle(CreateVehicleDTO model);
        // vehicle'leri çeken sevis için
        Task<ApiResponse> GetVehicles();

        //güncelleme yapacağımız method
        Task<ApiResponse> UpdateVehicle(int vehicleId, UpdateVehicleDTO model);

        //silme işlemi için
        Task<ApiResponse> DeleteVehicle(int vehicleId);

        //ilgili aracın detayına gitmek için
        Task<ApiResponse> GetVehicleById(int vehicleId);

        //Araç durumlarını değişebilmesi için
        Task<ApiResponse> ChangeVehicleStatus(int vehicleId);
    }
}
