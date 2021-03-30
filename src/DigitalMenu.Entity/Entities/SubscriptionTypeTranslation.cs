using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;
using Newtonsoft.Json;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type_translation")]
    public class SubscriptionTypeTranslation : BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        [JsonIgnore]
        public override Guid Id { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public Guid CultureId { get; set; }

        [JsonIgnore]
        public Guid SubscriptionTypeId { get; set; }

        public Culture Culture { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}