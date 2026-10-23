using Microsoft.AspNetCore.Mvc;

namespace AppVellum.Controllers
{
    public class ApplicationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
