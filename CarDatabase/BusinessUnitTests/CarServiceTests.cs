using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace BusinessUnitTests
{
    public class CarServiceTests
    {
        [SetUp]
        public Task GetCar_CarExists_ReturnsCar()
        {
            // // Arrange
            // var departmentContainer = new Mock<IDepartmentContainer>();
            //
            // var department = new Department();
            // var departmentDataAccess = new Mock<IDepartmentDataAccess>();
            // departmentDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(department);
            //
            // var departmentGetService = new DepartmentGetService(departmentDataAccess.Object);
            //
            // // Act
            // var action = new Func<Task>(() => departmentGetService.ValidateAsync(departmentContainer.Object));
            //
            // // Assert
            // await action.Should().NotThrowAsync<Exception>();

            // var carContainer = new Mock<ICarId>();
            //
            // var car = new Car();
            // var carDataAccessContainer = new Mock<ICarDataAccess>();
            // carDataAccessContainer.Setup(t => t.GetCar(carContainer.Object)).ReturnsAsync(car);
            //
            // var carGetService = new GetCarService(carDataAccessContainer.Object);
            //
            // var result = await carGetService.GetCar(carContainer.Object);
            // Assert.AreNotEqual(result, null);
            // Assert.Pass();
            return null;
        }

        [Test]
        public void Test1()
        {
        }
    }
}