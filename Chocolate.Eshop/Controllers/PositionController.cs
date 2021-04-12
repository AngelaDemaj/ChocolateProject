using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Eshop.Controllers
{
    public class PositionController : Controller
    {
        protected readonly ChocolateDbContext _context;
        protected readonly IPositionService _service;
        
        public PositionController(ChocolateDbContext context, IPositionService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetPositionWithIncludesEshop(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
