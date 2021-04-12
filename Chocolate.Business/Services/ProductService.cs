using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ChocolateDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ProductViewModel> GetProduct(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<ProductViewModel>(product);

            return viewModel;
        }

        public async Task<ProductViewModel> GetProductWithIncludes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var product = await _context.Products
                .Include(p => p.RawMaterialProducts)
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<ProductViewModel>(product);

            var photo = product.Photos.FirstOrDefault();

            if (photo != null)
            {
                viewModel.ImageString = string
                .Format($"data:image/jpg;base64 ," +
                    $" {Convert.ToBase64String(photo.ImageData)}");
            }

            viewModel.RawMaterials = await _context.RawMaterials
                .ToListAsync();

            viewModel.RawMaterialIds = product.RawMaterialProducts
                .Select(rmp => rmp.RawMaterialId)
                .ToList();
            return viewModel;
        }

        public async Task<List<ProductViewModel>> GetProductsWithIncludes(int pageSize, int currentPage)
        {
            var products = await _context.Products
                .Include(p => p.RawMaterialProducts)
                .Include(p => p.Photos)
                .Where(p => p.Photos.Count > 0)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (products == null)
            {
                return null;
            }

            var viewModels = _mapper.Map<List<ProductViewModel>>(products);

            foreach (var viewModel in viewModels)
            {
                var photo = viewModel.Photos.FirstOrDefault();

                if (photo != null)
                {
                    viewModel.ImageString = string
                    .Format($"data:image/jpg;base64 ," +
                        $" {Convert.ToBase64String(photo.ImageData)}");
                }
            }

            return viewModels;
        }

        public async Task<ProductViewModel> GetRelatedEntities()
        {
            var viewModel = new ProductViewModel
            {
                RawMaterials = await _context.RawMaterials
                    .ToListAsync()
            };

            return viewModel;
        }

        public async Task CreateProduct(ProductViewModel viewModel, HttpRequest request)
        {
            foreach (var file in request.Form.Files)
            {
                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                viewModel.ImageData = memoryStream.ToArray();
                viewModel.FileName = file.FileName;
            }

            var product = _mapper.Map<Product>(viewModel);
            product.Photos.Add(new Photo
            {
                ImageData = viewModel.ImageData,
                Name = viewModel.FileName,
            });

            _context.Add(product);

            foreach (var rawMaterialId in viewModel.RawMaterialIds)
            {
                var rawMaterialProduct = new RawMaterialProduct
                {
                    Product = product,
                    RawMaterialId = rawMaterialId
                };

                _context.Add(rawMaterialProduct);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductViewModel viewModel, HttpRequest request)
        {
            foreach (var file in request.Form.Files)
            {
                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                viewModel.ImageData = memoryStream.ToArray();
                viewModel.FileName = file.FileName;
            }

            var product = _mapper.Map<Product>(viewModel);

            product.Photos.Add(new Photo
            {
                ImageData = viewModel.ImageData,
                Name = viewModel.FileName,
            });

            var rawMaterialIds = await _context.RawMaterialProducts
                .Where(rmp => rmp.ProductId == viewModel.Id)
                .Select(rmp => rmp.RawMaterialId)
                .ToListAsync();

            foreach (var rawMaterialId in viewModel.RawMaterialIds)
            {
                if (!rawMaterialIds.Contains(rawMaterialId))
                {
                    var rawMaterialProduct = new RawMaterialProduct
                    {
                        Product = product,
                        RawMaterialId = rawMaterialId
                    };

                    _context.Add(rawMaterialProduct);
                }
                else
                {
                    rawMaterialIds.Remove(rawMaterialId);
                }
            }

            foreach (var rawMaterialId in rawMaterialIds)
            {
                var rawMaterialProduct = await _context.RawMaterialProducts
                    .SingleOrDefaultAsync(rmp => rmp.ProductId == viewModel.Id &&
                        rmp.RawMaterialId == rawMaterialId);

                _context.RawMaterialProducts.Remove(rawMaterialProduct);
            }

            _context.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int? id)
        {
            var product = await _context.Products
                .FindAsync(id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}