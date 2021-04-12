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
    [Route("api/shelves")]
    [ApiController]
    public class ShelfDataController : BaseApiController<Shelf>
    {
        public ShelfDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Shelf, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return s => s.Name.Contains(term) ||
                        s.Sector.Name.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Shelf, object>>> GetIncludes()
        {
            return new List<Expression<Func<Shelf, object>>>
            {
                s=>s.Sector,
                s=>s.Products
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToShelf(ProductShelfViewModel viewModel)
        {
            var productShelf = new ProductShelf
            {
                ProductId = viewModel.ProductId,
                ShelfId = viewModel.ShelfId,
                Quantity = viewModel.Quantity
            };

            _context.ProductShelves.Add(productShelf);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductFromShelf(ProductShelfViewModel viewModel)
        {
            var productShelf = await _context.ProductShelves
                .FirstOrDefaultAsync(ps => ps.ShelfId == viewModel.ShelfId &&
                    ps.ProductId == viewModel.ProductId);

            _context.ProductShelves.Remove(productShelf);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("addRawMaterial")]
        public async Task<IActionResult> AddRawMaterialToShelf(RawMaterialShelf viewModel)
        {
            var rawMaterialShelf = new RawMaterialShelf
            {
                RawMaterialId = viewModel.RawMaterialId,
                ShelfId = viewModel.ShelfId,
                Quantity = viewModel.Quantity
            };

            _context.RawMaterialShelves.Add(rawMaterialShelf);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("deleteRawMaterial")]
        public async Task<IActionResult> DeleteRawMaterialFromShelf(RawMaterialShelf viewModel)
        {
            var rawMaterialShelf = await _context.RawMaterialShelves
                .FirstOrDefaultAsync(rms => rms.RawMaterialId == viewModel.RawMaterialId &&
                    rms.ShelfId == viewModel.ShelfId);

            _context.RawMaterialShelves.Remove(rawMaterialShelf);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}