using Chocolate.DataAccess.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class SectorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        public int StorageUnitId { get; set; }
        public StorageUnit StorageUnit { get; set; }
        public int NumberOfShelves { get; set; }
        public string SectorShelves { get; set; }
        public ICollection<StorageUnit> StorageUnits { get; set; } = new HashSet<StorageUnit>();
        public ICollection<Shelf> Shelves { get; set; } = new HashSet<Shelf>();
    }
}
