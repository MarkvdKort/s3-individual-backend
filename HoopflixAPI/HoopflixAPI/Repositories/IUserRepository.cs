using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task Delete(int id);
        int? GetByAuthId(string authid);
    }
}
