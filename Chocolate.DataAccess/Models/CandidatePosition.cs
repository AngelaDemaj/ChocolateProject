using Chocolate.DataAccess.Models.Enums;

namespace Chocolate.DataAccess.Models
{
    public class CandidatePosition
    {
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public RecruitStatus RecruitStatus { get; set; }
    }
}
