using System;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Meeting : Entity
    {
        public string Title { get; set; }
        public DateTime When { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<EmployeeMeeting> EmployeeMeetings { get; set; } 
            = new HashSet<EmployeeMeeting>();
    }
}
