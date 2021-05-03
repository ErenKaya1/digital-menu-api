using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.ProductGroup
{
    public class NewProductGroupModel
    {
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public double Price { get; set; }
        public string DescriptionTR { get; set; }
        public string DescriptionEN { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> Products { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}