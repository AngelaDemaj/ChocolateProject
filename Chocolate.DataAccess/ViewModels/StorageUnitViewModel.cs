using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class StorageUnitViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        [Range(0, 10, ErrorMessage = "The valid values are between 0 and 10.")]
        public int NumberOfSectors { get; set; }
        public string StorageUnitSectors { get; set; }
        public Dictionary<int, string> WarehouseAddress { get; set; } = new Dictionary<int, string>();
        public ICollection<Sector> Sectors { get; set; } = new HashSet<Sector>();
        public ICollection<Warehouse> Warehouses { get; set; } = new HashSet<Warehouse>();

    }
}
