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

        public Task<Owner> GetOwner(IOwnerId ownerId)
        {
            return OwnerDataAccess.GetOwner(ownerId);
        }
    }
}