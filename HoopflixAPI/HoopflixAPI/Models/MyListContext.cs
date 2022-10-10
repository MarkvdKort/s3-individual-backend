using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Models
{
    public class MyListContext : DbContext
    {
        public MyListContext(DbContextOptions<MyListContext> options)
: base(options)
        {

        }

        public DbSet<MyList> MyList { get; set; }
    }
}
