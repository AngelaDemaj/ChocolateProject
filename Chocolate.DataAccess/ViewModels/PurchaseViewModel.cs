using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class PurchaseViewModel : Entity
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        [Required(ErrorMessage ="Please enter a Date")]
        public DateTime DateReceived { get; set; }
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
    }
}
