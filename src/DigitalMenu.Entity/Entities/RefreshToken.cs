using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("refresh_token")]
    public class RefreshToken : BaseEntity
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime Expires { get; set; }

        [Required]
        public bool IsExpired => DateTime.UtcNow >= Expires;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedByIp { get; set; }

        public DateTime? RevokedAt { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        
        [Required]
        public bool IsActive => RevokedAt == null && !IsExpired;

        [Required]
        public Guid UserId { get; set; }

        public DMUser User { get; set; }
    }
}