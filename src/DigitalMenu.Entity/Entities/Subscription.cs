using DigitalMenu.Entity.Entities.Base;
using DigitalMenu.Entity.Enum;
using System;

namespace DigitalMenu.Entity.Entities
{
    public class Subscription : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool InTrialModel { get; set; }
        public Guid UserId { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }

        public DMUser User { get; set; }
    }
}