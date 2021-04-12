using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Chocolate.Eshop.ApiControllers
{
    [ApiController]
    [Route("api/positions")]
    public class PositionDataController : BaseApiController<Position>
    {
        public PositionDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Position, bool>> GetFilter(string term)
        {
            return p => p.IsActive == true;
        }

        [NonAction]
        public override List<Expression<Func<Position, object>>> GetIncludes()
        {
            return new List<Expression<Func<Position, object>>>
            {
                p=>p.Department
            };
        }
    }
}