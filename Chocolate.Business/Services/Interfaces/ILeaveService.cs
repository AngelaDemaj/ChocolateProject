using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface ILeaveService
    {
        Task<LeaveViewModel> GetLeaveWithIncludes(int? id);

        Task<Leave>CreateLeave(LeaveViewModel viewModel, ClaimsPrincipal user, HttpRequest request);

        Task ApproveLeave(int id, ClaimsPrincipal user);

        Task RejectLeave(int id, ClaimsPrincipal user);

        Task UpdateLeave(Leave leave);

        Task DeleteLeave(int? id);

        Task<FileViewModel> GetFile(int id);
    }
}