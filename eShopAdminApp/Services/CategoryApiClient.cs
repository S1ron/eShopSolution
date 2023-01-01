using eShopViewModels.Catalog.Categories;
using eShopViewModels.Common;

namespace eShopAdminApp.Services
{
    public class CategoryApiClient : BaseApiClient ,ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory, 
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor):base(httpClientFactory, configuration, httpContextAccessor)
        {
            
        }
        public async Task<List<CategoryViewModel>> GetAll(string languageId)
        {
            return await GetListAsync<CategoryViewModel>("/api/categories?languageId="+languageId);
        }

    }
}
