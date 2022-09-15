using Microsoft.AspNetCore.Mvc;

namespace WebHealthStatus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }


    }
}
