using GarageManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageManagment.DBContext
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Car> Cars { get; set; }

    }

}

