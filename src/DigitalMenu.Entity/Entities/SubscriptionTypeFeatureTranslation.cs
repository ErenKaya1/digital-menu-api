using System;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subsctiption_type_feature_translation")]
    public class SubscriptionTypeFeatureTranslation : BaseEntity
    {
        public string Name { get; set; }
        public Guid CultureId { get; set; }
        public Guid SubscriptionTypeFeatureId { get; set; }

        public Culture Culture { get; set; }
        public SubscriptionTypeFeature SubscriptionTypeFeature { get; set; }
    }
}