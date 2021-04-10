using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class CarIdentityModel : ICarId
    {
        public ulong CarId { get; }

        public CarIdentityModel(ulong id)
        {
            CarId = id;
        }
    }
}