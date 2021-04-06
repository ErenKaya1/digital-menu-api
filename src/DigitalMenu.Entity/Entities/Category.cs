using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("category")]
    public class Category : BaseEntity
    {
        [StringLength(200)]
        public string ImageName { get; set; }

        [Required]
        public Guid UserId { get; set; }
        
        public int ProductCount => Product.Count;
        public bool AnyProduct => Product.Count > 0;
        public bool HasImage => !string.IsNullOrEmpty(ImageName);
        public List<CategoryTranslation> CategoryTranslation { get; set; }
        public List<Product> Product { get; set; }
        public DMUser User { get; set; }
    }
}