using HoopflixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Usercontext usercontext;
        public UserRepository(Usercontext usercontext)
        {
            this.usercontext = usercontext;
        }
        public async Task<User> Create(User user)
        {
            usercontext.Users.Add(user);
            await usercontext.SaveChangesAsync();
            return user;
        }
        public async Task Delete(int id)
        {
            var user = await usercontext.Users.FindAsync(id);
            usercontext.Users.Remove(user);
            await usercontext.SaveChangesAsync();            
        }
        public async Task<User> GetById(int id)
        {
            usercontext.Users.FirstOrDefault(x => x.ID == id);
            return await usercontext.Users.FindAsync(id);
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await usercontext.Users.ToListAsync();
        }
    }
}
