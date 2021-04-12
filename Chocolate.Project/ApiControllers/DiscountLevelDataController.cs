using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/discountLevels")]
    [ApiController]
    public class DiscountLevelDataController : BaseApiController<DiscountLevel>
    {
        public DiscountLevelDataController(ChocolateDbContext context):base(context)
        {

        }

        [NonAction]
        public override Expression<Func<DiscountLevel, bool>> GetFilter(string term)
        {
            return null;
        }

        [NonAction]
        public override List<Expression<Func<DiscountLevel, object>>> GetIncludes()
        {
            return null;
        }
    }
}
