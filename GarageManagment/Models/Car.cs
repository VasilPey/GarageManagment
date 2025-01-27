using Microsoft.EntityFrameworkCore;

namespace GarageManagment.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Car
    {
        [Key]
        [JsonIgnore]
        public int id { get; set; }
        public int Make { get; set; }
        public int Model { get; set; }
        public int Color { get; set; }
        public int YearOfProduction {  get; set; }
        public int HorsePower { get; set; }

    }
}
