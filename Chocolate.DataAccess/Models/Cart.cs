using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Cart : Entity
    {
        public List<Product> Products { get; set; }
    }
}