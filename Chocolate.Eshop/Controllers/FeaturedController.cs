using Chocolate.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chocolate.Eshop.Controllers
{
    public class FeaturedController : Controller
    {
        private readonly IProductService _service;

        public FeaturedController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProductsWithIncludes(4, 1));
        }
    }
}