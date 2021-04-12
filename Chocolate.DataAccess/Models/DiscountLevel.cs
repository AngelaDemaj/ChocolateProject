namespace Chocolate.DataAccess.Models
{
    public class DiscountLevel : Entity
    {
        public double Amount { get; set; }
        public double DiscountPercentage { get; set; }
        public Discount Discount { get; set; }
        public int DiscountId { get; set; }
    }
}
