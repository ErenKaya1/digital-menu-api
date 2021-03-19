using System;

namespace DigitalMenu.Entity.DTOs
{
    public class ResetPasswordTokenDTO
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}