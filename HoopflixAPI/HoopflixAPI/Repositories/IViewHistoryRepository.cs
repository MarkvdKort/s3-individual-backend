using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IViewHistoryRepository
    {
        Task Delete(int userid, int videoID);
        List<ViewHistory> GetViewHistoryFromUser(int userid);
        Task<ViewHistory> Create(ViewHistory viewHistory);
    }
}
