using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Data
{
    public class TestingWebAppRazorPagesContext : DbContext
    {
        public TestingWebAppRazorPagesContext (DbContextOptions<TestingWebAppRazorPagesContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;

        public DbSet<Producer> Producer { get; set; } = default!;

        public DbSet<ProducerAddress> ProducerAddress { get; set; } = default!;
    }
}
