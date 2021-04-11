using System;
using System.Threading.Tasks;
using CarDatabase.Business.Contracts;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;

namespace CarDatabase.Business.Implementations
{
    public class GetOwnerService : IGetOwnerService
    {
        private IOwnerDataAccess OwnerDataAccess { get; }

        public GetOwnerService(IOwnerDataAccess ownerDataAccess)
        {
            OwnerDataAccess = ownerDataAccess;
        }

        public async Task<Owner> GetOwner(IOwnerId ownerId)
        {
            if (ownerId == null)
                throw new ArgumentNullException(nameof(ownerId));

            var result = await OwnerDataAccess.GetOwner(ownerId);

            if (result == null)
                throw new InvalidOperationException($"No such owner with {nameof(ownerId)} equal {ownerId.OwnerId}");

            return result;
        }
    }
}