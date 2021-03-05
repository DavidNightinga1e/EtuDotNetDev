using System.Threading.Tasks;
using CarDatabase.Domain;
using CarDatabase.Domain.Models;

namespace CarDatabase.Business.Contracts
{
    public interface ICreateCarService
    {
        Task<Car> CreateCar(CarUpdateModel carUpdateModel);
    }
}