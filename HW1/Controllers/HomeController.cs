using Microsoft.AspNetCore.Mvc;
using SampleLogin.Models;
using System.Diagnostics;

namespace SampleLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] LoginViewModel loginViewModel)
        {

            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            return Ok(
                getSuccessLoginResponse()
            );
        }

        private static LoginResponse getErrorLoginResponse()
        {
            return new LoginResponse
            {
                Success = false,
                Data = "Giriş İşlemi Başarısız"
            };
        }

        private static LoginResponse getSuccessLoginResponse()
        {
            return new LoginResponse
            {
                Success = true,
                Data = "Giriş işlemi başarılı "
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}