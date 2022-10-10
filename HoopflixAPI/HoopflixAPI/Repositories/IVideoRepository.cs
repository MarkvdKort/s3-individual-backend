using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetAllVideos();
        Video GetVideoById(int id);
        List<Video> GetAllLikedVideos(int userid);
        List<Video> GetAllVideosFromMyList(int userid);
    }
}
