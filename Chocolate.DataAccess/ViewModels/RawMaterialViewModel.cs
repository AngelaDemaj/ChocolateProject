using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class RawMaterialViewModel : Entity
    {
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage =("Please enter a Price above 0"))]
        [Required(ErrorMessage ="Please enter a Price")]
        public double Price { get; set; }
    }
}
