using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetAllVideos();
        Video GetVideoById(int id);
        List<Video> GetAllLikedVideos(int userid);
        List<Video> GetAllVideosFromMyList(int userid);
        List<Video> GetSuggestedVideos(string player, string team, int id);
        Task Delete(int videoID);
    }
}
