using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("product_translation")]
    public class ProductGroupTranslation : BaseEntity
    {
        private string _name;
        private string _description;

        [Required]
        public Guid ProductGroupId { get; set; }

        [Required]
        public Guid CultureId { get; set; }

        [StringLength(50)]
        public string Name { get { return _name; } set { _name = value ?? string.Empty; } }
        
        public string Description { get { return _description; } set { _description = value ?? string.Empty; } }

        public ProductGroup ProductGroup { get; set; }
        public Culture Culture { get; set; }
    }
}