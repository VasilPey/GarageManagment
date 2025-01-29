using GarageManagment.Models;

namespace GarageManagment.Services
{
    public interface IGarageService
    {
        public Task<IEnumerable<Garage>> getAll();
        public Task<Garage> getGarageById(int garageId);
        public void addGarage(Garage garage);
        public void deleteGarage(int garageId);
        public void updateGarage(int garageId, Garage garage);
    }
}
