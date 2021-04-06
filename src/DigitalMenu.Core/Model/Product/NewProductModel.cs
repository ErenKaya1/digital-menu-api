using System;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.Product
{
    public class NewProductModel
    {
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public string DescriptionTR { get; set; }
        public string DescriptionEN { get; set; }
        public double Price { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid CategoryId { get; set; }
    }
}