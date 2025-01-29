using GarageManagment.Models;

namespace GarageManagment.Repositories
{
    public interface IGarageRepository
    {
        Task<IEnumerable<Garage>> GetAllAsync();
        Task<Garage> GetById(int id);
        void Add(Garage entity);
        void Update(int garageid,Garage entity);
        void Delete(int id);
        void Save();
    }
}
