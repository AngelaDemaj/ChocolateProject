using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Eshop.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a User Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public Email Mail { get; set; }

        [Required(ErrorMessage ="Please enter your Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
        ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, " +
        "one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }

        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public Address Address { get; set; }

        [Required(ErrorMessage = "Please enter the Street Name")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a valid Street Number")]
        public short AddressNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid Postal Code")]
        public short PostCode { get; set; }

        [Required(ErrorMessage = "Please enter the Country")]
        public string Country { get; set; }

        public Phone Phone { get; set; }
        [Required(ErrorMessage ="Please enter your Phone Number")]
        public string Number { get; set; }
    }
}
