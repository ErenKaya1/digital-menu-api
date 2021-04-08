using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("menu")]
    public class Menu : BaseEntity
    {
        [StringLength(20)]
        public string QrCodeColor { get; set; }

        [StringLength(20)]
        public string QrCodeBackgroundColor { get; set; }

        public int QrCodeScale { get; set; } = 4;
        public int QrCodeMargin { get; set; } = 4;

        [Required]
        public Guid UserId { get; set; }

        public int ProductCount => Product.Count;
        public List<Product> Product { get; set; }
        public DMUser User { get; set; }
    }
}