using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDatabase.DataAccess.Entities
{
    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        public virtual CarOwner CarOwner { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}