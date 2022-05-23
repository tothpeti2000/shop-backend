using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartService cartService;

        public CartsController(CartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddItemToCart([FromBody] CartItemToAdd item)
        {
            var userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await cartService.AddItemToCart(item.ProductID, item.Amount, userID);

            return Ok();
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetCartItems()
        {
            var userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cartItems = await cartService.GetCartItems(userID);

            return Ok(cartItems);
        }

        [HttpGet("update/{cartItemID}")]
        public async Task<ActionResult> UpdateCartItemAmount(int cartItemID, [FromQuery] int amount)
        {
            await cartService.UpdateCartItemAmount(cartItemID, amount);
            return Ok();
        }

        [HttpGet("delete/{cartItemID}")]
        public async Task<ActionResult> DeleteCartItem(int cartItemID)
        {
            await cartService.DeleteCartItem(cartItemID);
            return Ok();
        }
    }
}
