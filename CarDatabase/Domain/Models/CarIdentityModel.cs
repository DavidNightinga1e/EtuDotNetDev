using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class CarIdentityModel : ICarId
    {
        public int CarId { get; }

        public CarIdentityModel(int id)
        {
            CarId = id;
        }
    }
}