using HoopflixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoopflixAPI.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly LikeContext likeContext;
        public LikeRepository(LikeContext likeContext)
        {
            this.likeContext = likeContext;
        }
        public async Task<Like> Create(Like like)
        {
            likeContext.Likes.Add(like);
            await likeContext.SaveChangesAsync();
            return like;
        }
        public List<Like> GetLikesFromUser(int userid)
        {
            List<Like> likes = likeContext.Likes.Where(x => x.UserID == userid).ToList();
            return likes;
        }
        public async Task Delete(int id)
        {
            var like = await likeContext.Likes.FindAsync(id);
            likeContext.Likes.Remove(like);
            await likeContext.SaveChangesAsync();
        }
    }
}
