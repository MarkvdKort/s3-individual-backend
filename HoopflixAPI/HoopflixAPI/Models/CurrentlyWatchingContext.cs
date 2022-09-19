using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Models
{
    public class CurrentlyWatchingContext : DbContext
    {
        public CurrentlyWatchingContext(DbContextOptions<CurrentlyWatchingContext> options)
        : base(options)
        {

        }

        public DbSet<CurrentlyWatching> CurrentlyWatching { get; set; }
    }
}
