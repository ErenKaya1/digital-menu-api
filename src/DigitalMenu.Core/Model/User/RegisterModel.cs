using System;

namespace DigitalMenu.Core.Model.User
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        //public Guid SubscriptionTypeId { get; set; }
    }
}