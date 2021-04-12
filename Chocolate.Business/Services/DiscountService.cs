using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public DiscountService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DiscountViewModel> GetDiscount(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var discount = await _context.Discounts.FindAsync(id);

            if (discount == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<DiscountViewModel>(discount);

            return viewModel;
        }

        public async Task<DiscountViewModel> GetDiscountWithIncludes(int? id)
        {
            var discount = await _context.Discounts
                .Include(d => d.Supplier)
                .SingleOrDefaultAsync(m => m.Id == id);

            var viewModel = _mapper.Map<DiscountViewModel>(discount);

            viewModel.Suppliers = await _context.Suppliers.ToListAsync();

            return viewModel;
        }

        public async Task<DiscountViewModel> GetRelatedEntities()
        {
            var viewModel = new DiscountViewModel
            {
                Suppliers = await _context.Suppliers.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreateDiscount(DiscountViewModel viewModel)
        {
            var discount = _mapper.Map<Discount>(viewModel);
            _context.Add(discount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDiscount(DiscountViewModel viewModel)
        {
            var discount = _mapper.Map<Discount>(viewModel);
            _context.Update(discount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiscount(int? id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
        }
    }
}