using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class DiscountViewModel : Entity
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime EndDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
