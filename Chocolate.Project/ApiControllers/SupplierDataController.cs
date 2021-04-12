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
    [Route("api/suppliers")]
    public class SupplierDataController : BaseApiController<Supplier>
    {
        public SupplierDataController(ChocolateDbContext context) : base(context)
        {

        }

        [NonAction]
        public override Expression<Func<Supplier, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }
            else
            {
                return s => s.Name.Contains(term) ||
                    s.Type.Contains(term);
            }
        }

        [NonAction]
        public override List<Expression<Func<Supplier, object>>> GetIncludes()
        {
            return null;
        }
    }
}
