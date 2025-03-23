using AutoMapper;
using ChatBotModelAPI.DTOs.BotReplyDTOs;
using ChatBotModelAPI.Models;
using ChatBotModelAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotModelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BotReplyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BotReplyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBotReplies()
        {
            var botReplies = await _unitOfWork.BotReplyRepository.GetAllAsync();
            return Ok(botReplies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBotReply(string id)
        {
            var botReply = await _unitOfWork.BotReplyRepository.GetByIdAsync(id);
            if (botReply == null) return NotFound();
            return Ok(botReply);
        }


        [HttpPost]
        public async Task<IActionResult> AddBotReply(AddBotResponseDTO botReplyDTO)
        {
            var botReply = _mapper.Map<BotReply>(botReplyDTO);

            if (botReply == null) return BadRequest();

            var updatedBotReply = await _unitOfWork.BotReplyRepository.AddAsync(botReply);
            return Ok(updatedBotReply);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBotReply(AddBotResponseDTO botReplyDTO)
        {
            var botReply = _mapper.Map<BotReply>(botReplyDTO);
            if (botReply == null) return BadRequest();
            var updatedBotReply = await _unitOfWork.BotReplyRepository.UpdateAsync(botReply);
            return Ok(updatedBotReply);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBotReply(string id)
        {
            var isDeleted = await _unitOfWork.BotReplyRepository.DeleteAsync(id);
            if (!isDeleted) return NotFound();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBotRepliesByMessageId(string id)
        {
            var botReplies = await _unitOfWork.BotReplyRepository.GetByCondition(x => x.MessageId == id);
            if (botReplies == null) return NotFound();
            return Ok(botReplies);
        }

    }
}
