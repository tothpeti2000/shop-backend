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

        public ActionResult RegisterUser(User user)
        {
            userService.CreateUser();
        }
    }
}
