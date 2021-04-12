using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class OfferService : IOfferService
    {
        private readonly IMapper _mapper;
        private readonly ChocolateDbContext _context;

        public OfferService(IMapper mapper, ChocolateDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OfferViewModel> GetOffer(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var offer = await _context.Offers.FindAsync(id);

            if (offer == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OfferViewModel>(offer);

            viewModel.Suppliers = await _context.Suppliers.ToListAsync();
            viewModel.Employees = await _context.Employees.ToListAsync();
            viewModel.DiscountLevels = await _context.DiscountLevels.ToListAsync();

            return viewModel;
        }

        public async Task<OfferViewModel> GetOfferWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var offer = await _context.Offers
                .Include(o => o.DiscountLevel)
                .Include(o => o.Employee)
                .Include(o => o.Supplier)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (offer == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OfferViewModel>(offer);

            viewModel.FullName = viewModel.Employee.FullName;

            return viewModel;
        }

        public async Task<OfferViewModel> GetRelatedEntities()
        {
            var viewModel = new OfferViewModel()
            {
                Employees = await _context.Employees.ToListAsync(),
                Suppliers = await _context.Suppliers.ToListAsync(),
                DiscountLevels = await _context.DiscountLevels.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreateOffer(OfferViewModel viewModel)
        {
            var offer = _mapper.Map<Offer>(viewModel);
            _context.Add(offer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOffer(OfferViewModel viewModel)
        {
            var offer = _mapper.Map<Offer>(viewModel);
            _context.Update(offer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOffer(int? id)
        {
            var offer = await _context.Offers.FindAsync(id);
            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();
        }
    }
}