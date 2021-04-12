using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chocolate.Eshop.ApiControllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersDataController : BaseApiController<Order>
    {
        public OrdersDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Order, bool>> GetFilter(string term)
        {
            var customer = _context.Customers
                   .FirstOrDefault(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            return o => o.CustomerId == customer.Id;
        }

        [NonAction]
        public Expression<Func<Order, bool>> GetFilter(ClaimsPrincipal user)
        {
            return o => o.Customer.UserId.Contains(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }


        [NonAction]
        public override List<Expression<Func<Order, object>>> GetIncludes()
        {
            return new List<Expression<Func<Order, object>>>
            {
                p=>p.Customer
            };
        }
    }
}
