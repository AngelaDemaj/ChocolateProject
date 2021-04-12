using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierViewModel> GetDetails(int? id);

        Task CreateSupplier(SupplierViewModel viewModel);

        Task<SupplierViewModel> FindSupplier(int? id);

        Task UpdateSupplier(SupplierViewModel viewModel);

        Task DeleteSupplier(int? id);
    }
}