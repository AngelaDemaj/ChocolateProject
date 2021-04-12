using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chocolate.DataAccess.Models
{
    public class Employee : Person
    {
        public bool IsHeadOfDepartment { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string WorkExperience { get; set; }
        public string UserId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Leave> Leaves { get; set; } = new HashSet<Leave>();
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public ICollection<EmployeeMeeting> EmployeeMeetings { get; set; } 
            = new HashSet<EmployeeMeeting>();
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}