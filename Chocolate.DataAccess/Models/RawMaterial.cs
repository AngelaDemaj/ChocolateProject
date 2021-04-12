using System.Collections.Generic;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class RawMaterial : NamedEntity
    {
        public double Price { get; set; }
        public ICollection<RawMaterialShelf> Shelves { get; set; }
        public ICollection<RawMaterialSupplier> Suppliers { get; set; }
        public ICollection<RawMaterialProduct> Products { get; set; }
        public ICollection<OfferItem> OfferItems { get; set; }
    }
}
