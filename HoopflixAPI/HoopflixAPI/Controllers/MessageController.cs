using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoopflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository iMessageRepository;
        private readonly IVideoRepository iVideoRepository;
        private readonly IChatRepository iChatRepository;

        public MessageController(IMessageRepository iMessageRepository, IChatRepository iChatRepository, IVideoRepository iVideoRepository)
        {
            this.iMessageRepository = iMessageRepository;
            this.iChatRepository = iChatRepository;
            this.iVideoRepository = iVideoRepository;
        }
        [HttpGet("{chatid}")]
        public List<VideoMessage> GetMessagesFromCertainChat(int chatid)
        {
            return iMessageRepository.GetMessagesFromCertainChat(chatid);
        }
        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> CreateMessage([FromBody] Message message)
        {
            Video video = new Video();
            Chat chat = iChatRepository.GetChatByID(message.ChatID);
            if(chat == null)
            {
                return NotFound("");
            }
            if(message.Type == "Video")
            {
                video = iVideoRepository.GetVideoById(Convert.ToInt32(message.MessageContent));
            }
            if(video == null)
            {
                return NotFound("");
            }
            else
            {
                Message message1 = await iMessageRepository.CreateMessage(message);
                return Ok(message1);
            }
            
        }
        [HttpPut("{chatid}/{userid}")]
        public async Task SetMessagesToRead(int chatid, int userid)
        {
           await  iMessageRepository.SetMessagesToRead(chatid, userid);
            
        }
    }
}
