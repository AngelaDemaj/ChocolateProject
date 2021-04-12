using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeDataController : BaseApiController<Employee>
    {
        public EmployeeDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Employee, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return e => e.FirstName.Contains(term) ||
                        e.LastName.Contains(term) ||
                        e.Department.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Employee, object>>> GetIncludes()
        {
            return new List<Expression<Func<Employee, object>>>
            {
                e=>e.Department
            };
        }
    }
}