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
    [Route("api/warehouses")]
    public class WarehouseDataController : BaseApiController<Warehouse>
    {
        public WarehouseDataController(ChocolateDbContext context) : base(context)
        {
                
        }

        [NonAction]
        public override Expression<Func<Warehouse, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }
            else
            {
                return s => s.Name.Contains(term);
            }
        }

        [NonAction]
        public override List<Expression<Func<Warehouse, object>>> GetIncludes()
        {
            return null;
        }
    }
}
