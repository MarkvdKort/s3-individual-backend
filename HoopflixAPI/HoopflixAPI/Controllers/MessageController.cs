﻿using HoopflixAPI.Models;
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
        public MessageController(IMessageRepository iMessageRepository)
        {
            this.iMessageRepository = iMessageRepository;
        }
        [HttpGet("{chatid}")]
        public List<VideoMessage> GetMessagesFromCertainChat(int chatid)
        {
            return iMessageRepository.GetMessagesFromCertainChat(chatid);
        }
        [HttpPost]
        public async Task<ActionResult<Message>> CreateChat([FromBody] Message message)
        {
            Message message1 = await iMessageRepository.CreateMessage(message);
            return message1;
        }
        [HttpPut("{chatid}/{userid}")]
        public async Task SetMessagesToRead(int chatid, int userid)
        {
           await  iMessageRepository.SetMessagesToRead(chatid, userid);
            
        }
    }
}