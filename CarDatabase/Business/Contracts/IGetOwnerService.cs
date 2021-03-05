using System.Threading.Tasks;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;

namespace CarDatabase.Business.Contracts
{
    public interface IGetOwnerService
    {
        Task<Owner> GetOwner(IOwnerId ownerId);
    }
}