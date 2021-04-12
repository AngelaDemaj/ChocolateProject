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
    public class WarehouseService : IWarehouseService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public WarehouseService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region Get Methods
        public async Task<WarehouseViewModel> GetWarehouse(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var warehouse = await _context.Warehouses
                .SingleOrDefaultAsync(m => m.Id == id);

            if (warehouse == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<WarehouseViewModel>(warehouse);

            viewModel.Address = await _context.Addresses
                .SingleOrDefaultAsync(a => a.WarehouseId == id);

            viewModel.StorageUnits = await _context.StorageUnits
                .Where(s => s.WarehouseId == id)
                .ToListAsync();

            var warehouseStorageUnits = "";
            foreach (var storageUnit in viewModel.StorageUnits)
            {
                warehouseStorageUnits += $"{storageUnit.Id}, ";
            }
            viewModel.WarehouseStorageUnits = warehouseStorageUnits == "" ? "no storage units"
                : warehouseStorageUnits.Substring(0, warehouseStorageUnits.Length - 2);

            viewModel.Phone = await GetWarehousePhone(id);

            viewModel.Email = await GetWarehouseEmail(id);


            return viewModel;
        }
        public async Task<Phone> GetWarehousePhone(int? warehouseId)
        {
            var phone = await _context.Phones
                .SingleOrDefaultAsync(p => p.WarehouseId == warehouseId);

            return phone;
        }

        public async Task<Email> GetWarehouseEmail(int? warehouseId)
        {
            var email = await _context.Emails
                .SingleOrDefaultAsync(e => e.WarehouseId == warehouseId);
            return email;
        }
        #endregion

        #region Create Methods
        public async Task<Warehouse> CreateWarehouse(WarehouseViewModel viewModel)
        {
            var warehouse = _mapper.Map<Warehouse>(viewModel);
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();

            await CreateWarehouseAddress(viewModel, warehouse.Id);

            await CreateWarehouseStorageUnits(viewModel, warehouse.Id);

            await CreateWarehousePhone(viewModel, warehouse.Id);

            await CreateWarehouseEmail(viewModel, warehouse.Id);

            return warehouse;
        }

        public async Task CreateWarehouseAddress(WarehouseViewModel viewModel, int warehouseId)
        {
            var address = _mapper.Map<Address>(viewModel.Address);
            address.WarehouseId = warehouseId;
            await _context.Addresses.AddAsync(address);

            await _context.SaveChangesAsync();
        }
        public async Task CreateWarehouseStorageUnits(WarehouseViewModel viewModel, int warehouseId)
        {
            for (int i = 0; i < viewModel.NumberOfStorageUnits; i++)
            {
                await _context.StorageUnits
                     .AddAsync(new StorageUnit() { WarehouseId = warehouseId });
            }
            await _context.SaveChangesAsync();
        }

        public async Task CreateWarehousePhone(WarehouseViewModel viewModel, int warehouseId)
        {
            var phone = new Phone
            {
                WarehouseId = warehouseId,
                Number = viewModel.Phone.Number,
                PhoneType = viewModel.Phone.PhoneType
            };

            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();
        }

        public async Task CreateWarehouseEmail(WarehouseViewModel viewModel, int warehouseId)
        {
            var email = new Email
            {
                WarehouseId = warehouseId,
                Mail = viewModel.Email.Mail,
                MailType = viewModel.Email.MailType
            };

            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update Methods
        public async Task UpdateWarehouse(WarehouseViewModel viewModel, int id)
        {
            var warehouse = _mapper.Map<Warehouse>(viewModel);
            _context.Warehouses.Update(warehouse);

            await UpdateWarehouseAddress(viewModel, id);

            await UpdateWarehousePhone(viewModel, id);

            await UpdateWarehouseEmail(viewModel, id);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateWarehousePhone(WarehouseViewModel viewModel, int id)
        {
            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.WarehouseId == id);
            phone.Number = viewModel.Phone.Number;
            phone.PhoneType = viewModel.Phone.PhoneType;
            _context.Phones.Update(phone);
        }

        public async Task UpdateWarehouseEmail(WarehouseViewModel viewModel, int id)
        {
            var email = await _context.Emails.SingleOrDefaultAsync(e => e.WarehouseId == id);
            email.Mail = viewModel.Email.Mail;
            email.MailType = viewModel.Email.MailType;
            _context.Emails.Update(email);
        }

        public async Task UpdateWarehouseAddress(WarehouseViewModel viewModel, int id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.WarehouseId == id);
            address.Location = viewModel.Address.Location;
            address.AddressNumber = viewModel.Address.AddressNumber;
            address.Country = viewModel.Address.Country;
            address.Comments = viewModel.Address.Comments;
            address.PostCode = viewModel.Address.PostCode;
            _context.Addresses.Update(address);

        }
        #endregion

        #region Delete Methods
        public async Task DeleteWarehouse(int? id)
        {

            await DeleteWarehousePhone(id);
            await DeleteWarehouseEmail(id);
            await DeleteWarehouseAddress(id);
            var warehouse = await _context.Warehouses.FirstAsync(w => w.Id == id);

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWarehouseAddress(int? id)
        {
            var address = await _context
                .Addresses
                .SingleOrDefaultAsync(a => a.WarehouseId == id);
            _context.Addresses.Remove(address);
        }

        public async Task DeleteWarehousePhone(int? id)
        {
            var phone = await _context.Phones
                .SingleOrDefaultAsync(p => p.WarehouseId == id);
            _context.Phones.Remove(phone);
        }

        public async Task DeleteWarehouseEmail(int? id)
        {
            var email = await _context.Emails
                .SingleOrDefaultAsync(e => e.WarehouseId == id);
            _context.Emails.Remove(email);
        }
        #endregion
    }
}