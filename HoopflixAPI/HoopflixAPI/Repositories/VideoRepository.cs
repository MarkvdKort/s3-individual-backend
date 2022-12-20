using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public class VideoRepository :IVideoRepository
    {
        private readonly VideoContext videoContext;
        private readonly LikeContext likeContext;
        private readonly MyListContext myListContext;
        private readonly CurrentlyWatchingContext currentlyWatchingContext;
        private readonly ViewHistoryContext viewHistoryContext;
        private readonly MessageContext messageContext;
        public VideoRepository(VideoContext videoContext, LikeContext likeContext, MyListContext myListContext, CurrentlyWatchingContext currentlyWatchingContext, ViewHistoryContext viewHistoryContext, MessageContext messageContext)
        {
            this.videoContext = videoContext;
            this.likeContext = likeContext;
            this.myListContext = myListContext;
            this.currentlyWatchingContext = currentlyWatchingContext;
            this.viewHistoryContext = viewHistoryContext;
            this.messageContext = messageContext;
        }
        public List<Video> GetAllVideos()
        {
            List<Video> videos = videoContext.Videos.ToList();
            return videos;
        }
        public Video GetVideoById(int id)
        {
            Video video = videoContext.Videos.First(x => x.ID == id);
            return video;

        }
        public List<Video> GetAllLikedVideos(int userid)
        {
            List<Video> LikedVideos = new List<Video>();
            List<Video> videos = videoContext.Videos.ToList();
            List<Like> likes = likeContext.Likes.ToList();
            var data = from l in likes
                       where l.UserID == userid
                       join v in videos
                       on l.VideoID equals v.ID
                       select new 
                       {
                           v.ID,
                           v.Name,
                           v.Description,
                           v.Play,
                           v.Player,
                           v.Paths,
                           v.Thumbnail,
                           v.Era,
                           v.Team
                       };
            foreach (var item in data)
            {
                Video video = new Video()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    Play = item.Play,
                    Player = item.Player,
                    Paths = item.Paths,
                    Thumbnail = item.Thumbnail,
                    Era = item.Era,
                    Team = item.Team
                };
                LikedVideos.Add(video);
            }
            return LikedVideos;
        }
        public List<Video> GetAllVideosFromMyList(int userid)
        {
            List<Video> LikedVideos = new List<Video>();
            List<Video> videos = videoContext.Videos.ToList();
            List<MyList> myList = myListContext.MyList.ToList();
            var data = from m in myList
                       where m.UserID == userid
                       join v in videos
                       on m.VideoID equals v.ID
                       select new
                       {
                           v.ID,
                           v.Name,
                           v.Description,
                           v.Play,
                           v.Player,
                           v.Paths,
                           v.Thumbnail,
                           v.Era,
                           v.Team
                       };
            foreach (var item in data)
            {
                Video video = new Video()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    Play = item.Play,
                    Player = item.Player,
                    Paths = item.Paths,
                    Thumbnail = item.Thumbnail,
                    Era = item.Era,
                    Team = item.Team
                };
                LikedVideos.Add(video);
            }
            return LikedVideos;
        }
        public List<Video> GetSuggestedVideos(string player, string team, int id)
        {
            List<Video> videos = videoContext.Videos.Where(x => (x.Player == player || x.Team == team) && x.ID != id).ToList();
            return videos;
        }
        public async Task Delete(int videoID)
        {
            var video = videoContext.Videos.FirstOrDefault(x => x.ID == videoID);
            List<CurrentlyWatching> currentlyWatchings = currentlyWatchingContext.CurrentlyWatching.Where(x => x.VideoID == videoID).ToList();
            List<MyList> myLists = myListContext.MyList.Where(x => x.VideoID == videoID).ToList();
            List<Like> likes = likeContext.Likes.Where(x => x.VideoID == videoID).ToList();
            List<ViewHistory> viewHistories = viewHistoryContext.ViewHistory.Where(x => x.VideoID == videoID).ToList();
            List<Message> messages = messageContext.Messages.Where(x => x.MessageContent == videoID.ToString()).ToList();
            foreach (var vid in currentlyWatchings)
            {
                currentlyWatchingContext.CurrentlyWatching.Remove(vid);
                await currentlyWatchingContext.SaveChangesAsync();
            }
            foreach (var vid in myLists)
            {
                myListContext.MyList.Remove(vid);
                await myListContext.SaveChangesAsync();
            }
            foreach (var vid in likes)
            {
                likeContext.Likes.Remove(vid);
                await likeContext.SaveChangesAsync();
            }
            foreach (var vid in viewHistories)
            {
                viewHistoryContext.ViewHistory.Remove(vid);
                await viewHistoryContext.SaveChangesAsync();
            }
            foreach (var vid in messages)
            {
                messageContext.Messages.Remove(vid);
                await messageContext.SaveChangesAsync();
            }
            videoContext.Videos.Remove(video);
            await videoContext.SaveChangesAsync();
        }
    }
}
