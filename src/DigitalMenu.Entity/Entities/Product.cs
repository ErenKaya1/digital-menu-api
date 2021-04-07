using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public int Order { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid MenuId { get; set; }

        public bool HasImage => !string.IsNullOrEmpty(ImageName);
        public List<ProductTranslation> ProductTranslation { get; set; }
        public Category Category { get; set; }
        public Menu Menu { get; set; }
    }
}