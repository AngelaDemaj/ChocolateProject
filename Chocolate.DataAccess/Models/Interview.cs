using System;

namespace Chocolate.DataAccess.Models
{
    public class Interview : Entity
    {
        public DateTime DateOfInterview { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
