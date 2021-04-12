using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chocolate.DataAccess.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string LastName { get; set; }

        public bool IsHeadOfDepartment { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Work Experience is required")]
        public string WorkExperience { get; set; }

        [Required(ErrorMessage ="Please enter a User Name")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Address Address { get; set; }

        [Required(ErrorMessage = "Please enter the Street Name")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a valid Street Number")]
        public int AddressNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid Postal Code")]
        public int PostCode { get; set; }

        [Required(ErrorMessage = "Please enter the Country")]
        public string Country { get; set; }

        public string Comments { get; set; }

        public Email Mail { get; set; }

        [Required(ErrorMessage = "Please enter a Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter a valid Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
        ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, " +
        "one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }

        public MailType MailType { get; set; }

        public Phone Phone { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number")]
        public string PhoneNumber { get; set; }

        public PhoneType PhoneType { get; set; }

        public ICollection<Leave> Leaves { get; set; } =
            new HashSet<Leave>();

        public ICollection<Department> Departments { get; set; } =
            new HashSet<Department>();

        public ICollection<Address> Addresses { get; set; } =
            new HashSet<Address>();

        public ICollection<IdentityUser> Users { get; set; } =
           new HashSet<IdentityUser>();
    }
}