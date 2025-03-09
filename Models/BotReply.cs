using ChatBotModelAPI.Models.Roles;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatBotModelAPI.Models
{
    public class BotReply
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string BotResponse { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        // Navigation property
        [ForeignKey("User")]
        public string UserId { get; set; }  // Foreign Key
        public virtual AppUser User { get; set; }


        [ForeignKey("Message")]
        public string MessageId { get; set; }
        public virtual UserMessage userNessage { get; set; }

        [ForeignKey("Chat")]
        public string ChatMessageId { get; set; }
        public virtual ChatMessage Chat { get; set; }
    }
}
