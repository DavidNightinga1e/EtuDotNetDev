using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class CarUpdateModel : ICarId, IOwnerId
    {
        public ulong OwnerId { get; set; }
        public ulong CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }
    }
}