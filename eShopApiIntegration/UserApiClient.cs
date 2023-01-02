using eShopViewModels.Common;
using eShopViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace eShopApiIntegration
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserApiClient(IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //var response = await client.PostAsync("/api/users/authenticate", httpContent);
            //if (response.IsSuccessStatusCode)
            //{
            //    return JsonConvert.DeserializeObject<ApiSuccessResult<string>>( await response.Content.ReadAsStringAsync());
            //}
            //return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync());

            return await PostAsync<string, LoginRequest>($"/api/users/authenticate", request);
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/users/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/users/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<UserViewModel>>(body);
            return JsonConvert.DeserializeObject<ApiErrorResult<UserViewModel>>(body);
        }

        public async Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/Users/paging?PageIndex=" +
                $"{request.PageIndex}&PageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<UserViewModel>>>(body);
            return users;
        }

        public async Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest)
        {
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //var json = JsonConvert.SerializeObject(registerRequest);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync($"/api/users", httpContent);
            //var result = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //    return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            //return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
            return await PostAsync<bool, RegisterRequest>($"/api/users", registerRequest);
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync($"/api/users/{id}/roles", httpContent);
            //var result = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //    return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            //return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
            return await PutAsync<bool, RoleAssignRequest>($"/api/users/{id}/roles", request);
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync($"/api/users/{id}", httpContent);
            //var result = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //    return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            //return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);

            return await PutAsync<bool, UserUpdateRequest>($"/api/users/{id}", request);
        }
    }
}
