using System;

namespace Chocolate.DataAccess.Models
{
    public class LeaveHistory : Entity
    {
        public int LeaveId { get; set; }
        public Leave Leave { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string Comments { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? EmployeeId { get; set; }
    }
}
