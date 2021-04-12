using Chocolate.DataAccess.ViewModels;
using Chocolate.DataAccess.Models;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<CandidateViewModel> GetCandidate(int? id);

        Task<Candidate> CreateCandidate(CandidateViewModel viewModel);

        Task<CandidateViewModel> FindCandidateWithInclusions(int? id);

        Task CreateCandidateInfo(CandidateViewModel viewModel, int id);

        Task<CandidateViewModel> GetRelatedEntities();

        Task UpdateCandidate(CandidateViewModel viewModel, int id);

        Task DeleteCandidate(int? id);

        Task<FileViewModel> GetFile(int id);
    }
}