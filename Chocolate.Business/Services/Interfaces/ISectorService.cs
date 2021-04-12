using System.Threading.Tasks;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;

namespace Chocolate.Business.Services.Interfaces
{
    public interface ISectorService
    {
        Task<SectorViewModel> GetSector(int? id);

        Task<SectorViewModel> GetSectorWithIncludes(int? id);

        Task<SectorViewModel> GetRelatedEntities();

        Task<Sector> CreateSector(SectorViewModel viewModel);

        Task CreateSectorShelves(SectorViewModel viewModel, int sectorId);

        Task UpdateSector(int id, SectorViewModel viewModel);

        Task DeleteSector(int? id);
    }
}