namespace GarageManagment.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    public class Garage
    {
        [Key]
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Car> Cars { get; set; } = null!;
    }
}
