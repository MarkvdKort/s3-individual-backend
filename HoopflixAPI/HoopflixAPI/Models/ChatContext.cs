using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
: base(options)
        {

        }
        public DbSet<Chat> Chats { get; set; }
    }
}

