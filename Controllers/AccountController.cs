using Microsoft.AspNetCore.Mvc;

namespace AppVellum.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}