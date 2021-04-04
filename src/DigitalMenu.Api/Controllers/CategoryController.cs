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
            {
                return Success();
            }
            else
            {
                return Error();
            }
        }
    }
}