using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("product_translation")]
    public class ProductTranslation : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CultureId { get; set; }

        public Culture Culture { get; set; }
        public Product Product { get; set; }
    }
}