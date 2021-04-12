using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [ApiController]
    [Route("api/roles")]
    public class AdministrationDataController : BaseApiController<IdentityRole>
    {
        public AdministrationDataController(ChocolateDbContext context) : base(context)
        {

        }

        [NonAction]
        public override Expression<Func<IdentityRole, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return r => r.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<IdentityRole, object>>> GetIncludes()
        {
            return null;
        }
    }
}
