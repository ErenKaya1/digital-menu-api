using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.User
{
    public class UpdateProfileModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanySlug { get; set; }
        public IFormFile CompanyImageFile { get; set; }
    }
}