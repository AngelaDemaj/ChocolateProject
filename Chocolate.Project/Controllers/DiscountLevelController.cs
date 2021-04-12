using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ChocolateProject.Controllers
{
    [Authorize(Roles = "Admin,Accounting")]
    public class DiscountLevelController : BaseController
    {
        private readonly IDiscountLevelService _service;

        public DiscountLevelController(IDiscountLevelService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetDiscountLevelWithIncludes(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel =await _service.GetDiscounts();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiscountLevelViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateDiscountLevel(viewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetDiscountLevelWithIncludes(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DiscountLevelViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateDiscountLevel(viewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetDiscountLevelWithIncludes(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteDiscountLevel(id);

            return RedirectToAction(nameof(Index));
        }
    }
}