using System;
using System.ComponentModel.DataAnnotations;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    public class RefreshToken : BaseEntity
    {
        [Required]
        public Guid Token { get; set; }

        [Required]
        public DateTime Expires { get; set; }

        [Required]
        public bool IsExpired => DateTime.UtcNow >= Expires;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedByIp { get; set; }

        public DateTime? Revoked { get; set; }

        [StringLength(20)]
        public string RevokedByIp { get; set; }

        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;

        [Required]
        public Guid UserId { get; set; }

        public DMUser User { get; set; }
    }
}