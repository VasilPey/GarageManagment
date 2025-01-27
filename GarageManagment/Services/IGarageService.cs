using GarageManagment.Models;

namespace GarageManagment.Services
{
    public interface IGarageService
    {
        public Task<IEnumerable<Garage>> getAll();
        public Task<Garage> getGarageById(int garageId);
        public void addGarage(Garage garage);
    }
}
