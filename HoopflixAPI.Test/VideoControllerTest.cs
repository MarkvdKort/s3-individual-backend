using HoopflixAPI.Controllers;
using HoopflixAPI.Models;
using HoopflixAPI.Test.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoopflixAPI.Test
{
    public class VideoControllerTest
    {
        [Fact]
        public async void GetVideoByID_Returns_Video_When_Exists()
        {
            // Arrange
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var videoController = new VideoController(videoRepositoryMock.Object);

            // Act
            var response = videoController.GetVideoById(1);


            // Assert
            Assert.NotNull(response);
            Assert.IsAssignableFrom<Video>(response);
        }
        [Fact]
        public async void GetVideoByID_Returns_Null_When_Video_Does_Not_Exists()
        {
            // Arrange
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var videoController = new VideoController(videoRepositoryMock.Object);

            // Act
            var response = videoController.GetVideoById(100);


            // Assert
            Assert.Null(response);
            //Assert.IsAssignableFrom<Video>(response);
        }
        [Fact]

        public async void Video_Is_Deleted_When_Exists()
        {
            // Arrange
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var videoController = new VideoController(videoRepositoryMock.Object);

            // Act
            var request = await videoController.DeleteVideo(1);
            var response = request.Result as ObjectResult;

            // Assert

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            //Assert.IsAssignableFrom<Video>(response);
        }
        [Fact]
        public async void Video_Is__Not_Deleted_When_Video_Does_Not_Exist()
        {
            // Arrange
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var videoController = new VideoController(videoRepositoryMock.Object);

            // Act
            var videosBeforeDelete = videoController.GetAllVideos();
            var request = await videoController.DeleteVideo(100);
            var videosafterDelete = videoController.GetAllVideos();

            // Assert
            Assert.Equal(videosBeforeDelete, videosafterDelete);
        }
    }
}