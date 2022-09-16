using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Models
{
    public class Usercontext :DbContext
    {
        public Usercontext(DbContextOptions<Usercontext> options)
            :base(options)
        {
           
        }
        public DbSet<User> Users { get; set; }
    }
}
