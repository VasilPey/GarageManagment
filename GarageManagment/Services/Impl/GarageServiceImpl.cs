using GarageManagment.Models;
using GarageManagment.Repositories;
namespace GarageManagment.Services.Impl
{
    public class GarageServiceImpl : IGarageService
    {
        ICarRepository carRepository;
        IGarageRepository garageRepository;
        public GarageServiceImpl(IGarageRepository garageRepository, ICarRepository carRepository)
        {
            this.garageRepository = garageRepository;
            this.carRepository = carRepository;
        }

        public void addGarage(Garage garage)
        {
            Garage garage1 = new Garage();
            garage1.Name = garage.Name;
            garage1.Location = garage.Location;
            garage1.Cars = garage.Cars;
            garageRepository.Add(garage1);
            garageRepository.Save();
        }

        public void deleteGarage(int garageId)
        {
            garageRepository.Delete(garageId);
        }

        public async Task<IEnumerable<Garage>> getAll()
        {
            return await garageRepository.GetAllAsync();
        }

        public async Task<Garage> getGarageById(int garageId)
        {
            return await garageRepository.GetById(garageId);
        }

        public void updateGarage(int garageId, Garage garage)
        {
            garageRepository.Update(garageId, garage);
        }
    }
}
