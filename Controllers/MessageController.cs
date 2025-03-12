using AutoMapper;
using ChatBotModelAPI.DTOs.MessageDTOs;
using ChatBotModelAPI.Models;
using ChatBotModelAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatBotModelAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize] // 🔹 Ensure all actions require authentication
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // ✅ Send a new message (Fully RESTful)
        [HttpPost("send")]
        [AllowAnonymous]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO messageDTO)
        {
            if (messageDTO == null)
                return BadRequest("Message content is required.");

            // 🔹 Get user ID from JWT token (instead of IHttpContextAccessor)
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (string.IsNullOrEmpty(userId))
            //    return Unauthorized("User is not authenticated.");

            // 🔹 Map DTO to Message entity
            var message = _mapper.Map<UserMessage>(messageDTO);
            //message.SenderId = userId;
            message.SentAt = DateTime.UtcNow;

            // 🔹 Save to DB
            await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessageById), new { id = message.Id }, message);
        }

        // ✅ Get all messages in a chat (Fixed method)
        [HttpGet("chat/{chatId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMessagesByChat(string chatId)
        {
            try
            {
                var messages = await _unitOfWork.MessageRepository.GetByCondition(m => m.ChatMessageId == chatId);

                if (!messages.Any())
                    return NotFound("No messages found for this chat.");

                return Ok(messages);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving messages.");
            }
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

        // ✅ Delete a message (Ensure only the owner can delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            var message = await _unitOfWork.MessageRepository.GetByIdAsync(id);
            if (message == null)
                return NotFound("Message not found.");

            // 🔹 Ensure only the message sender can delete the message
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (message.SenderId != userId)
                return Forbid("You are not allowed to delete this message.");

            await _unitOfWork.MessageRepository.DeleteAsync(message);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }


    }
}
