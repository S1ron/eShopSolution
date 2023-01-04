using eShopApplication.Catalog.Orders;
using eShopViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShopBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckoutRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _orderService.Create(userId, request);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Khong thanh cong");
        }

    }
}
