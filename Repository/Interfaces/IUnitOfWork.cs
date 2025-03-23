using ChatBotModelAPI.Models;
using ChatBotModelAPI.Models.Roles;

namespace ChatBotModelAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<AppUser> AppUserRepository { get; }
        GenericRepository<ChatMessage> ChatMessageRepository { get; }

        GenericRepository<UserMessage> MessageRepository { get; }

        GenericRepository<BotReply> BotReplyRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
