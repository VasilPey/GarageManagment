using Microsoft.AspNetCore.Mvc;
using GarageManagment.Models;
using GarageManagment.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace GarageManagment.Controllers
{
    [ApiController]
    [Route("garage")]
    public class GarageController : Controller
    {
        IGarageService garageService;
        public GarageController(IGarageService garageService)
        {
            this.garageService = garageService;
        }
        [HttpPost("add")]
        public void addGarage(Garage garage)
        {
            garageService.addGarage(garage);
        }
        [HttpDelete("delete/{id}")]
        public void deleteGarage(int id)
        {
            garageService.deleteGarage(id);
        }
        [HttpPut("update/{garageid}")]
        public void updateGarage(int garageid, Garage garage)  
        {
            garageService.updateGarage(garageid, garage);
        }
        [HttpGet]
        public async Task <IActionResult> getAll()
        {
            IEnumerable<Garage> list = await garageService.getAll();
            return Ok(list);
        }


    }
}
