using eShopViewModels.Common;
using eShopViewModels.System.Languages;

namespace eShopAdminApp.Services
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}
