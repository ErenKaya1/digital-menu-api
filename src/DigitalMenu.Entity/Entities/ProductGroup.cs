using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("product_group")]
    public class ProductGroup : BaseEntity
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid MenuId { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        public List<Product> Product { get; set; }
        public List<ProductTranslation> ProductTranslation { get; set; }
        public Category Category { get; set; }
        public Menu Menu { get; set; }
    }
}