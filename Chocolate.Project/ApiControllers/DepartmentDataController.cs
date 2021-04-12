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
    [Route("api/departments")]
    public class DepartmentDataController : BaseApiController<Department>
    {
        public DepartmentDataController(ChocolateDbContext context): base(context)
        {

        }

        [NonAction]
        public override Expression<Func<Department, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }
            else
            {
                return d => d.Name.Contains(term);
            }
        }

        [NonAction]
        public override List<Expression<Func<Department, object>>> GetIncludes()
        {
            return null;
        }
    }
}
