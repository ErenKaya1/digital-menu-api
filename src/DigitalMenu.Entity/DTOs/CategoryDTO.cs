using System;

namespace DigitalMenu.Entity.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string NameTR { get; set; }
        public string NameEN { get; set; }
        public string ImagePath { get; set; }
    }
}