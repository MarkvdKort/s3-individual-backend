using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface ICurrentlyWatchingRepository
    {
        Task Delete(int userid, int videoID);
        List<CurrentlyWatching> GetCurrentlyWatchingsFromUser(int userid);
        Task<CurrentlyWatching> Create(CurrentlyWatching currentlyWatching);
    }
}
