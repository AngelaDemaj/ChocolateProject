using System.Collections.Generic;

namespace Chocolate.DataAccess.ViewModels
{
    public class CartViewModel
    {
        public ICollection<ItemViewModel> Items { get; set; }
    }
}