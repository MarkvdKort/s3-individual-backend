using HoopflixAPI.Models;
using HoopflixAPI.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoopflixAPI.Test.Mocks
{
    internal class MockIChatRepository
    {
        public static Mock<IChatRepository> GetMock()
        {
            var mock = new Mock<IChatRepository>();
            List<Chat> chats = new List<Chat>()
            {
                new Chat()
                {
                        ID = 1,
                        User1ID = 1,
                        User2ID = 1,
                },
            };

            mock.Setup(m => m.GetChatByID(It.IsAny<int>()))
                .Returns((int id) => chats.FirstOrDefault(o => o.ID == id));

            return mock;
        }
    }
}