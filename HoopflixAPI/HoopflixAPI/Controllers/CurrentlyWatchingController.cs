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
        [HttpGet("{userid}")]
        public List<CurrentlyWatching> GetCurrentlyWatchingsByID(int userid)
        {
            return currentlyWatchingRepository.GetCurrentlyWatchingsFromUser(userid);
        }
        [HttpDelete("{userid} {videoid}")]
        public async Task<ActionResult<CurrentlyWatching>> DeleteCurrentlyWatching(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            await currentlyWatchingRepository.Delete(userid, videoid);
            return NoContent();
        }
        [HttpGet("{userid} {videoid}")]
        public CurrentlyWatching GetCertainCurrentlyWatching(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            CurrentlyWatching currentlyWatching = currentlyWatchingRepository.GetCertainCurrentlyWatching(userid, videoid);
            return currentlyWatching;
        }
        [HttpPost]
        public async Task<ActionResult<CurrentlyWatching>> CreateCurrentlyWatching([FromBody] CurrentlyWatching currentlyWatching)
        {
            var newUser = await currentlyWatchingRepository.Create(currentlyWatching);
            return null;
        }
    }
}
