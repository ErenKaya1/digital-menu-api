using DigitalMenu.Entity.Entities.Base;
using DigitalMenu.Entity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription")]
    public class Subscription : BaseEntity
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public SubscriptionStatus SubscriptionStatus { get; set; }

        [Required]
        public bool IsTrialMode { get; set; }

        [Required]
        public bool IsSubscriptionReminderMailSent { get; set; }

        public Guid? SubscriptionTypeId { get; set; }

        public DMUser User { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}