using System.Threading.Tasks;
using CarDatabase.Business.Contracts;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;

namespace CarDatabase.Business.Implementations
{
    public class GetCarService : IGetCarService
    {
        private ICarDataAccess CarDataAccess { get; }

        public GetCarService(ICarDataAccess carDataAccess)
        {
            carDataAccess = carDataAccess;
        }

        public Task<Car> GetCar(ICarId carId)
        {
            return CarDataAccess.GetCar(carId);
        }
    }
}