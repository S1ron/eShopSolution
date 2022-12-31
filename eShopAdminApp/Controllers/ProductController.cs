using eShopAdminApp.Services;
using eShopUtilities.Constants;
using eShopViewModels.Catalog.Products;
using eShopViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace eShopAdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public ProductController(IConfiguration configuration, IProductApiClient productApiClient)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;   
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefautLanguageId);
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageSize = pageSize,
                PageIndex = pageIndex,
                LanguageId = languageId
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
    }
}
