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
        public Video GetAllVideos()
        {
            return iVideoRepository.GetAllVideos();
        }
    }
}
