using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.Category
{
    public class NewCategoryModel
    {
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}