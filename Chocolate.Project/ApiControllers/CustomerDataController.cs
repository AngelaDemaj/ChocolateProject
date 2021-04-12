using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerDataController : BaseApiController<Customer>
    {
        public CustomerDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Customer, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return c => c.FirstName.Contains(term) || c.LastName.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Customer, object>>> GetIncludes()
        {
            return null;
        }
    }
}