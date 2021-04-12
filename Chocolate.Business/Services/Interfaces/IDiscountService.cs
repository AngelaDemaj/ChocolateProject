using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(int? id);

        Task<DiscountViewModel> GetDiscountWithIncludes(int? id);

        Task<DiscountViewModel> GetRelatedEntities();

        Task CreateDiscount(DiscountViewModel viewModel);

        Task UpdateDiscount(DiscountViewModel viewModel);

        Task DeleteDiscount(int? id);
    }
}