using Chocolate.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Leave : Entity
    {
        public LeaveType LeaveType { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public ICollection<LeaveHistory> LeaveHistories { get; set; } 
            = new HashSet<LeaveHistory>();
    }
}
