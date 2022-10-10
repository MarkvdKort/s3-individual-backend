using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IMylistRepository
    {
        Task<MyList> AddToMyList(MyList myList);
        List<MyList> GetListFromUser(int userid);
        Task Delete(int userid, int videoID);
        MyList GetCertainItemFromList(int userid, int videoid);
    }
}
