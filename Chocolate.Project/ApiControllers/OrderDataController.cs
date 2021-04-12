using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChocolateProject.ApiControllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderDataController : BaseApiController<Order>
    {
        public OrderDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Order, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return o => o.Customer.LastName.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Order, object>>> GetIncludes()
        {
            return new List<Expression<Func<Order, object>>>
            {
                o=>o.Customer
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToShelf(OrderProductViewModel viewModel)
        {
            var orderProduct = new OrderProduct
            {
                ProductId = viewModel.ProductId,
                OrderId = viewModel.OrderId,
                Quantity = viewModel.Quantity
            };

            _context.OrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductFromShelf(OrderProductViewModel viewModel)
        {
            var orderProduct = await _context.OrderProducts
                .FirstOrDefaultAsync(
                    op => op.OrderId == viewModel.OrderId
                          && op.ProductId == viewModel.ProductId);
            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}