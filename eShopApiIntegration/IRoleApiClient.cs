using eShopViewModels.Common;
using eShopViewModels.System.Roles;

namespace eShopApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}
