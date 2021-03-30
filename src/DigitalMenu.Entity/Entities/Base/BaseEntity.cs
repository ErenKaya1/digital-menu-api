using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Entity.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public virtual Guid Id { get; set; }
    }
}