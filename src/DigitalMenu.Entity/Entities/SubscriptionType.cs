using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription_type")]
    public class SubscriptionType : BaseEntity
    {
        [Required]
        public double Price { get; set; }
        public bool InTrialModel { get; set; }

        public List<SubscriptionTypeFeature> SubscriptionTypeFeature { get; set; }
    }
}