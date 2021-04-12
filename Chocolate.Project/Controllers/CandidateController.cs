using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ChocolateProject.Controllers
{
    [Authorize(Roles = "Admin, HR")]
    public class CandidateController : BaseController
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _service.GetCandidate(id);


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
        public async Task<IActionResult> Create(CandidateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {
                    var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    viewModel.CV = memoryStream.ToArray();
                    viewModel.FileName = file.FileName;
                }

                var candidate = await _service.CreateCandidate(viewModel);

                await _service.CreateCandidateInfo(viewModel, candidate.Id);

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

            var viewModel = await _service.GetCandidate(id);


            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CandidateViewModel viewModel)
        {
            if(id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateCandidate(viewModel, id);

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

            var viewModel = await _service.GetCandidate(id);


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
            await _service.DeleteCandidate(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<FileContentResult> Download(int id)
        {
            var file = await _service.GetFile(id);
            return File(file.FileStream, "application/force-download", file.FileName);
        }

    }
}