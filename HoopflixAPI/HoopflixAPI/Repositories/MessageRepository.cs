using HoopflixAPI.Models;
using System.Security.Cryptography.Xml;

namespace HoopflixAPI.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageContext messageContext;
        private readonly VideoContext videoContext;
        private readonly ChatContext chatContext;
        private readonly Usercontext usercontext;
        public MessageRepository(MessageContext messageContext, VideoContext videoContext, ChatContext chatContext, Usercontext usercontext)
        {
            this.messageContext = messageContext;
            this.videoContext = videoContext;
            this.chatContext = chatContext;
            this.usercontext = usercontext;
        }
        public List<VideoMessage> GetMessagesFromCertainChat(int chatID)
        {
            List<Message> messages = messageContext.Messages.Where(x => x.ChatID == chatID).ToList();
            List<VideoMessage> videoMessages = new List<VideoMessage>();    
            foreach (var message in messages)
            {
                VideoMessage videoMessage = new VideoMessage();
                if(message.Type == "TextMessage")
                {
                    videoMessage.Message = message;
                    videoMessage.Video = null;
                }
                if (message.Type == "Video")
                {
                    videoMessage.Message = message;
                    videoMessage.Video = videoContext.Videos.FirstOrDefault(x => x.ID.ToString() == message.MessageContent);
                }
                videoMessages.Add(videoMessage);
            }
            return videoMessages;
        }
        public async Task<Message> CreateMessage(Message message)
        {
            message.New = 1;
            message.Time = DateTime.Now.ToString();
            if(message.Type == "Video")
            {
                Video video = videoContext.Videos.FirstOrDefault(x => x.ID.ToString() == message.MessageContent);
                if(video == null)
                {
                    return null;
                }
            }
            Chat chat = chatContext.Chats.FirstOrDefault(x => x.ID == message.ChatID);
            if(chat == null)
            {
                return null;
            }
            User user = usercontext.Users.FirstOrDefault(x => x.ID == message.UserID);
            if(user == null)
            {
                return null;
            }
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
