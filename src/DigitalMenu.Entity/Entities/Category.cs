using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("category")]
    public class Category : BaseEntity
    {
        public string ImageName { get; set; }
        
        public int ProductCount => Product.Count;
        public bool AnyProduct => Product.Count > 0;
        public bool HasImage => !string.IsNullOrEmpty(ImageName);
        public List<CategoryTranslation> CategoryTranslation { get; set; }
        public List<Product> Product { get; set; }
    }
}