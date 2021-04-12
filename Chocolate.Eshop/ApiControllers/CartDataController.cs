using Chocolate.Business.Helpers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chocolate.Eshop.ApiControllers
{
    [ApiController]
    [Route("api/carts")]
    public class CartDataController : ControllerBase
    {
        private readonly ChocolateDbContext _context;

        public CartDataController(ChocolateDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddProductSession(ItemViewModel viewModel)
        {
            viewModel.Product = _context.Products.Find(viewModel.ProductId);

            SessionHelper.Set(HttpContext.Session, viewModel.ProductId.ToString(), viewModel);

            return Ok();
        }
    }
}