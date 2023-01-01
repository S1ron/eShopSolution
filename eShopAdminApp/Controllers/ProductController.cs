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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            //if (!ModelState.IsValid)
            //    return View(request);
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm mới sảm phẩm không thành công");
            return View(request);
        }
    }
}
