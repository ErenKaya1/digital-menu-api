﻿using DigitalMenu.Entity.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Entity.Entities
{
    [Table("subscription")]
    public class Subscription : BaseEntity
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public bool IsTrialMode { get; set; }

        [Required]
        public bool IsSuspended { get; set; }

        [Required]
        public bool IsCurrent { get; set; }

        [Required]
        public bool IsSubscriptionReminderMailSent { get; set; }

        public Guid? SubscriptionTypeId { get; set; }
        public bool IsExpired => DateTime.UtcNow.Date >= EndDate.Date;

        public DMUser User { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}