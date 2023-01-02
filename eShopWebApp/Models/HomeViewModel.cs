using eShopViewModels.Catalog.Products;
using eShopViewModels.Utilities.Slides;

namespace eShopWebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> Slides { set; get; }
        public List<ProductViewModel> FeaturedProducts { set; get; }
    }
}
