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
        [Required]
        public Guid UserId { get; set; }

        public int ProductCount => Product.Count;
        public List<Product> Product { get; set; }
        public DMUser User { get; set; }
    }
}