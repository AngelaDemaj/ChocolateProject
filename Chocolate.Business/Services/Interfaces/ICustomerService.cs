using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> GetDetails(int? id);

        Task<CustomerViewModel> FindCustomerWithInclusions(int? id);

        Task<Customer> CreateCustomer(CustomerViewModel viewModel);

        Task CreateCustomerInfo(CustomerViewModel viewModel, int id);

        Task UpdateCustomer(CustomerViewModel viewModel, int id);

        Task<CustomerViewModel> GetAccountDetails(ClaimsPrincipal user);

        Task UpdateAccount(CustomerViewModel viewModel, ClaimsPrincipal user);

        Task DeleteCustomer(int id);
    }
}