using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public class CurrentlyWatchingRepository : ICurrentlyWatchingRepository
    {
        private readonly CurrentlyWatchingContext currentlyWatchingContext;
        public CurrentlyWatchingRepository(CurrentlyWatchingContext currentlyWatchingContext)
        {
            this.currentlyWatchingContext = currentlyWatchingContext;
        }
        public async Task<CurrentlyWatching> Create(CurrentlyWatching currentlyWatching)
        {
            currentlyWatchingContext.CurrentlyWatching.Add(currentlyWatching);
            await currentlyWatchingContext.SaveChangesAsync();
            return currentlyWatching;
        }
        public List<CurrentlyWatching> GetCurrentlyWatchingsFromUser(int userid)
        {
            List<CurrentlyWatching> watching = currentlyWatchingContext.CurrentlyWatching.Where(x => x.UserID == userid).ToList();
            return watching;
        }
        public async Task Delete(int userid, int videoID)
        {
            var like = currentlyWatchingContext.CurrentlyWatching.First(x => x.UserID == userid && x.VideoID == videoID);
            currentlyWatchingContext.CurrentlyWatching.Remove(like);
            await currentlyWatchingContext.SaveChangesAsync();
        }
    }
}
