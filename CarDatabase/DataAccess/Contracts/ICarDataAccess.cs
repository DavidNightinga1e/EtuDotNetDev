using System.Threading.Tasks;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;
using CarDatabase.Domain.Models;

namespace CarDatabase.DataAccess.Contracts
{
    public interface ICarDataAccess
    {
        Task<Car> GetCar(ICarId carId);
        Task<Car> UpdateCar(CarUpdateModel carUpdateModel);
        Task<Car> CreateCar(CarUpdateModel carUpdateModel);
    }
}