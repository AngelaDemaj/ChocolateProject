using Chocolate.DataAccess.Models.AbstractEntities;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Shelf : NamedEntity
    {
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public ICollection<ProductShelf> Products { get; set; } = new HashSet<ProductShelf>();
        public ICollection<RawMaterialShelf> RawMaterials { get; set; } = new HashSet<RawMaterialShelf>();
    }
}