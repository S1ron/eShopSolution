using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShopBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCurrentUserId()
        {
            var id = HttpContext.User.FindFirstValue("id");
            return Ok(new { userId = id });
        }
    }
}
