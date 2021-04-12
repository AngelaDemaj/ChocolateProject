using System.Collections.Generic;

namespace Chocolate.DataAccess.Models
{
    public class Customer : Person
    {
        public string UserId { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
