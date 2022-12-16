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
        public Chat GetCertainChat(int user1id, int user2id)
        {
            Chat chat = chatContext.Chats.First(x => (x.User1ID == user1id || x.User2ID == user1id) && (x.User1ID == user2id || x.User2ID == user2id));
            return chat;
        }
        public Chat GetChatByID(int id)
        {
            Chat chat = chatContext.Chats.First(x => x.ID == id);
                return chat;
        }
        public async Task<Chat> CreateChat(Chat chat)
        {
            chatContext.Chats.Add(chat);
            await chatContext.SaveChangesAsync();
            return chat;
        }
    }
}
