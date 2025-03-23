namespace ChatBotModelAPI.DTOs.BotReplyDTOs
{
    public class ReadBotResponseDTO
    {
        public string BotResponse { get; set; } = string.Empty;
        public string UserId { get; set; }  // Foreign Key
        public string MessageId { get; set; }
        public string ChatMessageId { get; set; }
    }
}
