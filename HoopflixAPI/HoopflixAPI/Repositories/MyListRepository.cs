using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public class MyListRepository : IMylistRepository
    {
        private readonly MyListContext myListContext;
        public MyListRepository(MyListContext myListContext)
        {
            this.myListContext = myListContext;
        }
        public async Task<MyList> AddToMyList(MyList myList)
        {
            myListContext.MyList.Add(myList);
            await myListContext.SaveChangesAsync();
            return myList;
        }
        public List<MyList> GetListFromUser(int userid)
        {
            List<MyList> list = myListContext.MyList.Where(x => x.UserID == userid).ToList();
            return list;
        }
        public async Task Delete(int userid, int videoID)
        {
            var like = myListContext.MyList.First(x => x.UserID == userid && x.VideoID == videoID);
            myListContext.MyList.Remove(like);
            await myListContext.SaveChangesAsync();
        }
        public MyList GetCertainItemFromList(int userid, int videoid)
        {
            MyList myList = myListContext.MyList.FirstOrDefault(x => x.UserID == userid && x.VideoID == videoid);
            return myList;
        }
    }
}
