using System;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.Category
{
    public class UpdateCategoryModel
    {
        public Guid Id { get; set; }
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}