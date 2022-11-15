using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IChatRepository
    {
        List<Chat> GetChatsFromUser(int userid);
        Task<Chat> CreateChat(Chat chat);
    }
}
