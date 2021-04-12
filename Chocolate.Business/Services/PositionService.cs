using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    class PositionService : IPositionService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public PositionService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PositionViewModel> GetPosition(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var position = await _context.Set<Position>()
                .FindAsync(id);

            if (position == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<PositionViewModel>(position);

            viewModel.Departments = await _context.Departments
                .ToListAsync();

            return viewModel;
        }

        public async Task<PositionViewModel> GetPositionWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var position = await _context.Positions
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (position == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<PositionViewModel>(position);

            return viewModel;
        }

        public async Task<PositionViewModel> GetPositionWithIncludesEshop(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var position = await _context.Positions
                .Where(p => p.IsActive == true)
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (position == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<PositionViewModel>(position);

            return viewModel;
        }

        public async Task<PositionViewModel> GetRelatedEntities()
        {
            var viewModel = new PositionViewModel
            {
                Departments = await _context.Departments.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreatePosition(PositionViewModel viewModel)
        {
            var position = _mapper.Map<Position>(viewModel);

            await _context.AddAsync(position);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePosition(PositionViewModel viewModel)
        {
            var position = _mapper.Map<Position>(viewModel);

            _context.Update(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePosition(int? id)
        {
            var position = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        }
    }
}