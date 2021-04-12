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
    [Route("api/users")]
    public class UserDataController : BaseApiController<IdentityUser>
    {
        public UserDataController(ChocolateDbContext context) : base(context)
        {

        }

        [NonAction]
        public override Expression<Func<IdentityUser, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }
            else
            {
                return u => u.UserName.Contains(term);
            }
        }

        [NonAction]
        public override List<Expression<Func<IdentityUser, object>>> GetIncludes()
        {
            return null;
        }
    }
}
