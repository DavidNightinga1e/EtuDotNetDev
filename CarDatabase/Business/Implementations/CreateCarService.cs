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
            carDataAccess = carDataAccess;
        }

        public Task<Car> CreateCar(CarUpdateModel carUpdateModel)
        {
            return CarDataAccess.CreateCar(carUpdateModel);
        }
    }
}