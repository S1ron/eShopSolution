using eShopViewModels.System.Languages;

namespace eShopAdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageViewModel> Languages { set; get; }
        public string CurrentLanguageId { get; set; }
        public string ReturnUrl { get; set; }
    }
}
