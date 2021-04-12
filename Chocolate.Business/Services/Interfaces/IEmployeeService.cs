using Chocolate.DataAccess.ViewModels;
using Chocolate.DataAccess.Models;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> GetDetails(int? id);

        Task<EmployeeViewModel> FindEmployeeWithInclusions(int? id);

        Task<Employee> CreateEmployee(EmployeeViewModel viewModel);

        Task CreateEmployeeInfo(EmployeeViewModel viewModel, int id);

        Task UpdateEmployee(EmployeeViewModel viewModel, int id);

        Task DeleteEmployee(int? id);
        Task<EmployeeViewModel> CreateViewModel();
    }
}