using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IPositionService
    {
        Task<PositionViewModel> GetPosition(int? id);

        Task<PositionViewModel> GetPositionWithIncludes(int? id);

        Task<PositionViewModel> GetPositionWithIncludesEshop(int? id);

        Task<PositionViewModel> GetRelatedEntities();

        Task CreatePosition(PositionViewModel viewModel);

        Task UpdatePosition(PositionViewModel viewModel);

        Task DeletePosition(int? id);
    }
}