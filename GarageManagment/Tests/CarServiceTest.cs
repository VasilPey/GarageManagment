using GarageManagment.Models;
using GarageManagment.Repositories;
using GarageManagment.Services.Impl;
using Moq;
using Xunit;

namespace GarageManagment.Tests
{
    public class CarServiceTests
    {
        private readonly Mock<ICarRepository> _mockCarRepository;
        private readonly CarServiceImpl _carService;

        public CarServiceTests()
        {
            _mockCarRepository = new Mock<ICarRepository>();
            _carService = new CarServiceImpl(_mockCarRepository.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfCars()
        {
            
            var cars = new List<Car>
            {
                new Car { id = 1, Brand = "Toyota", Model = "Corolla", Color = "Red", YearOfProduction = 2020, HorsePower = 150 },
                new Car { id = 2, Brand = "Honda", Model = "Civic", Color = "Blue", YearOfProduction = 2019, HorsePower = 140 }
            };

            _mockCarRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(cars);

           
            var result = await _carService.getAll();

            
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetCarById_ShouldReturnCar()
        {
            
            var car = new Car { id = 1, Brand = "Toyota", Model = "Corolla", Color = "Red", YearOfProduction = 2020, HorsePower = 150 };
            _mockCarRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(car);

            
            var result = await _carService.getCarById(1);

            
            Assert.NotNull(result);
            Assert.Equal(1, result.id);
            Assert.Equal("Toyota", result.Brand);
        }

        [Fact]
        public void AddCar_ShouldCallRepositoryAdd()
        {
          
            var car = new Car { id = 1, Brand = "Toyota", Model = "Corolla", Color = "Red", YearOfProduction = 2020, HorsePower = 150 };

        
            _carService.addCar(car);

           
            _mockCarRepository.Verify(repo => repo.Add(It.IsAny<Car>()), Times.Once);
            _mockCarRepository.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void UpdateCar_ShouldCallRepositoryUpdate()
        {
           
            var car = new Car { id = 1, Brand = "Toyota", Model = "Corolla", Color = "Red", YearOfProduction = 2020, HorsePower = 150 };

            
            _carService.updateCar(1, car);

            
            _mockCarRepository.Verify(repo => repo.Update(1, It.IsAny<Car>()), Times.Once);
        }
    }
}
