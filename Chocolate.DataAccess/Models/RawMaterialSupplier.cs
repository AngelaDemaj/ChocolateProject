namespace Chocolate.DataAccess.Models
{
    public class RawMaterialSupplier
    {
        public int RawMaterialId { get; set; }
        public int SupplierId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public Supplier Supplier { get; set; }
    }
}
