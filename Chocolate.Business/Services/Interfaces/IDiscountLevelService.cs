using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IDiscountLevelService
    {
        Task<DiscountLevelViewModel> GetDiscountLevel(int? id);

        Task<DiscountLevelViewModel> GetDiscountLevelWithIncludes(int? id);

        Task<DiscountLevelViewModel> GetDiscounts();

        Task CreateDiscountLevel(DiscountLevelViewModel viewModel);

        Task UpdateDiscountLevel(DiscountLevelViewModel viewModel);

        Task DeleteDiscountLevel(int? id);
    }
}