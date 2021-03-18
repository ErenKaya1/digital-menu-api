using DigitalMenu.Entity.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Entity.Entities
{
    [Table("role")]
    public class DMRole : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        public List<DMUser> User { get; set; }
    }
}