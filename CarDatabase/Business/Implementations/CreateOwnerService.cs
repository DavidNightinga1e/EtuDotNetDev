using System;
using System.Threading.Tasks;
using CarDatabase.Business.Contracts;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Models;

namespace CarDatabase.Business.Implementations
{
    public class CreateOwnerService : ICreateOwnerService
    {
        private IOwnerDataAccess OwnerDataAccess { get; }

        public CreateOwnerService(IOwnerDataAccess ownerDataAccess)
        {
            OwnerDataAccess = ownerDataAccess;
        }

        public async Task<Owner> CreateOwner(OwnerUpdateModel ownerUpdateModel)
        {
            var existingOwner = await OwnerDataAccess.GetOwner(ownerUpdateModel);

            if (existingOwner != null)
                throw new ArgumentException("Owner with such ownerId already exists");

            return await OwnerDataAccess.CreateOwner(ownerUpdateModel);
        }
    }
}