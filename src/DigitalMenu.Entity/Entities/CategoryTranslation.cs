using System;
using System.ComponentModel.DataAnnotations;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    public class CategoryTranslation : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public Guid CultureId { get; set; }

        public Culture Culture { get; set; }
    }
}