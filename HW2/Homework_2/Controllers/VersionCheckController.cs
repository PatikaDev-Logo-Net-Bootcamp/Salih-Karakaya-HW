using Microsoft.AspNetCore.Mvc;

namespace Homework_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionCheckController : ControllerBase
    {

        private readonly ILogger<VersionCheckController> _logger;

        public VersionCheckController(ILogger<VersionCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVersionCheck")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}