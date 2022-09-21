using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;   
        public UserController(IUserRepository IuserRepository)
        {
            _userRepository = IuserRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID(int id)
        {
            return await _userRepository.GetById(id);
        }
        [HttpGet("{authid}")]
        public int GetUserIDByAuthID([FromBody] string authid)
        {
            return _userRepository.GetByAuthId(authid);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUserByID), new {id = newUser.ID}, newUser );
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var deleteBook = await _userRepository.GetById(id);
            if(deleteBook == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(deleteBook.ID);
            return NoContent();
        }
    }
}
