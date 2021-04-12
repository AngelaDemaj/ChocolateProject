using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IRawMaterialService
    {
        Task<RawMaterialViewModel> GetRawMaterial(int? id);

        Task<RawMaterialViewModel> GetRawMaterialWithIncludes(int? id);

        Task<RawMaterialViewModel> GetRelatedEntities();

        Task CreateRawMaterial(RawMaterialViewModel viewModel);

        Task UpdateRawMaterial(int id, RawMaterialViewModel viewModel);

        Task DeleteRawMaterial(int? id);
    }
}