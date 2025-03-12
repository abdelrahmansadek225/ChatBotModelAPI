using AutoMapper;
using ChatBotModelAPI.DTOs.CharMessageDTOs;
using ChatBotModelAPI.DTOs.MessageDTOs;
using ChatBotModelAPI.Models;
using ChatBotModelAPI.Models.Roles;
using ChatBotModelAPI.ViewModels;

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

            CreateMap<SendMessageDTO, UserMessage>().ReverseMap();


            // Map WriteChatMessageDTO to ChatMessage
            CreateMap<WriteChatMessageDTO, ChatMessage>().ReverseMap();
            #endregion

            #region AppUser
            CreateMap<AppUser, RegisterViewModel>().ReverseMap();
            #endregion
        }
    }
}
