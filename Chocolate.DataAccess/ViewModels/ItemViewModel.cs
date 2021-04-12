using Chocolate.DataAccess.Models;

namespace Chocolate.DataAccess.ViewModels
{
    public class ItemViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}