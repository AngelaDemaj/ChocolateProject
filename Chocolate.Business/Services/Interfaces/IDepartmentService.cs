using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentViewModel> GetDetails(int? id);

        Task<DepartmentViewModel> FindDepartmentWithInclusions(int? id);

        Task CreateDepartment(DepartmentViewModel viewModel);

        Task UpdateDepartment(DepartmentViewModel viewModel);

        Task DeleteDepartment(int? id);
    }
}