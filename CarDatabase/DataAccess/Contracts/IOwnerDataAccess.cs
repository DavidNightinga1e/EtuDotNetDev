using System.Threading.Tasks;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;
using CarDatabase.Domain.Models;

namespace CarDatabase.DataAccess.Contracts
{
    public interface IOwnerDataAccess
    {
        Task<Owner> GetOwner(IOwnerId ownerId);
        Task<Owner> UpdateOwner(OwnerUpdateModel ownerUpdateModel);
        Task<Owner> CreateOwner(OwnerUpdateModel ownerUpdateModel);
    }
}