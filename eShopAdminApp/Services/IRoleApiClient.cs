using eShopViewModels.Common;
using eShopViewModels.System.Roles;

namespace eShopAdminApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}
