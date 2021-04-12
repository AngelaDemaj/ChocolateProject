using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public LeaveService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LeaveViewModel> GetLeaveWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var leave = await _context.Leaves
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);

            return _mapper.Map<LeaveViewModel>(leave);
        }

        public async Task<Leave> CreateLeave(
            LeaveViewModel viewModel, ClaimsPrincipal user, HttpRequest request)
        {
            foreach (var file in request.Form.Files)
            {
                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                viewModel.File = memoryStream.ToArray();
                viewModel.FileName = file.FileName;
            }

            var leave = _mapper.Map<Leave>(viewModel);
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.UserId ==
                    user.FindFirstValue(ClaimTypes.NameIdentifier)); //this is how we get the user Id
            leave.EmployeeId = employee.Id;

            leave.LeaveHistories.Add(new LeaveHistory
            {
                ApplicationDate = DateTime.Now,
                EmployeeId = employee.Id
            });

            _context.Add(leave);
            await _context.SaveChangesAsync();

            return leave;
        }

        public async Task UpdateLeave(Leave leave)
        {
            _context.Update(leave);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLeave(int? id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();
        }

        public async Task ApproveLeave(int id, ClaimsPrincipal user)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.UserId ==
                    user.FindFirstValue(ClaimTypes.NameIdentifier));

            var leave = await _context.Leaves.FindAsync(id);
            leave.Status = LeaveStatus.Approved;

            leave.LeaveHistories.Add(new LeaveHistory {
                ApprovalDate = DateTime.Now,
                EmployeeId = employee.Id
            });

            await _context.SaveChangesAsync();
        }

        public async Task RejectLeave(int id, ClaimsPrincipal user)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.UserId ==
                    user.FindFirstValue(ClaimTypes.NameIdentifier));

            var leave = await _context.Leaves.FindAsync(id);
            leave.Status = LeaveStatus.Rejected;

            leave.LeaveHistories.Add(new LeaveHistory
            {
                ApprovalDate = DateTime.Now,
                EmployeeId = employee.Id
            });

            await _context.SaveChangesAsync();
        }

        public async Task<FileViewModel> GetFile(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);

            return new FileViewModel
            {
                FileStream = leave.File,
                FileName = leave.FileName
            };
        }
    }
}