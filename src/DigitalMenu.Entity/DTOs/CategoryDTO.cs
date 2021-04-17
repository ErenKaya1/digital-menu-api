using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalMenu.Entity.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public string ImagePath { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}