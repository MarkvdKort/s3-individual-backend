using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IChatRepository
    {
        List<Chat> GetChatsFromUser(int userid);
        Task<Chat> CreateChat(Chat chat);
        Chat GetCertainChat(int user1id, int user2id);
        Chat GetChatByID(int id);
    }
}
