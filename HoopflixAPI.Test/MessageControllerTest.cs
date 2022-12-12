using HoopflixAPI.Controllers;
using HoopflixAPI.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoopflixAPI.Test
{
    public class MessageControllerTest
    {
        [Fact]
        public async void GetMessagesFromCertainChat_Returns_Messages_When_Chat_Exists()
        {
            // Arrange
            var messageRepositoryMock = MockIMessageRepository.GetMock();
            var messageController = new MessageController(messageRepositoryMock.Object);

            // Act
            var request = messageController.GetMessagesFromCertainChat(1);

            // Assert
            Assert.NotNull(request);
        }
    }
}
