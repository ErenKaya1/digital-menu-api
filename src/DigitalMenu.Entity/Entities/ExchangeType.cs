using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("exhange_type")]
    public class ExchangeType : BaseEntity
    {
        [Required]
        public double USDtoTRY { get; set; }

        [Required]
        public double EURtoTRY { get; set; }
    }
}