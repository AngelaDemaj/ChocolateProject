using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.ViewModels
{
    public class DepartmentViewModel : Entity
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
