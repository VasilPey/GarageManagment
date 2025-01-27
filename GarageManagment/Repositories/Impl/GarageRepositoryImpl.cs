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
            context.Garages.Add(entity);
        }

        public void Delete(int id)
        {
            Garage garage = context.Garages.Find(id);
            context.Garages.Remove(garage);

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
            context.SaveChanges();
        }
         
        public void Update(Garage entity)
        {
            throw new NotImplementedException();
        }
    }
}
