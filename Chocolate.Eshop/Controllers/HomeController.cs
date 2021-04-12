using Chocolate.Business.Services.Interfaces;
using Chocolate.Eshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chocolate.Eshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProductsWithIncludes(4, 1));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ReturnPolicy()
        {
            return View();
        }

        public IActionResult TermsAndConditions()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShippingGuide()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Stores()
        {
            return View();
        }

        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult Success(string paymentId, string token, string payerId)
        {
            return View();
        }

        public IActionResult Failure(string paymentId, string token, string payerId)
        {
            return View();
        }
    }
}