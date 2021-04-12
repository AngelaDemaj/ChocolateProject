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
    public class OfferItemService : IOfferItemService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public OfferItemService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OfferItemViewModel> GetOfferItem(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var offerItem = await _context.OfferItems.FindAsync(id);

            if (offerItem == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OfferItemViewModel>(offerItem);

            viewModel.Offers = await _context.Offers.ToListAsync();
            viewModel.RawMaterials = await _context.RawMaterials.ToListAsync();

            return viewModel;
        }

        public async Task<OfferItemViewModel> GetOfferItemWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var offerItem = await _context.OfferItems
                .Include(o => o.Offer)
                .Include(o => o.RawMaterial)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (offerItem == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OfferItemViewModel>(offerItem);

            return viewModel;
        }

        public async Task<OfferItemViewModel> GetRelatedEntities()
        {
            var viewModel = new OfferItemViewModel()
            {
                Offers = await _context.Offers.ToListAsync(),
                RawMaterials = await _context.RawMaterials.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreateOfferItem(OfferItemViewModel viewModel)
        {
            var offerItem = _mapper.Map<OfferItem>(viewModel);
            _context.Add(offerItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOfferItem(OfferItemViewModel viewModel)
        {
            var offerItem = _mapper.Map<OfferItem>(viewModel);
            _context.Update(offerItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOfferItem(int? id)
        {
            var offerItem = await _context.OfferItems.FindAsync(id);
            _context.OfferItems.Remove(offerItem);
            await _context.SaveChangesAsync();
        }
    }
}