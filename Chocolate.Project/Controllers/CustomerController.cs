using Chocolate.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ChocolateProject.Controllers
{
    [Authorize(Roles = "Admin,Accounting")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetDetails(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CustomerViewModel();
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = await _service.CreateCustomer(viewModel);

                await _service.CreateCustomerInfo(viewModel, customer.Id);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetDetails(id);

            if(viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateCustomer(viewModel, id);

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

            var viewModel = await _service.GetDetails(id);

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
            await _service.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}