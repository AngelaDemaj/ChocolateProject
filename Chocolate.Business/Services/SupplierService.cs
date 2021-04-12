using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public SupplierService(
            ChocolateDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SupplierViewModel> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var supplier = await _context.Suppliers
                .SingleOrDefaultAsync(m => m.Id == id);

            if (supplier == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<SupplierViewModel>(supplier);

            viewModel.Phone = await _context.Phones
                .SingleOrDefaultAsync(p => p.SupplierId == id);

            viewModel.Email = await _context.Emails
                .SingleOrDefaultAsync(e => e.SupplierId == id);

            viewModel.Address = await _context.Addresses
                .SingleOrDefaultAsync(a => a.SupplierId == id);

            return viewModel;
        }

        public async Task CreateSupplier(SupplierViewModel viewModel)
        {
            var supplier = _mapper.Map<Supplier>(viewModel);
            _context.Add(supplier);
            await _context.SaveChangesAsync();

            await CreateSupplierEmail(viewModel, supplier.Id);
            await CreateSupplierPhone(viewModel, supplier.Id);
            await CreateSupplierAddress(viewModel, supplier.Id);
        }

        public async Task CreateSupplierAddress(SupplierViewModel viewModel, int supplierId)
        {
            var address = new Address
            {
                Location = viewModel.Address.Location,
                AddressNumber = viewModel.Address.AddressNumber,
                Country = viewModel.Address.Country,
                PostCode = viewModel.Address.PostCode,
                Comments = viewModel.Address.Comments,
                SupplierId = supplierId
            };
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task CreateSupplierPhone(SupplierViewModel viewModel, int supplierId)
        {
            var phone = new Phone
            {
                Number = viewModel.Phone.Number,
                PhoneType = viewModel.Phone.PhoneType,
                SupplierId = supplierId
            };
            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();
        }

        public async Task CreateSupplierEmail(SupplierViewModel viewModel, int supplierId)
        {
            var email = new Email
            {
                Mail = viewModel.Email.Mail,
                MailType = viewModel.Email.MailType,
                SupplierId = supplierId
            };
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
        }

        public async Task<SupplierViewModel> FindSupplier(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<SupplierViewModel>(supplier);
            viewModel.Phone = await _context
                .Phones
                .SingleOrDefaultAsync(p => p.SupplierId == supplier.Id);

            viewModel.Email = await _context
                .Emails
                .SingleOrDefaultAsync(e => e.SupplierId == supplier.Id);

            viewModel.Address = await _context
                .Addresses
                .SingleOrDefaultAsync(a => a.SupplierId == supplier.Id);

            return viewModel;
        }

        public async Task UpdateSupplier(SupplierViewModel viewModel)
        {
            var supplier = _mapper.Map<Supplier>(viewModel);
            _context.Update(supplier);
            await _context.SaveChangesAsync();

            await UpdateSupplierEmail(viewModel, supplier.Id);
            await UpdateSupplierPhone(viewModel, supplier.Id);
            await UpdateSupplierAddress(viewModel, supplier.Id);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAddress(SupplierViewModel viewModel, int supplierId)
        {
            var addressInDb = await _context.Addresses.SingleOrDefaultAsync(a => a.SupplierId == supplierId);
            if (addressInDb == null)
            {
                await CreateSupplierAddress(viewModel, supplierId);
            }
            else
            {
                addressInDb.Location = viewModel.Address.Location;
                addressInDb.AddressNumber = viewModel.Address.AddressNumber;
                addressInDb.Country = viewModel.Address.Country;
                addressInDb.PostCode = viewModel.Address.PostCode;
                addressInDb.Comments = viewModel.Address.Comments;
                _context.Addresses.Update(addressInDb);
            }
        }

        public async Task UpdateSupplierPhone(SupplierViewModel viewModel, int supplierId)
        {
            var phoneInDb = await _context.Phones.SingleOrDefaultAsync(p => p.SupplierId == supplierId);
            if (phoneInDb == null)
            {
                await CreateSupplierPhone(viewModel, supplierId);
            }
            else
            {
                phoneInDb.Number = viewModel.Phone.Number;
                phoneInDb.PhoneType = viewModel.Phone.PhoneType;
                _context.Phones.Update(phoneInDb);
            }
        }

        public async Task UpdateSupplierEmail(SupplierViewModel viewModel, int supplierId)
        {
            var emailInDb = await _context.Emails.SingleOrDefaultAsync(e => e.SupplierId == supplierId);
            if (emailInDb == null)
            {
                await CreateSupplierEmail(viewModel, supplierId);
            }
            else
            {
                emailInDb.Mail = viewModel.Email.Mail;
                emailInDb.MailType = viewModel.Email.MailType;
                _context.Emails.Update(emailInDb);
            }
        }

        public async Task DeleteSupplier(int? id)
        {
            var supplier = await _context.Suppliers.FirstAsync(s => s.Id == id);

            await DeleteSupplierPhone(id);
            await DeleteSupplierEmail(id);
            await DeleteSupplierAddress(id);

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAddress(int? id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.SupplierId == id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }
        }

        public async Task DeleteSupplierPhone(int? id)
        {
            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.SupplierId == id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }
        }

        public async Task DeleteSupplierEmail(int? id)
        {
            var email = await _context.Emails.SingleOrDefaultAsync(e => e.SupplierId == id);
            if (email != null)
            {
                _context.Emails.Remove(email);
            }
        }
    }
}