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
    public class ShelfService : IShelfService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public ShelfService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Get Methods

        public async Task<ShelfViewModel> GetShelf(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var shelf = await _context.Shelves.FindAsync(id);

            if (shelf == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<ShelfViewModel>(shelf);

            viewModel.Sectors = await _context.Sectors
                .ToListAsync();

            viewModel.ProductShelves = await _context.ProductShelves
                .Include(ps => ps.Product)
                .Where(ps => ps.ShelfId == id)
                .ToListAsync();

            viewModel.Products = await _context.Products
                .ToListAsync();

            viewModel.RawMaterials = await _context.RawMaterials
                .ToListAsync();

            viewModel.RawMaterialShelves = await _context.RawMaterialShelves
                .Include(rms => rms.RawMaterial)
                .Where(rms => rms.ShelfId == id)
                .ToListAsync();

            return viewModel;
        }

        public async Task<ShelfViewModel> GetShelfWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var shelf = await _context.Shelves
                .Include(s => s.Sector)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (shelf == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<ShelfViewModel>(shelf);

            return viewModel;
        }

        public async Task<ShelfViewModel> GetRelatedEntities()
        {
            var viewModel = new ShelfViewModel()
            {
                Sectors = await _context.Sectors.ToListAsync()
            };

            return viewModel;
        }

        #endregion Get Methods

        #region Create Methods

        public async Task CreateShelf(ShelfViewModel viewModel)
        {
            var shelf = _mapper.Map<Shelf>(viewModel);
            _context.Shelves.Add(shelf);
            await _context.SaveChangesAsync();
        }

        #endregion Create Methods

        #region Update Methods

        public async Task UpdateShelf(int id, ShelfViewModel viewModel)
        {
            var shelf = _mapper.Map<Shelf>(viewModel);
            _context.Shelves.Update(shelf);
            await _context.SaveChangesAsync();
        }

        #endregion Update Methods

        #region Delete Methods

        public async Task DeleteShelf(int? id)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            _context.Shelves.Remove(shelf);
            await _context.SaveChangesAsync();
        }

        #endregion Delete Methods
    }
}