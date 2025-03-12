namespace ChatBotModelAPI.DTOs.MessageDTOs
{
    public class SendMessageDTO
    {
        public string Content { get; set; }
        public string ChatMessageId { get; set; } // FK to ChatMessage
        public string SenderId { get; set; }  // FK to User who sent the message

    }
}
