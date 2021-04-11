using System;
using System.Threading.Tasks;
using AutoMapper;
using CarDatabase.DataAccess.Context;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;
using CarDatabase.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDatabase.DataAccess.Implementation
{
    public class CarDataAccess : ICarDataAccess
    {
        private CarDatabaseContext Context { get; }
        private IMapper Mapper { get; }

        public CarDataAccess(CarDatabaseContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<Car> GetCar(ICarId carId)
        {
            if (carId == null)
                throw new ArgumentNullException(nameof(carId));

            var entity = await Context.Cars.FirstOrDefaultAsync(t => t.CarId == carId.CarId);

            return Mapper.Map<Car>(entity);
        }

        public async Task<Car> CreateCar(CarUpdateModel carUpdateModel)
        {
            if (carUpdateModel == null)
                throw new ArgumentNullException(nameof(carUpdateModel));

            var entityEntry = await Context.Cars.AddAsync(Mapper.Map<Entities.Car>(carUpdateModel));

            await Context.SaveChangesAsync();

            return Mapper.Map<Car>(entityEntry.Entity);
        }
    }
}