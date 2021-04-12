using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeService(ChocolateDbContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<EmployeeViewModel> GetDetails(int? id)
        {
            var viewModel = await FindEmployeeWithInclusions(id);

            if (viewModel == null)
            {
                return null;
            }

            viewModel.IdentityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == viewModel.UserId);
            viewModel.Departments = await _context.Departments.ToListAsync();
            viewModel.Address = await _context.Addresses.FirstOrDefaultAsync(c => c.EmployeeId == id);
            viewModel.Phone = await _context.Phones.FirstOrDefaultAsync(c => c.EmployeeId == id);
            viewModel.Mail = await _context.Emails.FirstOrDefaultAsync(c => c.EmployeeId == id);
            viewModel.Email = viewModel.Mail?.Mail;
            viewModel.PhoneNumber = viewModel.Phone?.Number;
            viewModel.Location = viewModel.Address?.Location;
            viewModel.AddressNumber = viewModel.Address != null ? viewModel.Address.AddressNumber : 0;
            viewModel.Country = viewModel.Address?.Country;
            viewModel.PostCode = viewModel.Address != null ? viewModel.Address.PostCode : 0;
            viewModel.Comments = viewModel.Address?.Comments;

            return viewModel;
        }

        public async Task<Employee> CreateEmployee(EmployeeViewModel viewModel)
        {
            var user = new IdentityUser
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email
            };

            await _userManager.CreateAsync(user, viewModel.Password);

            var employee = _mapper.Map<Employee>(viewModel);
            employee.UserId = user.Id;
            _context.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<EmployeeViewModel> FindEmployeeWithInclusions(int? id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Addresses)
                .Include(e => e.Phones)
                .Include(e => e.Emails)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<EmployeeViewModel>(employee);

            return viewModel;
        }

        public async Task CreateEmployeeInfo(EmployeeViewModel viewModel, int id)
        {
            var address = new Address()
            {
                EmployeeId = id,
                Location = viewModel.Location,
                AddressNumber = (Int16)viewModel.AddressNumber,
                PostCode = (Int16)viewModel.PostCode,
                Country = viewModel.Country,
                Comments = viewModel.Comments
            };
            _context.Addresses.Add(address);

            var phone = new Phone
            {
                EmployeeId = id,
                Number = viewModel.PhoneNumber,
                PhoneType = viewModel.PhoneType
            };
            _context.Phones.Add(phone);

            var email = new Email
            {
                EmployeeId = id,
                Mail = viewModel.Email,
                MailType = viewModel.MailType
            };
            _context.Emails.Add(email);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeViewModel viewModel, int id)
        {
            var employee = _mapper.Map<Employee>(viewModel);
            _context.Update(employee);

            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.EmployeeId == id);
            address.Location = viewModel.Location;
            address.AddressNumber = (Int16)viewModel.AddressNumber;
            address.Country = viewModel.Country;
            address.Comments = viewModel.Comments;
            address.PostCode = (Int16)viewModel.PostCode;
            _context.Addresses.Update(address);

            var phone = await _context.Phones.FirstOrDefaultAsync(p => p.EmployeeId == id);
            if (phone == null)
            {
                var newPhone = new Phone()
                {
                    EmployeeId = id,
                    Number = viewModel.PhoneNumber,
                    PhoneType = viewModel.PhoneType
                };
                _context.Phones.Add(newPhone);
            }
            else
            {
                phone.Number = viewModel.PhoneNumber;
                phone.PhoneType = viewModel.PhoneType;
                _context.Phones.Update(phone);
            }

            var email = await _context.Emails.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (email == null)
            {
                var newMail = new Email()
                {
                    EmployeeId = id,
                    Mail = viewModel.Email,
                    MailType = viewModel.MailType
                };
                _context.Emails.Add(newMail);
            }
            else
            {
                email.Mail = viewModel.Email;
                email.MailType = viewModel.MailType;
                _context.Emails.Update(email);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int? id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.EmployeeId == id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }
            var email = await _context.Emails.SingleOrDefaultAsync(e => e.EmployeeId == id);
            if (email != null)
            {
                _context.Emails.Remove(email);
            }
            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.EmployeeId == id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }

            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeViewModel> CreateViewModel()
        {
            return new EmployeeViewModel
            {
                Departments = await _context.Departments.ToListAsync(),
                Users = await _userManager.Users.ToListAsync()
            };
        }
    }
}