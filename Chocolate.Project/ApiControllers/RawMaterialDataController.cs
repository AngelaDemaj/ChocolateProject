using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/rawMaterials")]
    [ApiController]
    public class RawMaterialDataController : BaseApiController<RawMaterial>
    {
        public RawMaterialDataController(ChocolateDbContext context) :base(context)
        {

        }

        [NonAction]
        public override Expression<Func<RawMaterial, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return s => s.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<RawMaterial, object>>> GetIncludes()
        {
            return null;
        }
    }
}
