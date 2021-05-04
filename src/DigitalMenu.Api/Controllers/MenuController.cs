using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.Menu;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("{companySlug}")]
        public async Task<IActionResult> GetMenu(string companySlug)
        {
            var currency = Request.Headers["X-Currency"];
            var response = await _menuService.GetMenuByCompanySlugAsync(companySlug, GetCurrentLanguage(), currency);
            if (response.Success)
                return Success(data: response.Data);

            return Error(response.Message, response.InternalMessage);
        }

        [HttpPut("theme/{userId}")]
        [Authorize]
        public async Task<IActionResult> UpdateMenuTheme([FromRoute] Guid userId, [FromForm] MenuThemeModel model)
        {
            System.Console.WriteLine(model.SelectedCategoryBorderColor);
            var response = await _menuService.UpdateMenuThemeAsync(userId, model);
            if (response.Success)
                return Success();

            return Error(response.Message);
        }

        [HttpGet("theme/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetMenuTheme([FromRoute] Guid userId)
        {
            var response = await _menuService.GetMenuThemeAsync(userId);
            if (response.Success)
                return Success(data: response.Data);

            return Error(response.Message);
        }
    }
}