
using AppVellum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppVellum.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppVellumDbContext _context;

        public ApplicationsController(AppVellumDbContext context)
        {
            _context = context;
        }

        // Display all applications
        public async Task<IActionResult> Index()
        {
            var applications = await _context.Applications
                .Include(a => a.Company)
                .ToListAsync();

            return View(applications);
        }

        // Display the Add Application form
        public async Task<IActionResult> Create()
        {
            ViewBag.Companies = await _context.Companies
                .OrderBy(c => c.CompanyName)
                .ToListAsync();

            return View();
        }

        // Process the submitted form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Application application)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Companies = await _context.Companies
                    .OrderBy(c => c.CompanyName)
                    .ToListAsync();

                return View(application);
            }

            // User identity must be configured before saving.
            return BadRequest(
                "User identity setup is required before saving applications.");
        }
    }
}
