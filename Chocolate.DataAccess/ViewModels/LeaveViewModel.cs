using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class LeaveViewModel
    {
        public int Id { get; set; }
        public LeaveType LeaveType { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public bool Approve { get; set; }
        public ICollection<LeaveHistory> LeaveHistories { get; set; }
            = new HashSet<LeaveHistory>();
    }
}
