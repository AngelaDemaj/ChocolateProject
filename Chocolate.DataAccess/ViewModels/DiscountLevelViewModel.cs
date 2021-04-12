using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class DiscountLevelViewModel : Entity
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public double Amount { get; set; }
        [Range(0,100.00, ErrorMessage ="Please enter a value from 0 to 100")]
        public double DiscountPercentage { get; set; }
        public Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();
    }
}
