namespace Chocolate.DataAccess.Models
{
    public class RawMaterialShelf
    {
        public int Quantity { get; set; }
        public int ShelfId { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public Shelf Shelf { get; set; }
    }
}
