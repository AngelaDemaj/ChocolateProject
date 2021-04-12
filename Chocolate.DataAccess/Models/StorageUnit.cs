using System.Collections.Generic;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class StorageUnit : NamedEntity
    {
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<Sector> Sectors { get; set; }
    }
}
