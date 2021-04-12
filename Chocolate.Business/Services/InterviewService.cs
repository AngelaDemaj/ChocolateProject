using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public InterviewService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewViewModel> GetInterview(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Interview interview = await _context.Interviews.FindAsync(id);

            if (interview == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<InterviewViewModel>(interview);

            return viewModel;
        }

        public async Task<InterviewViewModel> GetInterviewWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var interview = await _context.Interviews
                .Include(i => i.Candidate)
                .Include(i => i.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (interview == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<InterviewViewModel>(interview);
            viewModel.Candidates = await _context.Candidates.ToListAsync();
            viewModel.Employees = await _context.Employees.ToListAsync();

            return viewModel;
        }

        public async Task CreateInterview(InterviewViewModel viewModel)
        {
            var interview = _mapper.Map<Interview>(viewModel);
            _context.Add(interview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInterview(InterviewViewModel viewModel)
        {
            var interview = _mapper.Map<Interview>(viewModel);
            _context.Update(interview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInterview(int? id)
        {
            var interview = await _context.Interviews.FindAsync(id);
            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();
        }

        public async Task<InterviewViewModel> CreateViewModel()
        {
            return new InterviewViewModel
            {
                Candidates = await _context.Candidates.ToListAsync(),
                Employees = await _context.Employees.ToListAsync()
            };
        }
    }
}