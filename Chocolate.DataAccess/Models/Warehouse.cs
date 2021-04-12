using System.Collections.Generic;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class Warehouse : NamedEntity
    {
        public bool IsActive { get; set; }

        public ICollection<StorageUnit> StorageUnits { get; set; } 
            = new HashSet<StorageUnit>();

        public ICollection<Address> Addresses { get; set; } 
            = new HashSet<Address>();
    }
}
