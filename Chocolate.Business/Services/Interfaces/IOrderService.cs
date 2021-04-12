using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewModel> GetOrder(int? id);

        Task<OrderViewModel> GetOrderWithIncludes(int? id);

        Task<OrderViewModel> GetRelatedEntities();

        Task CreateOrder(OrderViewModel viewModel);

        Task UpdateOrder(OrderViewModel viewModel);

        Task DeleteOrder(int? id);
    }
}