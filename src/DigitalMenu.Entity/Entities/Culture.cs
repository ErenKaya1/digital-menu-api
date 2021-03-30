using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("culture")]
    public class Culture : BaseEntity
    {
        [Required]
        [StringLength(5)]
        public string CultureCode { get; set; }

        public bool IsDefaultCulture { get; set; }
    }
}