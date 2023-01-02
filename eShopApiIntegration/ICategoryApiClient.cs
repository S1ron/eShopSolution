using eShopViewModels.Catalog.Categories;
using eShopViewModels.Common;

namespace eShopApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);
    }
}
