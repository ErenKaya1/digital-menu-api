using System.Collections.Generic;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string ImageName { get; set; }

        public List<CategoryTranslation> CategoryTranslation { get; set; }
    }
}