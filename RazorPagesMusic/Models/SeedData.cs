using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMusicContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMusicContext>>()))
            {
                if (context == null || context.Song == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any song.
                if (context.Song.Any())
                {
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new Music
                    {
                        Title = "ACOL",
                        Artist = "Casey",
                        Genre = "Rock",
                        ReleaseDate = DateTime.Parse("1989-02-12"),
                        Rating = "Good"
                    },

                    new Music
                    {
                        Title = "Algonquin",
                        Artist = "Kyle",
                        Genre = "Country",
                        ReleaseDate = DateTime.Parse("1997-09-29"),
                        Rating = "Better"
                    },

                    new Music
                    {
                        Title = "Online",
                        Artist = "Leanne",
                        Genre = "Raggae",
                        ReleaseDate = DateTime.Parse("2015-08-09"),
                        Rating = "Good"
                    },

                    new Music
                    {
                        Title = "Brightspace",
                        Artist = "Breanna",
                        Genre = "Hip hop",
                        ReleaseDate = DateTime.Parse("2023-03-15"),
                        Rating = "Best"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
