using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/purchases")]
    [ApiController]
    public class PurchaseDataController : BaseApiController<Purchase>
    {
        public PurchaseDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Purchase, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return p => p.DateReceived.ToString().Contains(term) ||
                p.Offer.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Purchase, object>>> GetIncludes()
        {
            return new List<Expression<Func<Purchase, object>>>
            {
                p=>p.Offer
            };
        }
    }
}