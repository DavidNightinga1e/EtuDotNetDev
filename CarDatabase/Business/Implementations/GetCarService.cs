using System;
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
            CarDataAccess = carDataAccess;
        }

        public async Task<Car> GetCar(ICarId carId)
        {
            if (carId == null)
                throw new ArgumentNullException(nameof(carId));
            
            var result = await CarDataAccess.GetCar(carId);
            
            if (result == null)
                throw new InvalidOperationException($"No such car with {nameof(carId)} equal {carId}");
            
            return result;
        }
    }
}