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
            if (garage != null)
            {
                context.Garages.Remove(garage);

            }
            else throw new Exception($"Garage with id {id} cannot be found");
        }
        public async Task<IEnumerable<Garage>> GetAllAsync()
        {
            return await context.Garages.ToListAsync();
        }

        public async Task<Garage> GetById(int id)
        {
            Garage garage = await context.Garages.FindAsync(id);
            if (garage != null)
            {
                return garage;
            }
            else
            {
                throw new Exception($"garage with id {id} is not found");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
         
        public async void Update(int garageid, Garage entity)
        {
            Garage garage = await context.Garages.FindAsync(garageid);
            garage.Name = entity.Name;
            garage.Location = entity.Location;
            garage.Cars = entity.Cars;
            Save();
        }
    }
}
