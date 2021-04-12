using Chocolate.DataAccess.Models.AbstractEntities;

namespace Chocolate.DataAccess.Models
{
    public class Photo : NamedEntity
    {
        public byte[] ImageData { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
