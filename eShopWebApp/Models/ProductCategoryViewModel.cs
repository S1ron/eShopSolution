using eShopViewModels.Catalog.Categories;
using eShopViewModels.Catalog.Products;
using eShopViewModels.Common;

namespace eShopWebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryViewModel Category { get; set; }
        public PagedResult<ProductViewModel> Products { get; set; }
    }
}
