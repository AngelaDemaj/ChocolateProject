using System.Threading.Tasks;
using Chocolate.DataAccess.ViewModels;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IOfferItemService
    {
        Task<OfferItemViewModel> GetOfferItem(int? id);

        Task<OfferItemViewModel> GetOfferItemWithIncludes(int? id);

        Task<OfferItemViewModel> GetRelatedEntities();

        Task CreateOfferItem(OfferItemViewModel viewModel);

        Task UpdateOfferItem(OfferItemViewModel viewModel);

        Task DeleteOfferItem(int? id);
    }
}