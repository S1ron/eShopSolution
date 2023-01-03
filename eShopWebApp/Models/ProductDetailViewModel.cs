using eShopViewModels.Catalog.Categories;
using eShopViewModels.Catalog.ProductImages;
using eShopViewModels.Catalog.Products;

namespace eShopWebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryViewModel Category { get; set; }
        public ProductViewModel Product { get; set; }
        public List<ProductViewModel> RelatedProducts { get; set; }
        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
