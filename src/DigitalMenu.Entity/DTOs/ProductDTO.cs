using System;
using Newtonsoft.Json;

namespace DigitalMenu.Entity.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public string Description { get; set; }
        public string DescriptionTR { get; set; }
        public string DescriptionEN { get; set; }
        public Guid CategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}