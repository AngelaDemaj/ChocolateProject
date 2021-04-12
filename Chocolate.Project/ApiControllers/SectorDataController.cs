using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/sectors")]
    [ApiController]
    public class SectorDataController : BaseApiController<Sector>
    {
        public SectorDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Sector, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return s => s.Name.Contains(term) ||
                        s.StorageUnit.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Sector, object>>> GetIncludes()
        {
            return new List<Expression<Func<Sector, object>>>
            {
                s=>s.StorageUnit
            };
        }
    }
}