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
    public class VideoControllertTests
    {
        [Fact]
        public async void User_Can_Get_List_Of_Brands()
        {
            // Arrange
            var videoRepositoryMock = MockIVideoRepository.GetMock();
            var brandController = new VideoController(videoRepositoryMock.Object);

            // Act
            var response =  brandController.GetAllVideos();


            // Assert
            Assert.IsAssignableFrom<List<Video>>(response);
            Assert.NotEmpty(response as List<Video>);
        }
    }
}
