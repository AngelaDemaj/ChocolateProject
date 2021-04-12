using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class OrderViewModel : Entity
    {
        public PaymentType PaymentType { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        [Required(ErrorMessage = "Please enter a Date")]
        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderFulfilled { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Customer> Customers { get; set; } =
            new HashSet<Customer>();

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public ICollection<Product> AllProducts { get; set; } = new HashSet<Product>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}