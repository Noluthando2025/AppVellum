
using AppVellum.Models;
using AppVellum.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppVellum.Controllers
{
    // Handles user registration, authentication and logout.
    public class AccountController : Controller
    {
        // UserManager handles creating and managing user accounts.
        private readonly UserManager<ApplicationUser> _userManager;

        // SignInManager handles signing users in and out.
        private readonly SignInManager<ApplicationUser> _signInManager;

        // Inject Identity services through the controller constructor.
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Displays the registration page.
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Processes the registration form submitted by a new user.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Check that all submitted registration details are valid.
            if (!ModelState.IsValid)
                return View(model);

            // Create a new user using the information supplied in the form.
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            // Create the account and securely hash the user's password.
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Automatically sign in the user after successful registration.
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            // Display any account creation errors on the registration page.
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // Displays the login page.
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Processes the login form submitted by an existing user.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Validate the submitted email and password fields.
            if (!ModelState.IsValid)
                return View(model);

            // Verify the user's credentials using ASP.NET Core Identity.
            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Redirect the authenticated user to the dashboard.
                return RedirectToAction("Index", "Home");
            }

            // Show a general error without revealing which credential was incorrect.
            ModelState.AddModelError(string.Empty, "Invalid email or password.");

            return View(model);
        }

        // Signs the authenticated user out of AppVellum.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            // Return the user to the home page after logout.
            return RedirectToAction("Index", "Home");
        }
    }
}
