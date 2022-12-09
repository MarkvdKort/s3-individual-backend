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
    public class MockIVideoRepository
    {
        public static Mock<IVideoRepository> GetMock()
        {
            var mock = new Mock<IVideoRepository>();
            List<Video> videos = new List<Video>()
            {
                new Video()
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

                },
            };



            mock.Setup(m => m.GetAllVideos())
                 .Returns(() => (videos));
            mock.Setup(m => m.GetVideoById(It.IsAny<int>()))
                .Returns((int id) => videos.FirstOrDefault(o => o.ID == id));

            //mock.Setup(m => m.CreateBrand(It.IsAny<Brand>()))
            //     .Callback(() => { return; });



            return mock;
        }
    }
}
