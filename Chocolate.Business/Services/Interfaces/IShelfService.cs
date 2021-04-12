using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IShelfService
    {
        Task<ShelfViewModel> GetShelf(int? id);

        Task<ShelfViewModel> GetShelfWithIncludes(int? id);

        Task<ShelfViewModel> GetRelatedEntities();

        Task CreateShelf(ShelfViewModel viewModel);

        Task UpdateShelf(int id, ShelfViewModel viewModel);

        Task DeleteShelf(int? id);
    }
}