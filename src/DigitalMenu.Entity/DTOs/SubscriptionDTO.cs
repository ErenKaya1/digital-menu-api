using System;
using DigitalMenu.Common.Enum;

namespace DigitalMenu.Entity.DTOs
{
    public class SubscriptionDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public bool IsExpired { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsTrialMode { get; set; }
        public bool IsSubscriptionReminderMailSent { get; set; }
        public Guid? SubscriptionTypeId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}