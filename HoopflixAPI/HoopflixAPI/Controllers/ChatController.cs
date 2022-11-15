using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository iChatRepository;
        public ChatController(IChatRepository iChatRepository)
        {
            this.iChatRepository = iChatRepository;
        }
        [HttpGet("{userid}")]
        public List<Chat> GetChatsFromUser(int userid)
        {
            return iChatRepository.GetChatsFromUser(userid);
        }
        [HttpPost]
        public async Task<ActionResult<Chat>> CreateChat([FromBody] Chat chat)
        {
            await iChatRepository.CreateChat(chat);
            return null;
        }
    }
}
