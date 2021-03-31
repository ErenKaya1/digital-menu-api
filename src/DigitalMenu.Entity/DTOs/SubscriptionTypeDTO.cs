using System;
using System.Collections.Generic;

namespace DigitalMenu.Entity.DTOs
{
    public class SubscriptionTypeDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public List<SubscriptionTypeFeatureDTO> Features { get; set; }
    }
}