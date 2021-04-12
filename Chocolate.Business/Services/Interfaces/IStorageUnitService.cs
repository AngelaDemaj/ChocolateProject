using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IStorageUnitService
    {
        Task<StorageUnitViewModel> GetStorageUnit(int? id);

        Task<StorageUnitViewModel> GetStorageUnitWithIncludes(int? id);

        Task<StorageUnitViewModel> GetRelatedEntities();

        Task<StorageUnit> CreateStorageUnit(StorageUnitViewModel viewModel);

        Task FillWarehouseAddress(StorageUnitViewModel viewModel, int? storageUnitId);

        Task FillWarehouseAddresses(StorageUnitViewModel viewModel);

        Task CreateStorageUnitSector(StorageUnitViewModel viewModel, int storageUnitId);

        Task UpdateStorageUnit(int id, StorageUnitViewModel viewModel);

        Task DeleteStorageUnit(int? id);
    }
}