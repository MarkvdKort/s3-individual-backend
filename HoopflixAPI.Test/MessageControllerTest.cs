using HoopflixAPI.Controllers;
using HoopflixAPI.Models;
using HoopflixAPI.Test.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var chatRepositoryMock = MockIChatRepository.GetMock();
            var messageController = new MessageController(messageRepositoryMock.Object, chatRepositoryMock.Object, videoRepositoryMock.Object);

            // Act
            var request = messageController.GetMessagesFromCertainChat(1);

            // Assert
            Assert.NotNull(request);
        }
        [Fact]
        public async void GetMessagesFromCertainChat_Returns_Null_When_Chat_Does_Not_Exist()
        {
            // Arrange
            var messageRepositoryMock = MockIMessageRepository.GetMock();
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var chatRepositoryMock = MockIChatRepository.GetMock();
            var messageController = new MessageController(messageRepositoryMock.Object, chatRepositoryMock.Object, videoRepositoryMock.Object);

            // Act
            var request = messageController.GetMessagesFromCertainChat(10);

            // Assert
            Assert.Equal(0, request.Count());
        }
        [Fact]
        public async void CreateMessage_Returns_Error_When_Video_Does_Not_Exist()
        {
            // Arrange
            var messageRepositoryMock = MockIMessageRepository.GetMock();
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var chatRepositoryMock = MockIChatRepository.GetMock();
            var messageController = new MessageController(messageRepositoryMock.Object, chatRepositoryMock.Object, videoRepositoryMock.Object);
            Message message = new Message()
            {
                ChatID = 1,
                ID = 2,
                Type = "Video",
                UserID = 1,
                MessageContent = "100",
                New = 1,
                Time = DateTime.Now.ToString()
            };
            // Act
            var request = await messageController.CreateMessage(message);
            var response = request.Result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, response.StatusCode);
        }
        [Fact]
        public async void CreateMessage_Returns_Error_When_Chat_Does_Not_Exist()
        {
            // Arrange
            var messageRepositoryMock = MockIMessageRepository.GetMock();
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var chatRepositoryMock = MockIChatRepository.GetMock();
            var messageController = new MessageController(messageRepositoryMock.Object, chatRepositoryMock.Object, videoRepositoryMock.Object);
            Message message = new Message()
            {
                ChatID = 100,
                ID = 2,
                Type = "Video",
                UserID = 1,
                MessageContent = "1",
                New = 1,
                Time = DateTime.Now.ToString()
            };
            // Act
            var request = await messageController.CreateMessage(message);
            var response = request.Result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, response.StatusCode);
        }
        [Fact]
        public async void CreateMessage_Returns_Error_When_Both_Chat_And_Video_Do_Not_Exist()
        {
            // Arrange
            var messageRepositoryMock = MockIMessageRepository.GetMock();
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var chatRepositoryMock = MockIChatRepository.GetMock();
            var messageController = new MessageController(messageRepositoryMock.Object, chatRepositoryMock.Object, videoRepositoryMock.Object);
            Message message = new Message()
            {
                ChatID = 100,
                ID = 2,
                Type = "Video",
                UserID = 1,
                MessageContent = "100",
                New = 1,
                Time = DateTime.Now.ToString()
            };
            // Act
            var request = await messageController.CreateMessage(message);
            var response = request.Result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, response.StatusCode);
        }
    }
}