namespace Chocolate.DataAccess.Models
{
    public class RawMaterialProduct
    {
        public int RawMaterialId { get; set; }
        public int ProductId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public Product Product { get; set; }
    }
}
