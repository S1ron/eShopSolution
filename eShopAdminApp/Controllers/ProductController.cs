using eShopApiIntegration;
using eShopUtilities.Constants;
using eShopViewModels.Catalog.Products;
using eShopViewModels.Common;
using eShopViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShopAdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        
        public ProductController(IConfiguration configuration, IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;   
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefautLanguageId);
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageSize = pageSize,
                PageIndex = pageIndex,
                LanguageId = languageId,
                CategoryId = categoryId
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            var categories = await _categoryApiClient.GetAll(languageId);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value ==x.Id
            });
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

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequest = await GetCategoryAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetCategoryAssignRequest(request.Id);

            return View(roleAssignRequest);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefautLanguageId);
            var product = await _productApiClient.GetById(id, languageId);
            var editViewModel = new ProductUpdateRequest()
            {
                Id = product.Id,
                Description = product.Description,
                Details = product.Details,
                Name = product.Name,
                SeoAlias = product.SeoAlias,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle
            };
            return View(editViewModel);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        {
            //if (!ModelState.IsValid)
            //    return View(request);
            var result = await _productApiClient.UpdateProduct(request);
            if (result)
            {
                TempData["result"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật sảm phẩm không thành công");
            return View(request);
        }


        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefautLanguageId);

            var productObj = await _productApiClient.GetById(id, languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var category in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = category.Id.ToString(),
                    Name = category.Name,
                    Selected = productObj.Categories.Contains(category.Name)
                });
            }
            return categoryAssignRequest;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new ProductDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.DeleteProduct(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa người dùng thành công!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "xóa không thành công");
            return View(request);
        }
    }
}
