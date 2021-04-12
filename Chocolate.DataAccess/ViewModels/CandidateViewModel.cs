using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class CandidateViewModel : Entity
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsBlacklisted { get; set; }
        public byte[] CV { get; set; }
        public string FileName { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        [Required(ErrorMessage ="You must submit your Phone Info.")]
        public Phone Phone { get; set; }
        [Required(ErrorMessage = "You must submit your Email Address.")]
        public Email Email { get; set; }
        public Address Address { get; set; }
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public ICollection<Position> Positions { get; set; } = new HashSet<Position>();
    }
}
