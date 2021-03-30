using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type")]
    public class SubscriptionType : BaseEntity
    {
        public double Price { get; set; }
        public List<SubscriptionTypeTranslation> SubscriptionTypeTranslation { get; set; }
        public List<SubscriptionTypeFeature> SubscriptionTypeFeature { get; set; }
    }
}