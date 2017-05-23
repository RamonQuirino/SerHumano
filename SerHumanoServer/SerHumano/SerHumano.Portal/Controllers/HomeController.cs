using Microsoft.AspNetCore.Mvc;

namespace SerHumano.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}