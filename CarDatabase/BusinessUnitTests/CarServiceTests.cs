using System;
using System.Threading.Tasks;
using CarDatabase.Business.Implementations;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;
using CarDatabase.Domain.Models;
using NUnit.Framework;
using Moq;

namespace BusinessUnitTests
{
    public class CarServiceTests
    {
        [Test]
        public async Task GetCar_CarExists_ReturnsCar()
        {
            var carContainer = new Mock<ICarId>();

            var car = new Car();
            var carDataAccessContainer = new Mock<ICarDataAccess>();
            carDataAccessContainer.Setup(t => t.GetCar(carContainer.Object)).ReturnsAsync(car);

            var carGetService = new GetCarService(carDataAccessContainer.Object);

            var result = await carGetService.GetCar(carContainer.Object);
            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void GetCar_CarNotExists_ThrowsException()
        {
            var carContainer = new Mock<ICarId>();
            carContainer.Setup(t => t.CarId).Returns(1);

            var carDataAccessContainer = new Mock<ICarDataAccess>();
            carDataAccessContainer.Setup(t => t.GetCar(carContainer.Object)).ReturnsAsync((Car) null);

            var carGetService = new GetCarService(carDataAccessContainer.Object);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await carGetService.GetCar(carContainer.Object));
        }

        [Test]
        public async Task CreateCar_CarNotExists_CreatesCar()
        {
            var carUpdateModel = new CarUpdateModel();
            var addedCar = new Car();
            var carDataAccessContainer = new Mock<ICarDataAccess>();
            carDataAccessContainer.Setup(t => t.GetCar(carUpdateModel)).ReturnsAsync((Car) null);
            carDataAccessContainer.Setup(t => t.CreateCar(carUpdateModel)).ReturnsAsync(addedCar);

            var carCreateService = new CreateCarService(carDataAccessContainer.Object);
            var result = await carCreateService.CreateCar(carUpdateModel);

            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void CreateCar_CarExists_ThrowsException()
        {
            var carUpdateModel = new CarUpdateModel();
            var existingCar = new Car();

            var carDataAccessContainer = new Mock<ICarDataAccess>();
            carDataAccessContainer.Setup(t => t.CreateCar(carUpdateModel)).ReturnsAsync(existingCar);
            carDataAccessContainer.Setup(t => t.GetCar(carUpdateModel)).ReturnsAsync(existingCar);

            var carCreateService = new CreateCarService(carDataAccessContainer.Object);

            Assert.ThrowsAsync<ArgumentException>(async () =>
                await carCreateService.CreateCar(carUpdateModel));
        }
    }
}