using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Models;

namespace TestingWebAppRazorPages.Data
{
    public static class SeedingDataInitializer
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new TestingWebAppRazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TestingWebAppRazorPagesContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null TestingWebAppRazorPagesContext");
                }

                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB data has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        MovieTitle = "The Dark Man",
                        MovieCategory = "Action",
                        MovieDuration = new TimeSpan(02, 05, 30),
                        MovieRelaesedDate = new DateTime(2018, 10, 10),
                    },

                    new Movie
                    {
                        MovieTitle = "Hull Mark",
                        MovieCategory = "Adventure",
                        MovieDuration = new TimeSpan(01, 45, 30),
                        MovieRelaesedDate = new DateTime(2019, 06, 10),
                    },

                    new Movie
                    {
                        MovieTitle = "Ghost House",
                        MovieCategory = "Horror",
                        MovieDuration = new TimeSpan(01, 35, 50),
                        MovieRelaesedDate = new DateTime(2020, 04, 11),
                    },

                    new Movie
                    {
                        MovieTitle = "Hard Way",
                        MovieCategory = "Action",
                        MovieDuration = new TimeSpan(01, 45, 30),
                        MovieRelaesedDate = new DateTime(2021, 02, 10),
                    },

                    new Movie
                    {
                        MovieTitle = "Brave Driver",
                        MovieCategory = "Action",
                        MovieDuration = new TimeSpan(02, 25, 30),
                        MovieRelaesedDate = new DateTime(2022, 09, 10),
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
