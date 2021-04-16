using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    public class MenuController : BaseController
    {
        [HttpGet("{companySlug}")]
        public async Task<IActionResult> GetMenu(string companySlug)
        {
            System.Console.WriteLine(companySlug);
            return Success();
        }
    }
}