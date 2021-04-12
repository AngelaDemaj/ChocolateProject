using System.Collections.Generic;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class Position : NamedEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string Degree { get; set; }
        public string WorkExperience { get; set; }
        public string Languages { get; set; }
        public string Qualifications { get; set; }
        public ICollection<CandidatePosition> CandidatePositions { get; set; } =
            new HashSet<CandidatePosition>();
    }
}
