using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChocolateProject.ApiControllers
{   
    [Route("api/meetings")]
    [ApiController]
    public class MeetingDataController : BaseApiController<Meeting>
    {
        public MeetingDataController(ChocolateDbContext context) :base(context)
        {

        }

        [NonAction]
        public override Expression<Func<Meeting, bool>> GetFilter(string term)
        {
            return null;
        }
        
        [NonAction]
        public override List<Expression<Func<Meeting, object>>> GetIncludes()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting(Meeting meeting)
        {
            meeting.Employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.UserId ==
                    User.FindFirstValue(ClaimTypes.NameIdentifier));

            var employees = await _context.Employees
                .Where(e => e.DepartmentId == meeting.Employee.DepartmentId)
                .ToListAsync();

            _context.Meetings.Add(meeting);

            foreach (var employee in employees)
            {
                _context.EmployeeMeetings.Add(new EmployeeMeeting
                {
                    EmployeeId = employee.Id,
                    Meeting = meeting
                });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMeetings()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (user != null)
            {
                var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.UserId == user);

                var userMeetings = await _context.EmployeeMeetings
                    .Include(em => em.Meeting)
                    .Where(em => em.EmployeeId == employee.Id)
                    .Select(em => new {
                        Title = em.Meeting.Title,
                        Start = em.Meeting.When.ToString("MM-dd-yyyy HH:mm"),
                        ClassName = "bg-info"
                    })
                    .ToListAsync();

                return Ok(userMeetings);
            }
            return Ok();
        }
    }
}
