using GarageManagment.DBContext;
using GarageManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageManagment.Repositories.Impl
{
    public class CarRepositoryImpl : ICarRepository
    {
        #region Fields And Constructors
        private AppDbContext context;
       public CarRepositoryImpl(AppDbContext context){
            this.context = context;
            
        }


        #endregion

        #region Methods
        public void Save()
        {
            context.SaveChanges();
        }
        void ICarRepository.Add(Car entity)
        {
            context.Cars.Add(entity);
            
        }

        void ICarRepository.Delete(int id)
        {
            Car car = context.Cars.Find(id);
            if (car != null)
            {
                context.Cars.Remove(car);
            }
            else throw new Exception($"Car with id {id} is not found");
       
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await context.Cars.ToListAsync();
        }

        async Task<Car> ICarRepository.GetById(int id)
        {
            Car car = await context.Cars.FindAsync(id);
            if (car != null)
            {
                return car;
            }
            else throw new Exception($"Car with id {id} is not found");
        }

        void ICarRepository.Update(Car entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
