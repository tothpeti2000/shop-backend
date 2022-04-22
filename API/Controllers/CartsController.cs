using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly TokenHandler tokenHandler;

        public CartsController(TokenHandler tokenHandler)
        {
            this.tokenHandler = tokenHandler;
        }

        [HttpPost("add/{cartID}")]
        public async Task<ActionResult> AddItemToCart(int cartID)
        {
            var header = HttpContext.Request.Headers.Authorization;
            var userID = tokenHandler.GetUserIDFromHeader(header);
            return Ok();
        }
    }
}
