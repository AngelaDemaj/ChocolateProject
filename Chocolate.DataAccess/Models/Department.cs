using System.Collections.Generic;
using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class Department : NamedEntity
    {
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
