using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferDataController : BaseApiController<Offer>
    {
        public OfferDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Offer, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return o => o.Employee.LastName.Contains(term) ||
                o.DiscountLevel.DiscountPercentage.ToString().Contains(term) ||
                o.Supplier.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Offer, object>>> GetIncludes()
        {
            return new List<Expression<Func<Offer, object>>>
            {
                o=>o.Employee,
                o=>o.DiscountLevel,
                o=>o.Supplier
            };
        }
    }
}