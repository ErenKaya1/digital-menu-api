using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_feature")]
    public class SubscriptionTypeFeature : BaseEntity
    {
        public bool IsUnlimited { get; set; }
        public int? TotalValue { get; set; }
        public int? ValueUsed { get; set; }
        public int? ValueRemained { get; set; }
        public List<SubscriptionTypeFeatureTranslation> SubscriptionTypeFeatureTranslation { get; set; }
    }
}