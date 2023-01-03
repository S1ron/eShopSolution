using eShopViewModels.Catalog.Categories;
using eShopViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace eShopApiIntegration 
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

        public async Task<CategoryViewModel> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryViewModel>($"/api/categories/{languageId}/{id}");
        }
    }
}
