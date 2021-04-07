using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.Product;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> InsertProduct([FromRoute] Guid userId, [FromForm] NewProductModel model)
        {
            var response = await _productService.InsertProductAsync(userId, model);
            if (response.Success)
                return Success();
            return Error(response.Message);
        }
    }
}