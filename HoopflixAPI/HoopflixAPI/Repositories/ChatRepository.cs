using HoopflixAPI.Models;

namespace HoopflixAPI.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatContext chatContext;
        public ChatRepository(ChatContext chatContext)
        {
            this.chatContext = chatContext;
        }
        public List<Chat> GetChatsFromUser(int userid)
        {
            List<Chat> chats = chatContext.Chats.Where(x => x.User1ID == userid || x.User2ID == userid).ToList();
            return chats;
        }
        public async Task<Chat> CreateChat(Chat chat)
        {
            chatContext.Chats.Add(chat);
            await chatContext.SaveChangesAsync();
            return chat;
        }
    }
}
