using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("payment")]
    public class Payment : BaseEntity
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid SubscriptionId { get; set; }

        public DMUser User { get; set; }
        public Subscription Subscription { get; set; }
    }
}