using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGalaxy_Auction_Business.Abstraction;
using MyGalaxy_Auction_Business.Dtos;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VehicleController(IVehicleService vehicleService, IWebHostEnvironment webHostEnvironment)
        {
            _vehicleService = vehicleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("CreateVehicle")]
        //resim eklemesi için [FromForm] ihtiyacımız var
        public async Task<IActionResult> AddVehicle([FromForm]CreateVehicleDTO model)
        {
            if (ModelState.IsValid)
            {
                //resim ekleme
                if (model.File == null || model.File.Length == 0)
                {
                    return BadRequest();
                }

                //resimleri API altında Images klasörü ekledik ve oraya atacağız.
                // _webHostEnvironment.ContentRootPath, "Images" ile ilgili dizinde Images klasörünü bul diyoruz.
                string uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Images");
                // dosya adını şifreleyip o şekilde kayıt edeceğiz. dışarıdan gelen isimle kayıt etmiyoruz.
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.File.FileName)}";
                string filePath = Path.Combine(uploadFolder, fileName);
               

                //model içine fileName'i gönderiyoruz.
                model.Image = fileName;

                var result = await _vehicleService.CreateVehicle(model);
                if (result.IsSuccess)
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(fileStream);
                    }

                    return Ok(result);
                }
            }

            return BadRequest();
        }

        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetVehicles();
            return Ok(vehicles);
        }

        [HttpPut("UpdateVehicle")]
        // Route'dan id!yi alacağız.
        public async Task<IActionResult> UpdateVehicle([FromRoute] int vehicleId, UpdateVehicleDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleService.UpdateVehicle(vehicleId, model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        // [HttpDelete("{vehicleId}")] bu şekilde rougte'dan bir id göndereceğimizi söylüyoruz. tavsiye edilen bir yöntem değil.
        [HttpDelete("{vehicleId}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int vehicleId)
        {
            var result = await _vehicleService.DeleteVehicle(vehicleId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int vehicleId)
        {
            var result = await _vehicleService.GetVehicleById(vehicleId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("{vehicleId}")]
        public async Task<IActionResult> ChangeVehicleStatus([FromRoute] int vehicleId)
        {
            var result = await _vehicleService.ChangeVehicleStatus(vehicleId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(); 
        }
    }
}
