using eShopViewModels.Sales;
using eShopWebApp.Controllers;

namespace eShopWebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public CheckoutRequest CheckoutModel { get; set; }
    }
}
