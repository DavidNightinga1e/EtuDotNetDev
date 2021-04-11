using CarDatabase.Domain.Contracts;

namespace CarDatabase.Domain.Models
{
    public class OwnerUpdateModel : IOwnerId
    {
        public int OwnerId { get; set; }
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}