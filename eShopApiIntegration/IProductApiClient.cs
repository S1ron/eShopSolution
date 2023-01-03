using eShopViewModels.Catalog.Products;
using eShopViewModels.Common;

namespace eShopApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ProductViewModel> GetById(int id, string languageId);
        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);
        Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);
    }
}
