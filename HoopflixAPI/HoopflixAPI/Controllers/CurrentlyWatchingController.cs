using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentlyWatchingController : ControllerBase
    {
        private readonly ICurrentlyWatchingRepository currentlyWatchingRepository;
        public CurrentlyWatchingController(ICurrentlyWatchingRepository currentlyWatchingRepository)
        {
            this.currentlyWatchingRepository = currentlyWatchingRepository;
        }
        [HttpGet("{id}")]
        public List<CurrentlyWatching> GetLikesByID(int id)
        {
            return currentlyWatchingRepository.GetCurrentlyWatchingsFromUser(id);
        }
        [HttpDelete("{userid} {videoid}")]
        public async Task<ActionResult<Like>> DeleteCurrentlyWatching(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            await currentlyWatchingRepository.Delete(userid, videoid);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<CurrentlyWatching>> CreateLike([FromBody] CurrentlyWatching currentlyWatching)
        {
            var newUser = await currentlyWatchingRepository.Create(currentlyWatching);
            return null;
        }
    }
}
