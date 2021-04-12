using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ChocolateProject.Controllers
{
    //authorize annotation allows certain roles to access this controller
    [Authorize(Roles = "Admin, HR, DepartmentHead")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        //Dependency Injection --> resolved with AutoFac
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _service.GetDetails(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = await _service.CreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = await _service.CreateEmployee(viewModel);

                await _service.CreateEmployeeInfo(viewModel, employee.Id);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _service.GetDetails(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateEmployee(viewModel, id);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _service.GetDetails(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }

    }
}