using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class InterviewViewModel : Entity
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        public DateTime DateOfInterview { get; set; }
        [Range(0, 5, ErrorMessage = "Ratings range from 1 to 5 or 0 if the interview has not taken place yet.")]
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
    }
}
