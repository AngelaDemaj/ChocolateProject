using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountDataController : BaseApiController<Discount>
    {
        public DiscountDataController(ChocolateDbContext context) : base(context)
        {

        }

        [NonAction]
        public override Expression<Func<Discount, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return d => d.Supplier.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Discount, object>>> GetIncludes()
        {
            return new List<Expression<Func<Discount, object>>>
            {
                d=>d.Supplier
            };
        }
    }
}
