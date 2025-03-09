namespace ChatBotModelAPI.DTOs.CharMessageDTOs
{
    public class ReadChatMessageDTO
    {
        public List<string> BotReplies { get; set; }

        public List<string> UserMessages { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }

        public string ChatMessageId { get; set; }

    }
}
