using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyListController : ControllerBase
    {
        private readonly IMylistRepository MyListRepository;
        public MyListController(IMylistRepository MyListRepository)
        {
            this.MyListRepository = MyListRepository;
        }
        [HttpGet("{userid}")]
        public List<MyList> GetMyListFromUser(int userid)
        {
            return MyListRepository.GetListFromUser(userid);
        }
        [HttpDelete("{userid} {videoid}")]
        public async Task<ActionResult<CurrentlyWatching>> DeleteFromList(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            await MyListRepository.Delete(userid, videoid);
            return NoContent();
        }
        [HttpGet("{userid} {videoid}")]
        public MyList GetCertainItemFromList(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            MyList myList = MyListRepository.GetCertainItemFromList(userid, videoid);
            return myList;
        }
        [HttpPost]
        public async Task<ActionResult<MyList>> AddToMyList([FromBody] MyList myList)
        {
            var newUser = await MyListRepository.AddToMyList(myList);
            return null;
        }
    }
}
