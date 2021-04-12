using Chocolate.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Order : Entity
    {
        public PaymentType PaymentType { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
            = new HashSet<OrderProduct>();
    }
}