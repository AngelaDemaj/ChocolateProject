using System.Collections.Generic;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class Sector : NamedEntity
    {
        public int StorageUnitId { get; set; }
        public StorageUnit StorageUnit { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
    }
}
