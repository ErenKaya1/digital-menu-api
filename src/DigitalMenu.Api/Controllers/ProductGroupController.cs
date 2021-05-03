using System;
using System.Threading.Tasks;
using DigitalMenu.Api.Controllers.Base;
using DigitalMenu.Core.Model.ProductGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Api.Controllers
{
    [Authorize]
    public class ProductGroupController : BaseController
    {
        [HttpPost("{userId}")]
        public async Task<IActionResult> InsertProductGroup([FromRoute] Guid userId, [FromForm] NewProductGroupModel model)
        {
            System.Console.WriteLine(model.NameTR);
            System.Console.WriteLine(model.NameEN);
            System.Console.WriteLine(model.Price);
            System.Console.WriteLine(model.DescriptionTR);
            System.Console.WriteLine(model.DescriptionEN);
            System.Console.WriteLine(model.CategoryId);
            return Success();
        }
    }
}