using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using ChocolateProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChocolateProject.ApiControllers
{
    [ApiController]
    [Route("api/leaves")]
    public class LeaveDataController : BaseApiController<Leave>
    {
        public LeaveDataController(ChocolateDbContext context) : base(context)
        {

        }

        [Route("myApprovals")]
        [HttpPost]
        public async Task<IActionResult> MyApprovals(DatatablesPostModel model)
        {
            model.Search.Value = "MyApprovals";
            var response = await GetData(model);

            return Ok(response);
        }

        [Route("myLeaves")]
        [HttpPost]
        public async Task<IActionResult> MyLeaves(DatatablesPostModel model)
        {
            model.Search.Value = "MyLeaves";
            var response = await GetData(model);

            return Ok(response);
        }

        [NonAction]
        public override Expression<Func<Leave, bool>> GetFilter(string term)
        {
            var employee = _context.Employees
                    .FirstOrDefault(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (term == "MyLeaves")
            {
                return l => l.EmployeeId == employee.Id ;
            }
            else if (term == "MyApprovals")
            {
                return l => l.Employee.DepartmentId == employee.DepartmentId;
            }
            else
            {
                return null;
            }
        }

        [NonAction]
        public override List<Expression<Func<Leave, object>>> GetIncludes()
        {
            return new List<Expression<Func<Leave, object>>>
            {
                l => l.Employee
            };
        }
    }

}

