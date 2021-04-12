using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Chocolate.DataAccess.ViewModels;
using System.IO;

namespace ChocolateProject.Controllers
{
    
    public class LeaveController : BaseController
    {
        private readonly ILeaveService _service;

        public LeaveController(ILeaveService service)
        {
            _service = service;
        }

        
        public IActionResult MyLeaves()
        {
            return View();
        }

        [Authorize(Roles = "DepartmentHead")]
        public IActionResult MyApprovals()
        {
            return View();
        }

        [Authorize(Roles = "DepartmentHead")]
        public async Task<IActionResult> Approve(int id)
        {
            await _service.ApproveLeave(id, User);
            return View(nameof(MyApprovals));
        }

        [Authorize(Roles = "DepartmentHead")]
        public async Task<IActionResult> Reject(int id)
        {
            await _service.RejectLeave(id, User);
            return View(nameof(MyApprovals));
        }

        public async Task<IActionResult> Details(int? id, bool approve = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveViewModel = await _service.GetLeaveWithIncludes(id);
            leaveViewModel.Approve = approve;

            if (leaveViewModel == null)
            {
                return NotFound();
            }

            return View(leaveViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateLeave(viewModel, User, Request);

                return RedirectToAction(nameof(MyLeaves));
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Leave leave)
        {
            if (id != leave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateLeave(leave);

                return RedirectToAction(nameof(MyLeaves));
            }

            return View(leave);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteLeave(id);

            return RedirectToAction(nameof(MyLeaves));
        }

        public async Task<FileContentResult> Download(int id)
        {
            var file = await _service.GetFile(id);
            return File(file.FileStream, "application/force-download", file.FileName);
        }
    }
}