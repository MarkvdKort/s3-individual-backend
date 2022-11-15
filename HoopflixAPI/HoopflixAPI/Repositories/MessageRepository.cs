using HoopflixAPI.Models;
using System.Security.Cryptography.Xml;

namespace HoopflixAPI.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageContext messageContext;
        public MessageRepository(MessageContext messageContext)
        {
            this.messageContext = messageContext;
        }
        public List<Message> GetMessagesFromCertainChat(int chatID)
        {
            List<Message> messages = messageContext.Messages.Where(x => x.ChatID == chatID).ToList();
            return messages;
        }
        public async Task<Message> CreateMessage(Message message)
        {
            message.New = 1;
            message.Time = DateTime.Now.ToString();
            messageContext.Messages.Add(message);
            await messageContext.SaveChangesAsync();
            return message;
        }
        public async Task<Message> SetMessagesToRead(int chatID, int UserID)
        {
            List<Message> messages =messageContext.Messages.Where(x => x.ChatID == chatID && x.UserID != UserID).ToList();
            foreach (var message in messages)
            {
                message.New = 0;
            }
            await messageContext.SaveChangesAsync();
            return null;
        }
    }
}
