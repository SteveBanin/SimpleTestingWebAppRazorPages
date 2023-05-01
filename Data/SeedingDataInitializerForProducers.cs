using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Models;

namespace TestingWebAppRazorPages.Data
{
    public static class SeedingDataInitializerForProducers
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new TestingWebAppRazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TestingWebAppRazorPagesContext>>()))
            {
                if (context == null || context.Producer == null)
                {
                    throw new ArgumentNullException("Null TestingWebAppRazorPagesContext");
                }

                // Look for any Producer.
                if (context.Producer.Any())
                {
                    return;   // DB data has been seeded
                }

                context.Producer.AddRange(
                    new Producer
                    {
                        FirstName = " Thomas ",
                        LastName = "Lechmann ",
                        Category = "Action"
                    },

                    new Producer
                    {
                        FirstName = " Jones ",
                        LastName = "Woods",
                        Category = "Romance"
                    },

                    new Producer
                    {
                        FirstName = "Steve",
                        LastName = "Bans",
                        Category = "Horror"
                    },

                    new Producer
                    {
                        FirstName = "Markus",
                        LastName = "Buch",
                        Category = "Action"
                    },

                    new Producer
                    {
                        FirstName = "Larry",
                        LastName = "Stones",
                        Category = "Adventure"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
