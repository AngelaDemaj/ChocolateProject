using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class ContactMessageViewModel
    {
        [Required(ErrorMessage ="Please enter your contact info")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter a Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage ="Please enter a Description of your problem")]
        public string Description { get; set; }
    }
}
