using System.Collections.Generic;

namespace DigitalMenu.Entity.DTOs
{
    public class MenuDTO
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string PriceColor { get; set; }
        public string CategoryDescriptionColor { get; set; }
        public string SelectedCategoryBorderColor { get; set; }
        public string ProductBackgroundColor { get; set; }
        public string LanguageCurrencyBackgroundColor { get; set; }
        public string LanguageCurrencyTextColor { get; set; }
        public string LinkColor { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}