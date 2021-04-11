using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class OwnerIdentityModel : IOwnerId
    {
        public int OwnerId { get; }

        public OwnerIdentityModel(int id)
        {
            OwnerId = id;
        }
    }
}