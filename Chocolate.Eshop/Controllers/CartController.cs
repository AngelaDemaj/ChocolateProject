using Chocolate.Business.Helpers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.ViewModels;
using Chocolate.Payment.Models;
using Chocolate.Payment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Eshop.Controllers
{
    public class CartController : Controller
    {
        readonly ChocolateDbContext _context;
        readonly IConfiguration _configuration;

        public CartController(
            ChocolateDbContext context,
            IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var itemViewModels = HttpContext.Session.GetItems<ItemViewModel>().ToList();

            for (int i = 0; i < itemViewModels.Count(); i++)
            {
                itemViewModels[i].Product.Photos = await _context.Photos
                    .Where(p => p.ProductId == itemViewModels[i].Product.Id)
                    .ToListAsync();
            }
            
            return View(itemViewModels);
        }

        public async Task<IActionResult> Checkout(double total)
        {
            var payPalApi = new PayPalApiService(_configuration);
            var url = await payPalApi.GetRedirectUrlToPayPal(total, "EUR");
            return Redirect(url);
        }

        [Route("home/success")]
        public async Task<IActionResult> Success([FromQuery(Name = "paymentId")] string paymentId, [FromQuery(Name = "PayerId")] string payerId)
        {
            var payPalApi = new PayPalApiService(_configuration);
            PayPalPaymentExecutedResponse result = await payPalApi
                .ExecutedPayment(paymentId, payerId);

            return View("~/Views/Home/Success.cshtml");
        }
    }
}