using GarageManagment.Models;

namespace GarageManagment.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
         Task <Car> GetById(int id);
        void Add(Car entity);
        void Update(Car entity);
        void Delete(int id);
        void Save();
    }
}
