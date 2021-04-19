using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Service.Contracts;
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

            return Error();
        }
    }
}