using System.ComponentModel.DataAnnotations;

namespace ChatBotModelAPI.DTOs.IdentityDTOs
{
    public class UpdateEmailDTO
    {
        public string UserId { get; set; }

        [Required]
        public string NewEmail { get; set; }
    }

    public class UpdatePasswordDTO
    {
        public string UserId { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required, MinLength(6)]
        public string NewPassword { get; set; }
    }

    public class UpdateNameDTO
    {
        public string UserId { get; set; }

        [Required, MinLength(2)]
        public string FirstName { get; set; }

        [Required, MinLength(2)]
        public string LastName { get; set; }
    }

    public class ReadUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;

        public string UserName { get; set; }

        // public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
        // public List<UserMessage> Messages { get; set; } = new List<UserMessage>();

        public List<string> ChatMessagesId { get; set; }

    }
}
