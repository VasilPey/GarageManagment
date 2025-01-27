using GarageManagment.Repositories;
using GarageManagment.Repositories.Impl;
using GarageManagment.Models;

namespace GarageManagment.Services
{
    public interface ICarService
    {
        public Task<IEnumerable<Car>> getAll();
        public Task<Car> getCarById(int carId);
        public void addCar(Car car);

        public void updateCar(int carId, Car car);
    }
}
