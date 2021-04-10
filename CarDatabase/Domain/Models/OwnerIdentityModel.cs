using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class OwnerIdentityModel : IOwnerId
    {
        public ulong OwnerId { get; }

        public OwnerIdentityModel(ulong id)
        {
            OwnerId = id;
        }
    }
}