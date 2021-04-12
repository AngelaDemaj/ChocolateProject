using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Address Address { get; set; }

        [Range(0,10, ErrorMessage ="The valid values are between 0 and 10.")]
        public int NumberOfStorageUnits { get; set; }
        public string WarehouseStorageUnits { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }
        public ICollection<StorageUnit> StorageUnits { get; set; } = new HashSet<StorageUnit>();
    }
}
