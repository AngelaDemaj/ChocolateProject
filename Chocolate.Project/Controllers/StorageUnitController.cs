using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChocolateProject.Controllers
{
    [Authorize(Roles = "Admin, Warehouse")]
    public class StorageUnitController : BaseController
    {
        private readonly IStorageUnitService _service;

        public StorageUnitController(IStorageUnitService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetStorageUnitWithIncludes(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = await _service.GetRelatedEntities();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StorageUnitViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var storageUnit = await _service.CreateStorageUnit(viewModel);

                await _service.CreateStorageUnitSector(viewModel, storageUnit.Id);
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

            var viewModel = await _service.GetStorageUnit(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            await _service.FillWarehouseAddresses(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StorageUnitViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateStorageUnit(id, viewModel);

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

            var viewModel = await _service.GetStorageUnitWithIncludes(id);

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
            await _service.DeleteStorageUnit(id);

            return RedirectToAction(nameof(Index));
        }
    }
}