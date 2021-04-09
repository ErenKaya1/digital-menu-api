using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Common.Enum;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_feature")]
    public class SubscriptionTypeFeature : BaseEntity
    {
        public bool IsUnlimited { get; set; }
        public int? TotalValue { get; set; }

        [Required]
        public Guid SubscriptionTypeId { get; set; }

        public SubscriptionFeatureName SubscriptionFeatureName { get; set; }
        public List<SubscriptionTypeFeatureTranslation> SubscriptionTypeFeatureTranslation { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}