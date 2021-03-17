using System;
using System.Threading.Tasks;
using CarDatabase.Business.Contracts;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Models;

namespace CarDatabase.Business.Implementations
{
    public class CreateCarService : ICreateCarService
    {
        private ICarDataAccess CarDataAccess { get; }

        public CreateCarService(ICarDataAccess carDataAccess)
        {
            CarDataAccess = carDataAccess;
        }

        public async Task<Car> CreateCar(CarUpdateModel carUpdateModel)
        {
            var existingCar = await CarDataAccess.GetCar(carUpdateModel);
            
            if (existingCar != null)
                throw new ArgumentException("Car with such carId already exists");
            
            return await CarDataAccess.CreateCar(carUpdateModel);
        }
    }
}