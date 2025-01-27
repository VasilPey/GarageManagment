using GarageManagment.DBContext;
using GarageManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageManagment.Repositories.Impl
{
    public class GarageRepositoryImpl : IGarageRepository
    {
        private AppDbContext context; 


        public GarageRepositoryImpl(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Garage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Garage>> GetAllAsync()
        {
            return await context.Garages.ToListAsync();
        }

        public Task<Garage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Garage entity)
        {
            throw new NotImplementedException();
        }
    }
}
