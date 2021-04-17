using System.Collections.Generic;

namespace DigitalMenu.Entity.DTOs
{
    public class MenuDTO
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}