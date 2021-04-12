using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public abstract class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Email> Emails { get; set; } = new HashSet<Email>();
        public ICollection<Phone> Phones { get; set; } = new HashSet<Phone>();
    }
}
