using Microsoft.AspNetCore.Mvc;

namespace Jungle_Web.Areas.Counselor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
