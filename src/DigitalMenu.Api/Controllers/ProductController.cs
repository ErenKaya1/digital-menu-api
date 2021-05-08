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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllProducts([FromRoute] Guid userId)
        {
            var response = await _productService.GetProductsAsync(userId);
            if (response.Success)
                return Success(data: response.Data);
            return Error();
        }

        [HttpPut("{userId}/update")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid userId, [FromForm] UpdateProductModel model)
        {
            var response = await _productService.UpdateProductAsync(userId, model);
            if (response.Success)
                return Success();
            return Error(response.Message, response.InternalMessage);
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid userId, [FromRoute] Guid productId)
        {
            var response = await _productService.DeleteProductAsync(userId, productId);
            if (response.Success)
                return Success();
            return Error(response.Message, response.InternalMessage);
        }

        [HttpGet("{userId}/{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid userId, [FromRoute] Guid productId)
        {
            var response = await _productService.GetByIdAsync(userId, productId);
            if (response.Success)
                return Success(data: response.Data);
            return Error(response.Message, response.InternalMessage);
        }
    }
}