using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class CarCreateDTO
    {
        [Required(ErrorMessage = "OwnerId is required")]
        public int? Owner { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }
    }
}