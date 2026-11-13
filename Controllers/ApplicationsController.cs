
using AppVellum.Models;
using AppVellum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppVellum.Controllers
{
    // Only authenticated users can access application records.
    [Authorize]
    public class ApplicationsController : Controller
    {
        private readonly AppVellumDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationsController(
            AppVellumDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Displays only the applications belonging to the logged-in user.
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var applications = await _context.Applications
                .Include(a => a.Company)
                .Where(a => a.UserId == userId)
                .ToListAsync();

            return View(applications);
        }

        // Displays the form for creating a new application.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Saves a new application and links it to the correct company.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Remove unnecessary spaces from the company name.
            var companyName = model.CompanyName.Trim();

            // Check whether the company already exists.
            var company = await _context.Companies
                .FirstOrDefaultAsync(c =>
                    c.CompanyName.ToLower() == companyName.ToLower());

            // Create a company record if it does not exist.
            if (company == null)
            {
                company = new Company
                {
                    CompanyName = companyName
                };

                _context.Companies.Add(company);
            }

            // Create the application and assign it to the logged-in user.
            var application = new Application
            {
                UserId = _userManager.GetUserId(User)!,
                Company = company,
                JobTitle = model.JobTitle,
                Status = model.Status,
                DateApplied = model.DateApplied,
                ApplicationDeadline = model.ApplicationDeadline,
                InterviewDate = model.InterviewDate,
                FollowUpDate = model.FollowUpDate,
                JobType = model.JobType,
                Location = model.Location,
                ApplicationLink = model.ApplicationLink,
                Notes = model.Notes
            };

            _context.Applications.Add(application);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
    }

