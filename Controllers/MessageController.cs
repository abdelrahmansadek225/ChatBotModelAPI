using AutoMapper;
using ChatBotModelAPI.Models;
using ChatBotModelAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatBotModelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageController(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // ✅ Send a new message
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO messageDTO)
        {
            if (messageDTO == null)
                return BadRequest("Message content is required.");

            // 🔹 Get the currently authenticated user's ID
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User is not authenticated.");

            // 🔹 Map DTO to Message entity
            var message = _mapper.Map<Message>(messageDTO);
            message.UserId = userId; // Assign user ID to the message
            message.SentAt = DateTime.UtcNow;

            // 🔹 Save to DB
            await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessageById), new { id = message.Id }, message);
        }

        // ✅ Get all messages in a chat
        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetMessagesByChat(string chatId)
        {
            var messages = await _unitOfWork.MessageRepository.GetMessagesByChatIdAsync(chatId);
            if (messages == null || !messages.Any())
                return NotFound("No messages found for this chat.");

            return Ok(messages);
        }

        // ✅ Get a single message by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(string id)
        {
            var message = await _unitOfWork.MessageRepository.GetByIdAsync(id);
            if (message == null)
                return NotFound("Message not found.");

            return Ok(message);
        }

        // ✅ Delete a message
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            var message = await _unitOfWork.MessageRepository.GetByIdAsync(id);
            if (message == null)
                return NotFound("Message not found.");

            await _unitOfWork.MessageRepository.DeleteAsync(message);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
