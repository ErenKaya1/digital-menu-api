using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("category_translation")]
    public class CategoryTranslation : BaseEntity
    {
        private string _name;
        private string _description;

        [StringLength(50)]
        public string Name { get { return _name; } set { _name = value ?? string.Empty; } }

        public string Description { get { return _description; } set { _name = value ?? string.Empty; } }

        [Required]
        public Guid CultureId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Culture Culture { get; set; }
        public Category Category { get; set; }
    }
}