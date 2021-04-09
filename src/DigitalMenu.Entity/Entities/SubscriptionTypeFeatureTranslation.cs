using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subsctiption_type_feature_translation")]
    public class SubscriptionTypeFeatureTranslation : BaseEntity
    {
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public Guid CultureId { get; set; }

        [Required]
        public Guid SubscriptionTypeFeatureId { get; set; }

        public Culture Culture { get; set; }
        public SubscriptionTypeFeature SubscriptionTypeFeature { get; set; }
    }
}