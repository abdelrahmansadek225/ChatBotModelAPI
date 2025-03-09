namespace ChatBotModelAPI.DTOs.CharMessageDTOs
{
    public class ReadChatMessageDTO
    {
        public string UserMessage { get; set; }
        public string BotResponse { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
    }
}
