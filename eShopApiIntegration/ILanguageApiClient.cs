using eShopViewModels.Common;
using eShopViewModels.System.Languages;

namespace eShopApiIntegration
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}
