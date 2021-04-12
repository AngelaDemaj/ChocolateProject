namespace Chocolate.DataAccess.Models
{
    public class ProductShelf
    {
        public int Quantity { get; set; }
        public int ShelfId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Shelf Shelf { get; set; }
    }
}