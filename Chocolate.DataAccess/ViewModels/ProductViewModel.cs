using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Barcode")]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a positive Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter the Weight")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Enter a valid Weight")]
        public double Weight { get; set; }

        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        public string ImageString { get; set; }

        public ProductCategory Category { get; set; }
        //public bool IsDeleted { get; set; }
        public ICollection<RawMaterial> RawMaterials { get; set; }
        public ICollection<RawMaterialProduct> RawMaterialProducts { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<int> RawMaterialIds { get; set; } = new HashSet<int>();
    }
}