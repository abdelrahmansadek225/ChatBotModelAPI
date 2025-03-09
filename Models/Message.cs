using ChatBotModelAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatBotModelAPI.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChatMessageId { get; set; } // FK to ChatMessage

        public virtual ChatMessage Chat { get; set; }  // Navigation Property

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }  // FK to User who sent the message

        public virtual AppUser Sender { get; set; }  // Navigation Property

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public bool IsEdited { get; set; } = false;
    }
}
