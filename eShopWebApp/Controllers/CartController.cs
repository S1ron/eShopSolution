using eShopApiIntegration;
using eShopUtilities.Constants;
using eShopViewModels.Sales;
using eShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;

namespace eShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            var itemadd = new CartItemViewModel() { ProductId = 0 };
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);  
            }
            if(currentCart.Any(x=>x.ProductId == id))
            {
                currentCart.Where(x => x.ProductId == id).ToList().ForEach(s => s.Quantity = s.Quantity+1);
            }
            else {
                var cartItem = new CartItemViewModel()
                {
                    ProductId = id,
                    Description = product.Description,
                    Name = product.Name,
                    Image = product.ThumbnailImage,
                    Price = product.Price,
                    Quantity = 1
                };
                currentCart.Add(cartItem);
            }
            HttpContext.Session.SetString(SystemConstants.CartSession,JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            var itemadd = new CartItemViewModel() { ProductId = 0 };
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }
            if (currentCart.Any(x => x.ProductId == id))
            {
                itemadd = currentCart.FirstOrDefault(x => x.ProductId == id);
                var tempQuantity = itemadd.Quantity + quantity;
                if (quantity != 0 && tempQuantity >= 1)
                {
                    currentCart.Where(x => x.ProductId == id).ToList().ForEach(s => s.Quantity = tempQuantity);
                }
                else
                {
                    currentCart.Remove(itemadd);
                }
            }
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(GetCheckoutViewModel());
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailViewModel>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailViewModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new CheckoutRequest()
            {
                Address = request.CheckoutModel.Address,
                Name = request.CheckoutModel.Name,
                Email = request.CheckoutModel.Email,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                OrderDetails = orderDetails
            };
            var culture = CultureInfo.CurrentCulture;
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect($"/{culture}/Account/Login");
            }
            var result = _orderApiClient.CreateOrder(checkoutRequest);
            if (result==null)
            {
                return View(model);
            }
            TempData["SuccessMsg"] = "Order puschased successful";
            return View(model);
        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutVm;
        }
    }
}
