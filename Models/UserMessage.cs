using ChatBotModelAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatBotModelAPI.Models
{
    public class UserMessage
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("Chat")]
        public string ChatMessageId { get; set; } // FK to ChatMessage

        public virtual ChatMessage Chat { get; set; }  // Navigation Property

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }  // FK to User who sent the message

        public virtual AppUser Sender { get; set; }  // Navigation Property

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public bool IsEdited { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        //[ForeignKey("BotReply")]
        //public string BotReplyId { get; set; }  // FK to BotReply
        //public virtual BotReply BotReply { get; set; }

    }
}
