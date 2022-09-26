using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public class VideoRepository :IVideoRepository
    {
        private readonly VideoContext videoContext;
        public VideoRepository(VideoContext videoContext)
        {
            this.videoContext = videoContext;
        }
        public Video GetAllVideos()
        {
            Video videos = videoContext.Videos.FirstOrDefault();
            return videos;
        }
    }
}
