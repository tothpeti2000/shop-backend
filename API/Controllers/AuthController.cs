using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;

        public AuthController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
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
        public async Task<ActionResult> LoginUser([FromBody] LoginCredentials data)
        {
            var result = await userService.LoginUser(data);

            if (result.Succeeded)
            {
                return Ok(result.Token);
            }

            return BadRequest(result.ErrorMessages);
        }
    }
}
