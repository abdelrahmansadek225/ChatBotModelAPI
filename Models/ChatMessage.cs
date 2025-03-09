using ChatBotModelAPI.Models.Roles;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatBotModelAPI.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserMessage { get; set; }
        public string BotResponse { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation property

        [ForeignKey("User")]
        public string UserId { get; set; }  // Foreign Key
        public virtual AppUser User { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
