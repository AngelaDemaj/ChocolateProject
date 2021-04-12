using Chocolate.DataAccess;
using Chocolate.DataAccess.ViewModels;
using ChocolateProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace ChocolateProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChocolateDbContext _context;

        public HomeController(ChocolateDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Departments = _context.Departments.Count(),
                Candidates = _context.Candidates.Count(),
                Customers = _context.Customers.Count(),
                Employees = _context.Employees.Count(),
                Orders = _context.Orders.Count(),
                Positions = _context.Positions.Count(),
                Products = _context.Products.Count(),
                Purchases = _context.Purchases.Count(),
                RawMaterials = _context.RawMaterials.Count(),
                StorageUnits = _context.StorageUnits.Count(),
                Suppliers = _context.Suppliers.Count(),
                Warehouses = _context.Warehouses.Count()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetAllMeetings(HomeViewModel viewModel)
        {
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}