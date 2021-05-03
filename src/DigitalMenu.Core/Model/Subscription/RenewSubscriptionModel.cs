using System;

namespace DigitalMenu.Core.Model.Subscription
{
    public class RenewSubscriptionModel
    {
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string CardMonth { get; set; }
        public string CardYear { get; set; }
        public string CardCvv { get; set; }
        public Guid SubscriptionTypeId { get; set; }
    }
}