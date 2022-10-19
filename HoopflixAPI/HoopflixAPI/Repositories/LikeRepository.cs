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
        public async Task Delete(int userid, int videoid)
        {
            var like = likeContext.Likes.First(x=> x.UserID == userid && x.VideoID == videoid);
            likeContext.Likes.Remove(like);
            await likeContext.SaveChangesAsync();
        }
        public List<Like> GetCertainLike(int userid, int videoid)
        {
            List<Like> likes = likeContext.Likes.Where(x => x.UserID == userid && x.VideoID == videoid).ToList();
            if(likes.Count == 0)
            {
                return null;
            }
            return likes;
        }
    }
}
