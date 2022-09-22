using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public class ViewHistoryRepository :IViewHistoryRepository
    {
        private readonly ViewHistoryContext viewHistoryContext;
        public ViewHistoryRepository(ViewHistoryContext viewHistoryContext)
        {
            this.viewHistoryContext = viewHistoryContext;
        }
        public async Task<ViewHistory> Create(ViewHistory viewHistory)
        {
            viewHistoryContext.ViewHistory.Add(viewHistory);
            await viewHistoryContext.SaveChangesAsync();
            return viewHistory;
        }
        public List<ViewHistory> GetViewHistoryFromUser(int userid)
        {
            List<ViewHistory> watching = viewHistoryContext.ViewHistory.Where(x => x.UserID == userid).ToList();
            return watching;
        }
        public ViewHistory GetCertainViewHistory(int userid, int videoid)
        {
            ViewHistory viewHistory = viewHistoryContext.ViewHistory.FirstOrDefault(x => x.UserID == userid && x.VideoID == videoid);
            return viewHistory;
        }
        public async Task Delete(int userid, int videoID)
        {
            var like = viewHistoryContext.ViewHistory.First(x => x.UserID == userid && x.VideoID == videoID);
            viewHistoryContext.ViewHistory.Remove(like);
            await viewHistoryContext.SaveChangesAsync();
        }
    }
}
