using DigitalMenu.Entity.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Entity.Entities
{
    [Table("reset_password_token")]
    public class ResetPasswordToken : BaseEntity
    {
        [Required]
        public string TokenHash { get; set; }

        [Required]
        public DateTime Expires { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DMUser User { get; set; }
    }
}