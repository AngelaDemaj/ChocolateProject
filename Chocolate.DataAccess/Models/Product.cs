using Chocolate.DataAccess.Models.AbstractEntities;
using Chocolate.DataAccess.Models.Enums;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Product : NamedEntity
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public ProductCategory Category { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = 
            new HashSet<OrderProduct>();
        public ICollection<RawMaterialProduct> RawMaterialProducts { get; set; } = 
            new HashSet<RawMaterialProduct>();
        public ICollection<ProductShelf> Shelves { get; set; } = 
            new HashSet<ProductShelf>();
        public List<Photo> Photos { get; set; } = 
            new List<Photo>();
        public ICollection<Favorite> Favorites { get; set; } = 
            new HashSet<Favorite>();
    }
}