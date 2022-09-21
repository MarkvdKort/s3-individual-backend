using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewHistoryController : ControllerBase
    {
        private readonly IViewHistoryRepository iViewHistoryRepository;
        public ViewHistoryController(IViewHistoryRepository iViewHistoryRepository)
        {
            this.iViewHistoryRepository = iViewHistoryRepository;
        }
        [HttpGet("{id}")]
        public List<ViewHistory> GetLikesByID(int id)
        {
            return iViewHistoryRepository.GetViewHistoryFromUser(id);
        }
        [HttpDelete("{userid} {videoid}")]
        public async Task<ActionResult<ViewHistory>> DeleteViewHistory(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            await iViewHistoryRepository.Delete(userid, videoid);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<ViewHistory>> CreateLike([FromBody] ViewHistory viewHistory)
        {
            var newViewHistory = await iViewHistoryRepository.Create(viewHistory);
            return newViewHistory;
        }
    }
}
