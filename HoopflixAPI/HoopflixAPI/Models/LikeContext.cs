using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Models
{
    public class LikeContext : DbContext
    {
        public LikeContext(DbContextOptions<LikeContext> options)
    : base(options)
        {

        }
        public DbSet<Like> Likes { get; set; }
    }
}
