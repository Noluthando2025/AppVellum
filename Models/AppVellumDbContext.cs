
using Microsoft.EntityFrameworkCore;

namespace AppVellum.Models
{
    public class AppVellumDbContext : DbContext
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
