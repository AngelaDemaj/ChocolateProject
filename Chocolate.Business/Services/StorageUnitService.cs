using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Chocolate.Business.Services
{
    public class StorageUnitService : IStorageUnitService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public StorageUnitService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageUnitViewModel> GetStorageUnit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var storageUnit = await _context.StorageUnits.FindAsync(id);

            if (storageUnit == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<StorageUnitViewModel>(storageUnit);

            viewModel.Warehouses = await _context.Warehouses.ToListAsync();

            return viewModel;
        }

        public async Task<StorageUnitViewModel> GetStorageUnitWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var storageUnit = await _context.StorageUnits
                .Include(s => s.Warehouse)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (storageUnit == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<StorageUnitViewModel>(storageUnit);

            viewModel.Sectors = await _context.Sectors
                .Where(s => s.StorageUnitId == id)
                .ToListAsync();

            GetStorageUnitSectors(viewModel);

            await FillWarehouseAddress(viewModel, storageUnit.Id);

            return viewModel;
        }

        public void GetStorageUnitSectors(StorageUnitViewModel viewModel)
        {
            var storageUnitSectors = "";
            foreach (var sector in viewModel.Sectors)
            {
                storageUnitSectors += $"{sector.Id}, ";
            }
            viewModel.StorageUnitSectors = storageUnitSectors == "" ? "no sectors"
                : storageUnitSectors.Substring(0, storageUnitSectors.Length - 2);
        }

        public async Task<StorageUnitViewModel> GetRelatedEntities()
        {
            var viewModel = new StorageUnitViewModel()
            {
                Warehouses = await _context.Warehouses.ToListAsync(),
                Sectors = await _context.Sectors.ToListAsync()
            };

            return viewModel;
        }

        public async Task<StorageUnit> CreateStorageUnit(StorageUnitViewModel viewModel)
        {
            var storageUnit = _mapper.Map<StorageUnit>(viewModel);
            _context.StorageUnits.Add(storageUnit);

            await _context.SaveChangesAsync();

            return storageUnit;
        }

        public async Task UpdateStorageUnit(int id, StorageUnitViewModel viewModel)
        {
            var storageUnit = _mapper.Map<StorageUnit>(viewModel);
            storageUnit.Id = id;
            _context.StorageUnits.Update(storageUnit);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStorageUnit(int? id)
        {
            var storageUnit = await _context.StorageUnits.FindAsync(id);
            _context.StorageUnits.Remove(storageUnit);

            await _context.SaveChangesAsync();
        }

        public async Task CreateStorageUnitSector(StorageUnitViewModel viewModel, int storageUnitId)
        {
            for (int i = 0; i < viewModel.NumberOfSectors; i++)
            {
                await _context.Sectors
                    .AddAsync(new Sector() { StorageUnitId = storageUnitId });
            }
                await _context.SaveChangesAsync();
        }
        public async Task FillWarehouseAddress(StorageUnitViewModel viewModel,int? storageUnitId)
        {
            var storageUnit = await _context.StorageUnits.FindAsync(storageUnitId);
            var address = await _context.Addresses
                .SingleOrDefaultAsync(a => a.WarehouseId == storageUnit.WarehouseId);

            viewModel.WarehouseAddress
                .Add(storageUnit.WarehouseId, address.Location);
        }

        public async Task FillWarehouseAddresses(StorageUnitViewModel viewModel)
        {
            var address = new Address();
            foreach (var warehouse in viewModel.Warehouses)
            {
                address = await _context.Addresses
                    .SingleOrDefaultAsync(a => a.WarehouseId == warehouse.Id);

                viewModel.WarehouseAddress.Add(warehouse.Id, address.Location);
            }
        }
    }
}