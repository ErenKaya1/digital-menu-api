using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Core.Attribute;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("user")]
    public class DMUser : BaseEntity
    {
        [Required]
        [StringLength(16)]
        public string UserName { get; set; }

        [Required]
        [StringLength(16)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(16)]
        public string LastName { get; set; }

        [Required]
        [Encrypted]
        public string EmailAddress { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [Encrypted]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid RoleId { get; set; }

        public List<RefreshToken> RefreshToken { get; set; } = new List<RefreshToken>();
        public List<Subscription> Subscription { get; set; }
        public List<ResetPasswordToken> ResetPasswordToken { get; set; }
        public DMRole Role { get; set; }
    }
}