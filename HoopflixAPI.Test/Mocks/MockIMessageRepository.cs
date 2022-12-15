using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoopflixAPI.Test.Mocks
{
    public class MockIMessageRepository
    {
        public static Mock<IMessageRepository> GetMock()
        {
            var mock = new Mock<IMessageRepository>();
            List<VideoMessage> videoMessages = new List<VideoMessage>()
            {
                new VideoMessage()
                {
                    Message = new Message()
                    {
                        ID = 1,
                        ChatID = 1,
                        UserID = 1,
                        MessageContent = "1",
                        Time = DateTime.Now.ToString(),
                        New = 1, 
                        Type="Video"

                    },
                    Video = new Video()
                    {
                        ID = 1,
                        Name = "Test1",
                        Description = "description",
                        Era = "2020",
                        Paths = "path",
                        Play = "play",
                        Player = "player",
                        Team = "team",
                        Thumbnail = "thumbnail"
                    }
                    


                },
            };
            List<Message> Messages = new List<Message>()
            {
                new Message()
                {
                        ID = 1,
                        ChatID = 1,
                        UserID = 1,
                        MessageContent = "1",
                        Time = DateTime.Now.ToString(),
                        New = 1,
                        Type="Video"
                },
            };

            mock.Setup(m => m.GetMessagesFromCertainChat(It.IsAny<int>()))
                .Returns((int id) => videoMessages.Where(o => o.Message.ChatID == id).ToList());
            mock.Setup(m => m.CreateMessage(It.IsAny<Message>()))
                .Callback(() => { return; });

            return mock;
        }
    }
}
