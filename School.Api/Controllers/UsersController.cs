using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Core.Services;
using School.Core.Dtos.Requests.Auth;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private UsersServices usersService { get; set; }

        public UsersController(UsersServices usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest payload)
        {
            await usersService.RegisterAsync(payload);
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest payload)
        {
            var response = await usersService.LoginAsync(payload);

            return Ok(response);
        }
    }
}
