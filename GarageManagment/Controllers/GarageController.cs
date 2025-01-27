using Microsoft.AspNetCore.Mvc;
using GarageManagment.Models;
using GarageManagment.Services;
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

    }
}
