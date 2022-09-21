using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Models
{
    public class ViewHistoryContext :DbContext
    {
        public ViewHistoryContext(DbContextOptions<ViewHistoryContext> options)
: base(options)
        {

        }

        public DbSet<ViewHistory> ViewHistory { get; set; }
    }
}
