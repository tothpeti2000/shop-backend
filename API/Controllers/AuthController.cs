using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;
        private readonly TokenHandler tokenHandler;

        public AuthController(UserService userService, TokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegisterUser([FromBody] User user)
        {
            var result = await userService.CreateUser(user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessages);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LoginUser([FromBody] LoginCredentials data)
        {
            var result = await userService.LoginUser(data);

            if (result.Succeeded)
            {
                var token = tokenHandler.GenerateJWTToken(result.Payload);
                return Ok(token);
            }

            return BadRequest(result.ErrorMessages);
        }

        [HttpGet("logout")]
        public async Task<ActionResult> LogoutUser()
        {
            var userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //await userService.LogoutUser(userID);

            return Ok();
        }
    }
}
