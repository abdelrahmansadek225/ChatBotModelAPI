using AutoMapper;
using ChatBotModelAPI.DTOs.CharMessageDTOs;
using ChatBotModelAPI.DTOs.IdentityDTOs;
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
            //CreateMap<ChatMessage, ReadChatMessageDTO>()
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<SendMessageDTO, UserMessage>().ReverseMap();


            // Map WriteChatMessageDTO to ChatMessage
            CreateMap<WriteChatMessageDTO, ChatMessage>().ReverseMap();
            //CreateMap<ChatMessage, ReadChatMessageDTO>().ReverseMap()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ChateMessageId));

            CreateMap<ChatMessage, ReadChatMessageDTO>()
            .ForMember(dest => dest.ChatMessageId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserMessages, opt => opt.MapFrom(src => src.Messages.Select(um => um.Content).ToList()));

            #endregion

            #region AppUser
            CreateMap<AppUser, RegisterViewModel>().ReverseMap();

            CreateMap<AppUser, ReadUserDTO>()
           .ForMember(dest => dest.ChatMessagesId,
            opt => opt.MapFrom(src => src.ChatMessages.Select(cm => cm.Id).ToList()));

            #endregion

            #region UserMessage

            CreateMap<UserMessage, ReadUserMessageDTO>()
            .ForMember(dest => dest.ChatMessageId, opt => opt.MapFrom(src => src.ChatMessageId))
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.Id));



            #endregion
        }
    }
}
