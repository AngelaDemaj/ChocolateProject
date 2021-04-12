using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<WarehouseViewModel> GetWarehouse(int? id);

        Task<Phone> GetWarehousePhone(int? warehouseId);

        Task<Email> GetWarehouseEmail(int? warehouseId);

        Task<Warehouse> CreateWarehouse(WarehouseViewModel viewModel);

        Task CreateWarehouseAddress(WarehouseViewModel viewModel, int warehouseId);

        Task CreateWarehouseStorageUnits(WarehouseViewModel viewModel, int warehouseId);

        Task CreateWarehousePhone(WarehouseViewModel viewModel, int warehouseId);

        Task CreateWarehouseEmail(WarehouseViewModel viewModel, int warehouseId);

        Task UpdateWarehouse(WarehouseViewModel viewModel, int id);

        Task DeleteWarehouse(int? id);
    }
}