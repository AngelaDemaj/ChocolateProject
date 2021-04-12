using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class CustomerViewModel : Entity
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} + {LastName}";
            }
        }
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public Phone Phone { get; set; }

        [Required(ErrorMessage ="Please enter your Phone Number")]
        public string Number { get; set; }
        public Email Mail { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        public Address Address { get; set; }

        [Required(ErrorMessage = "Please enter the Street Name")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a valid Street Number")]
        public short AddressNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid Postal Code")]
        public short PostCode { get; set; }

        [Required(ErrorMessage = "Please enter the Country")]
        public string Country { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
