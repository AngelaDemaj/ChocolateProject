using System;

namespace Chocolate.DataAccess.Models
{
    public class Purchase : Entity
    {
        public DateTime DateReceived { get; set; }
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
    }
}
