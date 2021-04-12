using Chocolate.DataAccess.ViewModels;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IInterviewService
    {
        Task<InterviewViewModel> GetInterview(int? id);

        Task<InterviewViewModel> CreateViewModel();

        Task<InterviewViewModel> GetInterviewWithIncludes(int? id);

        Task CreateInterview(InterviewViewModel interview);

        Task UpdateInterview(InterviewViewModel interview);

        Task DeleteInterview(int? id);
    }
}