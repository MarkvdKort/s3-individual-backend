using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository iVideoRepository;
        public VideoController(IVideoRepository iVideoRepository)
        {
            this.iVideoRepository = iVideoRepository;
        }
        [HttpGet]
        public List<Video> GetAllVideos()
        {
            return iVideoRepository.GetAllVideos();
        }
        [HttpGet("{id}")]
        public Video GetVideoById(int id)
        {
            return iVideoRepository.GetVideoById(id);
        }
        [HttpGet("/Video/Liked/{userid}")]
        public List<Video> GetLikedVideos(int userid)
        {
            return iVideoRepository.GetAllLikedVideos(userid);
        }
        [HttpGet("/Video/MyList/{userid}")]
        public List<Video> GetAllVideosFromMyList(int userid)
        {
            return iVideoRepository.GetAllVideosFromMyList(userid);
        }
        [HttpGet("/api/Video/Suggested/{player}/{team}")]
        public List<Video> GetSuggestedVideos(string player, string team)
        {
            return iVideoRepository.GetSuggestedVideos(player,team);
        }
    }
}
