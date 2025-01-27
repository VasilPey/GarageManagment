using GarageManagment.Models;
using GarageManagment.Repositories;
namespace GarageManagment.Services.Impl
{
    public class GarageServiceImpl : IGarageService
    {
        IGarageRepository garageRepository;
        public GarageServiceImpl(IGarageRepository garageRepository)
        {
            this.garageRepository = garageRepository;
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

        public Task<IEnumerable<Garage>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Garage> getGarageById(int garageId)
        {
            throw new NotImplementedException();
        }
    }
}
