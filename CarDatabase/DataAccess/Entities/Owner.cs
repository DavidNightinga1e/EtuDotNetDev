using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDatabase.DataAccess.Entities
{
    public class Owner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}