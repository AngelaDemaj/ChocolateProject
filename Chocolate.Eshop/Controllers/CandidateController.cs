using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Eshop.Controllers
{
    public class CandidateController : Controller
    {
        protected readonly ChocolateDbContext _context;
        protected readonly ICandidateService _service;

        public CandidateController(ChocolateDbContext context, ICandidateService service)
        {
            _context = context;
            _service = service;
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

                TempData["Candidate"] = "Thank you for applying!";

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
    }
}
