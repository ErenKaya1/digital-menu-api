using System;
using DigitalMenu.Entity.Enum;

namespace DigitalMenu.Entity.DTOs
{
    public class SubscriptionDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public bool IsTrialMode { get; set; }
        public bool IsSubscriptionReminderMailSent { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}