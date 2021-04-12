using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class SectorService : ISectorService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public SectorService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region Get Methods
        public async Task<SectorViewModel> GetSector(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var sector = await _context.Sectors.FindAsync(id);

            if (sector == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<SectorViewModel>(sector);
            viewModel.StorageUnits = await _context.StorageUnits
                .ToListAsync();

            return viewModel;
        }

        public async Task<SectorViewModel> GetSectorWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var sector = await _context.Sectors
                .Include(s => s.StorageUnit)
                .Include(sh => sh.Shelves)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (sector == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<SectorViewModel>(sector);

            viewModel.StorageUnits = await _context.StorageUnits
                .ToListAsync();

            var sectorShelves = "";
            foreach (var shelf in viewModel.Shelves)
            {
                sectorShelves += $"{shelf.Id}, ";
            }
            viewModel.SectorShelves = sectorShelves == "" ? "no shelves"
                : sectorShelves.Substring(0, sectorShelves.Length - 2);

            return viewModel;
        }

        public async Task<SectorViewModel> GetRelatedEntities()
        {
            var viewModel = new SectorViewModel()
            {
                StorageUnits = await _context.StorageUnits.ToListAsync()
            };

            return viewModel;
        }
        #endregion

        #region Create Methods
        public async Task<Sector> CreateSector(SectorViewModel viewModel)
        {
            var sector = _mapper.Map<Sector>(viewModel);
            await _context.Sectors.AddAsync(sector);
            await _context.SaveChangesAsync();

            return sector;
        }

        public async Task CreateSectorShelves(SectorViewModel viewModel, int sectorId)
        {
            for (int i = 0; i < viewModel.NumberOfShelves; i++)
            {
                await _context.Shelves
                    .AddAsync(new Shelf() { SectorId = sectorId });
            }
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update Methods
        public async Task UpdateSector(int id, SectorViewModel viewModel)
        {
            var sector = _mapper.Map<Sector>(viewModel);
            _context.Sectors.Update(sector);
            _context.Update(sector);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete Methods
        public async Task DeleteSector(int? id)
        {
            var sector = await _context.Sectors.FindAsync(id);
            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}