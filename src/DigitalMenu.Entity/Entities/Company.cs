using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("company")]
    public class Company : BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Slug { get; set; }

        public string LogoName { get; set; }
        public bool HasLogo => !string.IsNullOrEmpty(LogoName);
    }
}