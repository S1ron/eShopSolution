using eShopViewModels.System.Users;

namespace eShopAdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

    }
}
