using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository IlikeRepository)
        {
            _likeRepository = IlikeRepository;
        }
        [HttpGet("{id}")]
        public List<Like> GetLikesFromUser(int id)
        {
            return _likeRepository.GetLikesFromUser(id);
        }
        [HttpGet("{userid} {videoid}")]
        public List<Like> GetCertainLike(int userid, int videoid)
        {
            return _likeRepository.GetCertainLike(userid,videoid);
        }
        [HttpDelete("{userid} {videoid}")]
        public async Task<ActionResult<Like>> DeleteLike(int userid, int videoid)
        {
            //var deleteBook = await likeRepository.get(id);
            //if (deleteBook == null)
            //{
            //    return NotFound();
            //}
            await _likeRepository.Delete(userid, videoid);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Like>> Create([FromBody] Like like)
        {
            var newUser = await _likeRepository.Create(like);
            return newUser;
        }
    }
}
