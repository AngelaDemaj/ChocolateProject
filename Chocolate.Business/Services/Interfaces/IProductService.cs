using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetProduct(int? id);

        Task<ProductViewModel> GetProductWithIncludes(int? id);

        Task<List<ProductViewModel>> GetProductsWithIncludes(int pageSize, int currentPage);

        Task<ProductViewModel> GetRelatedEntities();

        Task CreateProduct(ProductViewModel viewModel, HttpRequest request);

        Task UpdateProduct(ProductViewModel viewModel, HttpRequest request);

        Task DeleteProduct(int? id);
    }
}