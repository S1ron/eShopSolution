using eShopViewModels.Catalog.Products;
using eShopViewModels.Common;

namespace eShopAdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);
    }
}
