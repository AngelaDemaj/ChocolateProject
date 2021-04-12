using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class OfferViewModel : Entity
    {
        [Required(ErrorMessage = "Please add a Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Please add a Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        public DateTime ReviewDeadline { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        public DateTime? DateReviewed { get; set; }

        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public int SupplierId { get; set; }
        public int DiscountLevelId { get; set; }
        public string FullName { get; set; }

        public Employee Employee { get; set; }
        public Supplier Supplier { get; set; }
        public DiscountLevel DiscountLevel { get; set; }

        public ICollection<Employee> Employees { get; set; }
            = new HashSet<Employee>();

        public ICollection<Supplier> Suppliers { get; set; }
            = new HashSet<Supplier>();

        public ICollection<DiscountLevel> DiscountLevels { get; set; }
            = new HashSet<DiscountLevel>();
    }
}