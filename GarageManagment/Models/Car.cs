using Microsoft.EntityFrameworkCore;

namespace GarageManagment.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Car
    {
        [Key]
        
        public int id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int YearOfProduction {  get; set; }
        public int HorsePower { get; set; }

    }
}
