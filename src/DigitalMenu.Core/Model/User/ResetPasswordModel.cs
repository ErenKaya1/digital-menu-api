using System;

namespace DigitalMenu.Core.Model.User
{
    public class ResetPasswordModel
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}