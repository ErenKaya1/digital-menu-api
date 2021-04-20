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

        public Guid? CompanyId { get; set; }

        public int ProductCount => Product.Count + ProductGroup.Count;
        public List<Product> Product { get; set; }
        public List<ProductGroup> ProductGroup { get; set; }
        public DMUser User { get; set; }
        public Company Company { get; set; }
    }
}