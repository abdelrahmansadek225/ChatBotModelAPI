using AutoMapper;
using ChatBotModelAPI.DTOs.CharMessageDTOs;
using ChatBotModelAPI.Models;

namespace ChatBotModelAPI.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region ChatMessage

            // Map ChatMessage to ReadChatMessageDTO
            CreateMap<ChatMessage, ReadChatMessageDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            // Map WriteChatMessageDTO to ChatMessage
            CreateMap<WriteChatMessageDTO, ChatMessage>().ReverseMap();
            #endregion
        }
    }
}
