using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Chocolate.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerViewModel> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var viewModel = await FindCustomerWithInclusions(id);

            if (viewModel == null)
            {
                return null;
            }

            viewModel.Address = await _context.Addresses.FirstOrDefaultAsync(c => c.CustomerId == id);
            viewModel.Phone = await _context.Phones.FirstOrDefaultAsync(c => c.CustomerId == id);
            viewModel.Mail = await _context.Emails.FirstOrDefaultAsync(c => c.CustomerId == id);

            return viewModel;
        }

        public async Task<CustomerViewModel> GetAccountDetails(ClaimsPrincipal user)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserId == user.FindFirstValue(ClaimTypes.NameIdentifier));

            var viewModel = await FindCustomerWithInclusions(customer.Id);

            if (viewModel == null)
            {
                return null;
            }

            viewModel.Address = await _context.Addresses.FirstOrDefaultAsync(c => c.CustomerId == customer.Id);
            viewModel.Phone = await _context.Phones.FirstOrDefaultAsync(c => c.CustomerId == customer.Id);
            viewModel.Mail = await _context.Emails.FirstOrDefaultAsync(c => c.CustomerId == customer.Id);

            return viewModel;
        }

        public async Task CreateCustomerInfo(CustomerViewModel viewModel, int id)
        {
            var address = _mapper.Map<Address>(viewModel.Address);
            address.CustomerId = id;
            await _context.Addresses.AddAsync(address);

            var phone = _mapper.Map<Phone>(viewModel.Phone);
            phone.CustomerId = id;
            await _context.Phones.AddAsync(phone);

            var email = _mapper.Map<Email>(viewModel.Email);
            email.CustomerId = id;
            await _context.Emails.AddAsync(email);

            await _context.SaveChangesAsync();
        }

        public async Task<CustomerViewModel> FindCustomerWithInclusions(int? id)
        {
            var customer = await _context.Customers
                .Include(c => c.Addresses)
                .Include(c => c.Phones)
                .Include(c => c.Emails)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<CustomerViewModel>(customer);

            return viewModel;
        }

        public async Task<Customer> CreateCustomer(CustomerViewModel viewModel)
        {
            var customer = _mapper.Map<Customer>(viewModel);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task UpdateCustomer(CustomerViewModel viewModel, int id)
        {
            var customer = _mapper.Map<Customer>(viewModel);
            _context.Customers.Update(customer);

            var address = await _context.Addresses.FirstAsync(a => a.CustomerId == id);
            address.Location = viewModel.Address.Location;
            address.AddressNumber = viewModel.Address.AddressNumber;
            address.Country = viewModel.Address.Country;
            address.Comments = viewModel.Address.Comments;
            address.PostCode = viewModel.Address.PostCode;
            _context.Addresses.Update(address);

            var phone = await _context.Phones.FirstAsync(p => p.CustomerId == id);
            phone.Number = viewModel.Phone.Number;
            phone.PhoneType = viewModel.Phone.PhoneType;
            _context.Phones.Update(phone);

            var email = await _context.Emails.FirstAsync(e => e.CustomerId == id);
            email.Mail = viewModel.Mail.Mail;
            email.MailType = viewModel.Mail.MailType;
            _context.Emails.Update(email);


            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccount(CustomerViewModel viewModel, ClaimsPrincipal user)
        {
            var customer = await _context.Customers.FirstAsync(c => c.UserId == user.FindFirstValue(ClaimTypes.NameIdentifier));
            customer.FirstName = viewModel.FirstName;
            customer.LastName = viewModel.LastName;

            //var customer = _mapper.Map<Customer>(viewModel);
            _context.Customers.Update(customer);

            var phone = await _context.Phones.FirstAsync(p => p.CustomerId == customer.Id);
            phone.Number = viewModel.Phone.Number;
            _context.Phones.Update(phone);

            var address = await _context.Addresses.FirstAsync(a => a.CustomerId == customer.Id);
            address.Location = viewModel.Address.Location;
            address.AddressNumber = viewModel.Address.AddressNumber;
            address.Country = viewModel.Address.Country;
            address.Comments = viewModel.Address.Comments;
            address.PostCode = viewModel.Address.PostCode;
            _context.Addresses.Update(address);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.CustomerId == id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }
            var email = await _context.Emails.SingleOrDefaultAsync(e => e.CustomerId == id);
            if (email != null)
            {
                _context.Emails.Remove(email);
            }
            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.CustomerId == id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }

            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}