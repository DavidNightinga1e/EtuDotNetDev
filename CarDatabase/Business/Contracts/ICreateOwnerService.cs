using System.Threading.Tasks;
using CarDatabase.Domain;
using CarDatabase.Domain.Models;

namespace CarDatabase.Business.Contracts
{
    public interface ICreateOwnerService
    {
        Task<Owner> CreateOwner(OwnerUpdateModel ownerUpdateModel);
    }
}