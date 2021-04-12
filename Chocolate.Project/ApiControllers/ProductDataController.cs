using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductDataController : BaseApiController<Product>
    {
        public ProductDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Product, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return p => p.Barcode.Contains(term) || p.Name.Contains(term) || p.Description.Contains(term) ||
                        p.Price.ToString().Contains(term) ||
                        p.Weight.ToString().Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Product, object>>> GetIncludes()
        {
            return null;
        }
    }
}