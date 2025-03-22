namespace ChatBotModelAPI.DTOs.MessageDTOs
{
    public class ReadUserMessageDTO
    {
        public string Id { get; set; }
        public string ChatMessageId { get; set; }
        public string SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
    }
}
