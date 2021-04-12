using System;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Discount : Entity
    {
        public DateTime EndDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<DiscountLevel> Levels { get; set; } =
            new HashSet<DiscountLevel>();
    }
}
