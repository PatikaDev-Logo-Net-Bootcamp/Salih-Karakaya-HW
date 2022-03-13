using Homework_2.Domain.Login;
using Microsoft.AspNetCore.Mvc;

namespace Homework_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {

        [HttpPost("Register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost("SignIn")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult SignIn()
        {
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            return Ok();
        }

        [HttpPost("Logout")]
        public IActionResult Logout([FromBody] LoginDto request)
        {
            return Ok();
        }
    }
}
