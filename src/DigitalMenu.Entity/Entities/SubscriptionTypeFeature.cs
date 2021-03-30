using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_feature")]
    public class SubscriptionTypeFeature : BaseEntity
    {
        [Required]
        public bool IsUnlimited { get; set; }

        public int? TotalValue { get; set; }

        [Required]
        public int ValueUsed { get; set; }

        public int? ValueRemained { get; set; }

        [Required]
        public Guid SubscriptionTypeId { get; set; }

        public SubscriptionType SubscriptionType { get; set; }
    }
}