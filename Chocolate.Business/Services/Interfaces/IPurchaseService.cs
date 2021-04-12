using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<PurchaseViewModel> GetPurchase(int? id);

        Task<PurchaseViewModel> GetPurchaseWithIncludes(int? id);

        Task<PurchaseViewModel> GetRelatedEntities();

        Task CreatePurchase(PurchaseViewModel viewModel);

        Task UpdatePurchase(PurchaseViewModel viewModel);

        Task DeletePurchase(int? id);
    }
}