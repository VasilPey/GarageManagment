namespace GarageManagment.Models
    
{
    using System.ComponentModel.DataAnnotations;
    public class Garage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Car> Car { get; set; } = null!;
    }
}
