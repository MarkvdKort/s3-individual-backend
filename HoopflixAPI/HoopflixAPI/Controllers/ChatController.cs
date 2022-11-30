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
        [HttpGet("{user1id}/{user2id}")]
        public Chat? GetCertainChat(int user1id, int user2id)
        {
            Chat chat = iChatRepository.GetCertainChat(user1id, user2id);
            if(chat == null)
            {
                return null;
            }
            return iChatRepository.GetCertainChat(user1id, user2id);
        }
        [HttpPost]
        public async Task<ActionResult<Chat>> CreateChat([FromBody] Chat chat)
        {
            await iChatRepository.CreateChat(chat);
            return chat;
        }
    }
}
