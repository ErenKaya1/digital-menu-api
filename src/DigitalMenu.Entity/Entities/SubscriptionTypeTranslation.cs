using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_translation")]
    public class SubscriptionTypeTranslation : BaseEntity
    {
        [Required]
        public Guid SubscriptionTypeId { get; set; }

        [Required]
        public Guid CultureId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        public SubscriptionType SubscriptionType { get; set; }
        public Guid Culture { get; set; }
    }
}