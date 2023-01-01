using eShopViewModels.Catalog.Categories;
using eShopViewModels.Common;

namespace eShopAdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);
    }
}
