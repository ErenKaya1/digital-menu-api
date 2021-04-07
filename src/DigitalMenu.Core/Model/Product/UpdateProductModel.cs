using System;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.Product
{
    public class UpdateProductModel
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public string DescriptionTR { get; set; }
        public string DescriptionEN { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid CategoryId { get; set; }
    }
}