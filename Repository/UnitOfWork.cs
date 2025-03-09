using ChatBotModelAPI.Models;
using ChatBotModelAPI.Models.Roles;
using ChatBotModelAPI.Repository.Interfaces;

namespace ChatBotModelAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) => _context = context;


        private readonly GenericRepository<AppUser> _userRepository;
        private readonly GenericRepository<ChatMessage> _chatMessageRepository;
        private readonly GenericRepository<UserMessage> _messageRepository;

        #region Repositories
        // Add your repositories here, assign Geters

        public GenericRepository<AppUser> AppUserRepository => _userRepository ?? new GenericRepository<AppUser>(_context);
        public GenericRepository<ChatMessage> ChatMessageRepository => _chatMessageRepository ?? new GenericRepository<ChatMessage>(_context);
        public GenericRepository<UserMessage> MessageRepository => _messageRepository ?? new GenericRepository<UserMessage>(_context);


        #region example
        /*    public GenericRepository<Book> BookRepo
        {
            get
            {
                if (BookRepository == null)
                    BookRepository = new GenericRepository<Book>(_context);
                return BookRepository;
            }
        }
        */
        #endregion
        #endregion

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
