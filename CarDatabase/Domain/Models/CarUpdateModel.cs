using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class CarUpdateModel : ICarId, IOwnerId
    {
        public int OwnerId { get; set; }
        public int CarId { get; set; }
        
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }
    }
}