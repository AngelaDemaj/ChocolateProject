using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class PositionViewModel : Entity
    {
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Job Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Degrees for the Position are required.")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "Work Experience expectations are required.")]
        public string WorkExperience { get; set; }
        [Required(ErrorMessage = "Degrees for the Position are required")]
        public string Languages { get; set; }
        public string Qualifications { get; set; }
        public Department Department { get; set; }

        public ICollection<CandidatePosition> CandidatePositions { get; set; } =
            new HashSet<CandidatePosition>();
        public ICollection<Department> Departments { get; set; } =
           new HashSet<Department>();
    }
}
