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
    [Route("api/storageunits")]
    public class StorageUnitDataController : BaseApiController<StorageUnit>
    {
        public StorageUnitDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<StorageUnit, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return s => s.Name.Contains(term) ||
                        s.Warehouse.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<StorageUnit, object>>> GetIncludes()
        {
            return new List<Expression<Func<StorageUnit, object>>>
            {
                su => su.Warehouse
            };
        }
    }
}