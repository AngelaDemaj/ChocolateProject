using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class OfferItemViewModel : Entity
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }
        public int OfferId { get; set; }
        public int RawMaterialId { get; set; }
        public Offer Offer { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
        public ICollection<RawMaterial> RawMaterials { get; set; } = new HashSet<RawMaterial>();
    }
}
