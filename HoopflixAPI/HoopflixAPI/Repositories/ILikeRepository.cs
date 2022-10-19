using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface ILikeRepository
    {
        Task Delete(int userid, int videoid);
        List<Like> GetLikesFromUser(int userid);
        Task<Like> Create(Like like);
        List<Like> GetCertainLike(int userid, int videoid);
    }
}
