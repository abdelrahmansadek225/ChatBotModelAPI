using AutoMapper;
using ChatBotModelAPI.DTOs.CharMessageDTOs;
using ChatBotModelAPI.Models;
using ChatBotModelAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotModelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatMessageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // ✅ Add a method to get all chat messages
        [HttpGet]
        public async Task<IActionResult> GetChatMessages()
        {
            var chatMessages = await _unitOfWork.ChatMessageRepository.GetAllAsync();
            return Ok(chatMessages);
        }

        // ✅ Add a method to get a chat message by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatMessage(string id)
        {
            var chatMessage = await _unitOfWork.ChatMessageRepository.GetByIdAsync(id);
            if (chatMessage == null)
            {
                return NotFound();
            }
            return Ok(chatMessage);
        }

        // ✅ Add a method to create a chat message
        [HttpPost]
        public async Task<IActionResult> CreateChatMessage(WriteChatMessageDTO chatMessageDTO)
        {
            if (chatMessageDTO == null)
            {
                return BadRequest();
            }

            var chatMessage = _mapper.Map<WriteChatMessageDTO, ChatMessage>(chatMessageDTO); // Map the DTO to the model
            await _unitOfWork.ChatMessageRepository.AddAsync(chatMessage);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChatMessage), new { id = chatMessage.Id }, chatMessageDTO);
        }

        /// <summary>
        /// Send a new chat message
        /// </summary>
        //[HttpPost("send")]
        //public async Task<IActionResult> SendMessage([FromBody] WriteChatMessageDTO chatMessageDTO)
        //{
        //    if (chatMessageDTO == null || string.IsNullOrWhiteSpace(chatMessageDTO.Content))
        //        return BadRequest("Message content cannot be empty");

        //    // Get the logged-in user's ID
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (userId == null)
        //        return Unauthorized("User not authenticated");

        //    // Create a new chat message entity
        //    var chatMessage = new ChatMessage
        //    {
        //        Id = Guid.NewGuid(),
        //        UserId = userId,
        //        Content = chatMessageDTO.Content,
        //        SentAt = DateTime.UtcNow
        //    };

        //    // Save to the database
        //    await _unitOfWork.ChatMessageRepository.AddAsync(chatMessage);
        //    await _unitOfWork.SaveChangesAsync();

        //    // Return the created message
        //    return CreatedAtAction(nameof(GetChatMessage), new { id = chatMessage.Id }, _mapper.Map<ReadChatMessageDTO>(chatMessage));
        //}

    }
}
