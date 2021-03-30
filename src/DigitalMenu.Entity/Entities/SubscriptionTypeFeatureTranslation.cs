using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_feature_translation")]
    public class SubscriptionTypeFeatureTranslation : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string FeatureName { get; set; }

        [Required]
        public Guid SubscriptionTypeFeatureId { get; set; }

        [Required]
        public Guid CultureId { get; set; }

        public SubscriptionTypeFeature SubscriptionTypeFeature { get; set; }
        public Culture Culture { get; set; }
    }
}