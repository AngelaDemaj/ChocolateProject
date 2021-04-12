using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ChocolateDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrderViewModel> GetOrder(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OrderViewModel>(order);

            return viewModel;
        }

        public async Task<OrderViewModel> GetOrderWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OrderViewModel>(order);

            viewModel.OrderProducts = await _context.OrderProducts
                .Include(op => op.Product)
                .Where(op => op.OrderId == id)
                .ToListAsync();

            viewModel.AllProducts = await _context.Products.ToListAsync();

            viewModel.Customers = await _context.Customers
                .ToListAsync();

            return viewModel;
        }

        public async Task<OrderViewModel> GetRelatedEntities()
        {
            var viewModel = new OrderViewModel
            {
                Customers = await _context.Customers.ToListAsync()
            };

            return viewModel;
        }

        public async Task CreateOrder(OrderViewModel viewModel)
        {
            var order = _mapper.Map<Order>(viewModel);
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(OrderViewModel viewModel)
        {
            var order = _mapper.Map<Order>(viewModel);
            _context.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int? id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}