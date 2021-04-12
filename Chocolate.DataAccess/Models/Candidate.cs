using System;
using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Candidate : Person
    {
        public DateTime DateOfBirth { get; set; }
        public bool IsBlacklisted { get; set; }
        public byte[] CV { get; set; }
        public string FileName { get; set; }
        public ICollection<CandidatePosition> CandidatePositions { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
