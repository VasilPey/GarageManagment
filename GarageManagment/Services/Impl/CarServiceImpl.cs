namespace GarageManagment.Services.Impl
  
{
    using GarageManagment.Models;
    using GarageManagment.Repositories;

    public class CarServiceImpl : ICarService
    {
        ICarRepository carRepository;
        public CarServiceImpl(ICarRepository carRepository) 
        {
            this.carRepository = carRepository;
        }

        public void addCar(Car car)
        {
            Car car1 = new Car();
            car1.Brand = car.Brand;
            car1.Model = car.Model;
            car1.Color = car.Color;
            car1.HorsePower = car.HorsePower;
            car1.YearOfProduction = car.YearOfProduction;
            carRepository.Add(car1);
            carRepository.Save();
        }

        public async Task<IEnumerable<Car>> getAll()
        {
           return await carRepository.GetAllAsync();
        }

        public async Task<Car> getCarById(int carId)
        {
           return await carRepository.GetById(carId);
        }

        public void updateCar(int carId, Car car)
        {
            carRepository.Update(carId, car);
        }
    }
}
