using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Service.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace src.DigitalMenu.Api.Controllers
{
    [Authorize]
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
    }
}