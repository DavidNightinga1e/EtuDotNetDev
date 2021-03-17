using System;
using System.Threading.Tasks;
using CarDatabase.Business.Implementations;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;
using CarDatabase.Domain.Models;
using Moq;
using NUnit.Framework;

namespace BusinessUnitTests
{
    public class OwnerServiceTests
    {
        [Test]
        public async Task GetOwner_OwnerExists_ReturnsOwner()
        {
            var ownerContainer = new Mock<IOwnerId>();

            var owner = new Owner();
            var ownerDataAccessContainer = new Mock<IOwnerDataAccess>();
            ownerDataAccessContainer.Setup(t => t.GetOwner(ownerContainer.Object)).ReturnsAsync(owner);

            var ownerGetService = new GetOwnerService(ownerDataAccessContainer.Object);

            var result = await ownerGetService.GetOwner(ownerContainer.Object);
            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void GetOwner_OwnerNotExists_ThrowsException()
        {
            var ownerContainer = new Mock<IOwnerId>();
            ownerContainer.Setup(t => t.OwnerId).Returns(1);

            var ownerDataAccessContainer = new Mock<IOwnerDataAccess>();
            ownerDataAccessContainer.Setup(t => t.GetOwner(ownerContainer.Object)).ReturnsAsync((Owner) null);

            var ownerGetService = new GetOwnerService(ownerDataAccessContainer.Object);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await ownerGetService.GetOwner(ownerContainer.Object));
        }

        [Test]
        public async Task CreateOwner_OwnerNotExists_CreatesOwner()
        {
            var ownerUpdateModel = new OwnerUpdateModel();
            var addedOwner = new Owner();
            var ownerDataAccessContainer = new Mock<IOwnerDataAccess>();
            ownerDataAccessContainer.Setup(t => t.GetOwner(ownerUpdateModel)).ReturnsAsync((Owner) null);
            ownerDataAccessContainer.Setup(t => t.CreateOwner(ownerUpdateModel)).ReturnsAsync(addedOwner);

            var ownerCreateService = new CreateOwnerService(ownerDataAccessContainer.Object);
            var result = await ownerCreateService.CreateOwner(ownerUpdateModel);

            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void CreateOwner_OwnerExists_ThrowsException()
        {
            var ownerUpdateModel = new OwnerUpdateModel();
            var existingOwner = new Owner();

            var ownerDataAccessContainer = new Mock<IOwnerDataAccess>();
            ownerDataAccessContainer.Setup(t => t.CreateOwner(ownerUpdateModel)).ReturnsAsync(existingOwner);
            ownerDataAccessContainer.Setup(t => t.GetOwner(ownerUpdateModel)).ReturnsAsync(existingOwner);

            var ownerCreateService = new CreateOwnerService(ownerDataAccessContainer.Object);

            Assert.ThrowsAsync<ArgumentException>(async () =>
                await ownerCreateService.CreateOwner(ownerUpdateModel));
        }
    }
}