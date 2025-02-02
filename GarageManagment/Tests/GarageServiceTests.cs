using GarageManagment.Models;
using GarageManagment.Repositories;
using GarageManagment.Services.Impl;
using Moq;
using Xunit;

namespace GarageManagment.Tests
{
    public class GarageServiceTests
    {
        private readonly Mock<IGarageRepository> _mockGarageRepository;
        private readonly Mock<ICarRepository> _mockCarRepository;
        private readonly GarageServiceImpl _garageService;

        public GarageServiceTests()
        {
            _mockGarageRepository = new Mock<IGarageRepository>();
            _mockCarRepository = new Mock<ICarRepository>();
            _garageService = new GarageServiceImpl(_mockGarageRepository.Object, _mockCarRepository.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfGarages()
        {
            
            var garages = new List<Garage>
            {
                new Garage { Id = 1, Name = "Garage A", Location = "Location A", Cars = new List<Car>() },
                new Garage { Id = 2, Name = "Garage B", Location = "Location B", Cars = new List<Car>() }
            };

            _mockGarageRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(garages);

           
            var result = await _garageService.getAll();

            
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetGarageById_ShouldReturnGarage()
        {
            
            var garage = new Garage { Id = 1, Name = "Garage A", Location = "Location A", Cars = new List<Car>() };
            _mockGarageRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(garage);

            
            var result = await _garageService.getGarageById(1);

           
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Garage A", result.Name);
        }

        [Fact]
        public void AddGarage_ShouldCallRepositoryAddGarage()
        {
            
            var garage = new Garage { Id = 1, Name = "Garage A", Location = "Location A", Cars = new List<Car>() };

           
            _garageService.addGarage(garage);

           
            _mockGarageRepository.Verify(repo => repo.AddGarage(It.IsAny<Garage>()), Times.Once);
        }

        [Fact]
        public void DeleteGarage_ShouldCallRepositoryDelete()
        {
            
            int garageId = 1;

            
            _garageService.deleteGarage(garageId);

            
            _mockGarageRepository.Verify(repo => repo.Delete(garageId), Times.Once);
        }
    }
}