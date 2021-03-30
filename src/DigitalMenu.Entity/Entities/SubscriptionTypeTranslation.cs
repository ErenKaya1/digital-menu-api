using System;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_translation")]
    public class SubscriptionTypeTranslation : BaseEntity
    {
        public string Title { get; set; }

        public Guid CultureId { get; set; }
        public Guid SubscriptionTypeId { get; set; }

        public Culture Culture { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}