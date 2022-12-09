using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [HttpGet("/api/Video/Suggested/{player}/{team}/{id}")]
        public List<Video> GetSuggestedVideos(string player, string team, int id)
        {
            return iVideoRepository.GetSuggestedVideos(player,team, id);
        }
        [HttpDelete("{videoid}")]
        public async Task<ActionResult<HttpResponseMessage>> DeleteVideo(int videoid)
        {
            var video = iVideoRepository.GetVideoById(videoid);
            if (video == null)
            {
                return NotFound("");
            }
            return Ok(iVideoRepository.Delete(videoid));
        }
    }
}
