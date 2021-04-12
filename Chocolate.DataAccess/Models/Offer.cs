using Chocolate.DataAccess.Models.AbstractEntities;
using System;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Offer : NamedEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime ReviewDeadline { get; set; }
        public DateTime? DateReviewed { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public DiscountLevel DiscountLevel { get; set; }
        public int DiscountLevelId { get; set; }
        public ICollection<OfferItem> OfferItems { get; set; } =
            new HashSet<OfferItem>();
    }
}