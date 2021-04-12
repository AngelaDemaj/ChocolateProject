using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class DiscountLevelService : IDiscountLevelService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public DiscountLevelService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiscountLevelViewModel> GetDiscountLevel(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var discountLevel = await _context
                .DiscountLevels
                .SingleOrDefaultAsync(d => d.Id == id);

            var viewModel = _mapper.Map<DiscountLevelViewModel>(discountLevel);

            if (discountLevel == null)
            {
                return null;
            }

            viewModel.Discounts = await _context.Discounts.ToListAsync();

            return viewModel;
        }

        public async Task<DiscountLevelViewModel> GetDiscountLevelWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var discountLevel = await _context.DiscountLevels
                .Include(d => d.Discount)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (discountLevel == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<DiscountLevelViewModel>(discountLevel);

            viewModel.DiscountPercentage = viewModel.DiscountPercentage * 100;
            viewModel.Discounts = await _context.Discounts.ToListAsync();

            return viewModel;
        }

        public async Task<DiscountLevelViewModel> GetDiscounts()
        {
            var viewModel = new DiscountLevelViewModel()
            {
                Discounts = await _context.Discounts.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreateDiscountLevel(DiscountLevelViewModel viewModel)
        {
            viewModel.DiscountPercentage = viewModel.DiscountPercentage / 100;
            var discountLevel = _mapper.Map<DiscountLevel>(viewModel);
            await _context.AddAsync(discountLevel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDiscountLevel(DiscountLevelViewModel viewModel)
        {
            viewModel.DiscountPercentage = viewModel.DiscountPercentage / 100;
            var discountLevel = _mapper.Map<DiscountLevel>(viewModel);
            _context.DiscountLevels.Update(discountLevel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiscountLevel(int? id)
        {
            var discountLevel = await _context.DiscountLevels.FindAsync(id);
            _context.DiscountLevels.Remove(discountLevel);
            await _context.SaveChangesAsync();
        }
    }
}