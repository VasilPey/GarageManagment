using GarageManagment.Services;
using Microsoft.AspNetCore.Mvc;
using GarageManagment.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GarageManagment.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController : Controller
    {
        ICarService carService;
       public CarController(ICarService carService) {
            this.carService = carService;

        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            IEnumerable<Car> list = await carService.getAll();
            return Ok(list);
        }
        [HttpGet("{carId}")]
        public async Task<IActionResult> getAll(int carId)
        {
            Car car = await carService.getCarById(carId);
            return Ok(car);
        }
        [HttpPost("add")]
        public void addCar(Car car)
        {
            carService.addCar(car);
        }
        [HttpPut("Update/{carId}")]
        public void updateCar(int carId, Car car)
        {
            carService.updateCar(carId, car);
        }
    }
}
