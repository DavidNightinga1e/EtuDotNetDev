using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain
{
    public class Car : IOwnerId
    {
        public ulong CarId { get; set; }
        public Owner Owner { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }

        public int OwnerId => Owner.Id;
    }
}