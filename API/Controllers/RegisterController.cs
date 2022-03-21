using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserService userService;

        public RegisterController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] User user)
        {
            var succeeded = await userService.CreateUser(user);

            if (succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
