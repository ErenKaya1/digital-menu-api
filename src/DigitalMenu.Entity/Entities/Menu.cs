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

        [Required]
        [StringLength(10)]
        public string BackgroundColor { get; set; }

        [Required]
        [StringLength(10)]
        public string TextColor { get; set; }

        [Required]
        [StringLength(10)]
        public string PriceColor { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryDescriptionColor { get; set; }

        [Required]
        [StringLength(10)]
        public string SelectedCategoryBorderColor { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductBackgroundColor { get; set; }

        [Required]
        [StringLength(10)]
        public string LanguageCurrencyBackgroundColor { get; set; }

        [Required]
        [StringLength(10)]
        public string LanguageCurrencyTextColor { get; set; }

        [Required]
        [StringLength(10)]
        public string LinkColor { get; set; }

        public int ProductCount => Product.Count + ProductGroup.Count;
        public List<Product> Product { get; set; }
        public List<ProductGroup> ProductGroup { get; set; }
        public DMUser User { get; set; }
        public Company Company { get; set; }
    }
}