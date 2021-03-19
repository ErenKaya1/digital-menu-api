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

        public bool InTrialModel { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public SubscriptionStatus SubscriptionStatus { get; set; }

        public DMUser User { get; set; }
    }
}