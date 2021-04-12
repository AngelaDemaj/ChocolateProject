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
    public class DepartmentService : IDepartmentService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartmentViewModel> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var viewModel = await FindDepartmentWithInclusions(id);
            viewModel.Employees = await _context.Employees
                .Where(e => e.DepartmentId == id)
                .ToListAsync();

            if (viewModel == null)
            {
                return null;
            }

            return viewModel;
        }

        public async Task CreateDepartment(DepartmentViewModel viewModel)
        {
            var department = _mapper.Map<Department>(viewModel); 
            _context.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartment(DepartmentViewModel viewModel)
        {
            var department = _mapper.Map<Department>(viewModel);
            _context.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int? id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<DepartmentViewModel> FindDepartmentWithInclusions(int? id)
        {
            var department = await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<DepartmentViewModel>(department);

            return viewModel;
        }
    }
}