using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface ILikeRepository
    {
        Task Delete(int id);
        List<Like> GetLikesFromUser(int userid);
        Task<Like> Create(Like like);
    }
}
