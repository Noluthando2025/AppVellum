using Microsoft.AspNetCore.Mvc;

namespace AppVellum.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
