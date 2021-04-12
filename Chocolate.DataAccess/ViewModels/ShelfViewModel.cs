using Chocolate.DataAccess.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class ShelfViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        public int SectorId { get; set; }
        public int RawMaterialId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ICollection<Sector> Sectors { get; set; } = new HashSet<Sector>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public ICollection<ProductShelf> ProductShelves { get; set; } = new HashSet<ProductShelf>();
        public ICollection<RawMaterial> RawMaterials { get; set; } = new HashSet<RawMaterial>();
        public ICollection<RawMaterialShelf> RawMaterialShelves { get; set; } = new HashSet<RawMaterialShelf>();
    }
}