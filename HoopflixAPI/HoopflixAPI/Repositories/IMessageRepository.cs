using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public interface IMessageRepository
    {
        List<VideoMessage> GetMessagesFromCertainChat(int chatID);
        Task<Message> CreateMessage(Message message);
        Task<Message> SetMessagesToRead(int chatID, int UserID);
    }
}
