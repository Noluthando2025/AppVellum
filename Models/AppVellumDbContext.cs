using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppVellum.Models
{
    public class AppVellumDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppVellumDbContext(
            DbContextOptions<AppVellumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}