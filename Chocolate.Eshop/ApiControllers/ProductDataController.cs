using Chocolate.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chocolate.Eshop.ApiControllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductDataController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductDataController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetProductsWithIncludes(1,1));
        }
    }
}
