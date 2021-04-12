using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public PurchaseService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseViewModel> GetPurchase(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<PurchaseViewModel>(purchase);

            viewModel.Offers = await _context.Offers.ToListAsync();

            return viewModel;
        }

        public async Task<PurchaseViewModel> GetPurchaseWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var purchase = await _context.Purchases
                .Include(p => p.Offer)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (purchase == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<PurchaseViewModel>(purchase);

            viewModel.Offers = await _context.Offers.ToListAsync();

            return viewModel;
        }

        public async Task<PurchaseViewModel> GetRelatedEntities()
        {
            var viewModel = new PurchaseViewModel()
            {
                Offers = await _context.Offers.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreatePurchase(PurchaseViewModel viewModel)
        {
            var purchase = _mapper.Map<Purchase>(viewModel);
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchase(PurchaseViewModel viewModel)
        {
            var purchase = _mapper.Map<Purchase>(viewModel);

            _context.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchase(int? id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();
        }
    }
}