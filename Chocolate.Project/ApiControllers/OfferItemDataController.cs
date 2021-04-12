using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/offerItems")]
    [ApiController]
    public class OfferItemDataController : BaseApiController<OfferItem>
    {
        public OfferItemDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<OfferItem, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return oi => oi.RawMaterial.Name.Contains(term) ||
                         oi.Offer.Supplier.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<OfferItem, object>>> GetIncludes()
        {
            return new List<Expression<Func<OfferItem, object>>>
            {
                oi=>oi.RawMaterial,
                oi=>oi.Offer.Supplier
            };
        }
    }
}