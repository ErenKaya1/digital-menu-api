using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.Category;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> NewCategory([FromRoute] Guid userId, [FromForm] NewCategoryModel model)
        {
            var response = await _categoryService.InsertCategoryAsync(model, userId);
            if (response.Success)
                return Success();
            else
                return Error();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllCategories([FromRoute] Guid userId)
        {
            var response = await _categoryService.GetCategoriesAsync(userId);
            if (response.Success)
                return Success(data: response.Data);

            return Error(code: 404);
        }

        [HttpPut("{userId}/update")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid userId, [FromForm] UpdateCategoryModel model)
        {
            var response = await _categoryService.UpdateCategoryAsync(model, userId);
            if (response.Success)
                return Success();
            return Error();
        }

        [HttpDelete("{userId}/{categoryId}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid userId, [FromRoute] Guid categoryId)
        {
            var response = await _categoryService.DeleteCategoryAsync(categoryId, userId);
            if (response.Success)
                return Success();
            return Error(response.Message, response.InternalMessage);
        }

        [HttpGet("{userId}/{categoryId}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid userId, [FromRoute] Guid categoryId)
        {
            var response = await _categoryService.GetByIdAsync(userId, categoryId);
            if (response.Success)
                return Success(data: response.Data);
            return Error(response.Message, response.InternalMessage);
        }
    }
}