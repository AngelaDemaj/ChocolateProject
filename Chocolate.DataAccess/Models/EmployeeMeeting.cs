using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.Models
{
    public class EmployeeMeeting
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
