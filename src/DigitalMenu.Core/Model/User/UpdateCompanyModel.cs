using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Core.Model.User
{
    public class UpdateCompanyModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public IFormFile LogoFile { get; set; }
    }
}