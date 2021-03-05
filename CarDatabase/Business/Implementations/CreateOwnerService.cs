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
        
        public Task<Owner> CreateOwner(OwnerUpdateModel ownerUpdateModel)
        {
            return OwnerDataAccess.CreateOwner(ownerUpdateModel);
        }
    }
}