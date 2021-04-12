using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IOfferService
    {
        Task<OfferViewModel> GetOffer(int? id);

        Task<OfferViewModel> GetOfferWithIncludes(int? id);

        Task<OfferViewModel> GetRelatedEntities();

        Task CreateOffer(OfferViewModel viewModel);

        Task UpdateOffer(OfferViewModel viewModel);

        Task DeleteOffer(int? id);
    }
}