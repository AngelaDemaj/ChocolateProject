using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChocolateProject.Controllers
{
    [Authorize(Roles = "Admin,Warehouse")]
    public class RawMaterialController : BaseController
    {
        private readonly IRawMaterialService _service;

        public RawMaterialController(IRawMaterialService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetRawMaterial(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new RawMaterialViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RawMaterialViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateRawMaterial(viewModel);

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

            var viewModel = await _service.GetRawMaterial(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RawMaterialViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateRawMaterial(id, viewModel);

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

            var viewModel = await _service.GetRawMaterial(id);

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
            await _service.DeleteRawMaterial(id);

            return RedirectToAction(nameof(Index));
        }

    }
}