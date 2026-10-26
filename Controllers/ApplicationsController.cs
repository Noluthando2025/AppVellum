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

        public async Task<IActionResult> Index()
        {
            var applications = await _context.Applications
                .Include(a => a.Company)
                .ToListAsync();

            return View(applications);
        }
    }
}