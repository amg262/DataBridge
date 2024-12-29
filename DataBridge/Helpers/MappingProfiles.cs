using DataBridge.Models.Delivra;
using DataBridge.Models.Delivra.Dto;
using DataBridge.Models.Liveperson;
using DataBridge.Models.Liveperson.Dto;
using Profile = AutoMapper.Profile;

namespace DataBridge.Helpers;

/// <summary>
/// Defines AutoMapper mapping profiles for converting between entity models and data transfer objects (DTOs).
/// This class inherits from AutoMapper's Profile class, allowing it to configure mappings for the AutoMapper instance.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Report, ReportDto>().ReverseMap();
        CreateMap<Segment, SegmentDto>().ReverseMap();
        CreateMap<Clickthrough, ClickthroughDto>().ReverseMap();
        CreateMap<MailingApproval, MailingApprovalDto>().ReverseMap();
        CreateMap<Open, OpenDto>().ReverseMap();
        CreateMap<Send, SendDto>().ReverseMap();

        // CreateMap<MessageContent, MessageRecord>()
        //     .ForMember(dest => dest.MessageText, opt => opt.MapFrom(src => src.Text))
        //     .ReverseMap();
        //
        // CreateMap<MessageRecord, MessageRecord>()
        //     .ForMember(dest => dest.MessageText, opt =>
        //         opt.MapFrom(src =>
        //             src.MessageData != null ? src.MessageData.Msg.Text ?? src.MessageData.Msg.Text : "No message content"));

        CreateMap<BaseUriResponseDto, BaseUriResponse>().ReverseMap();
        CreateMap<BaseUriDto, BaseUri>().ReverseMap();


        // Liveperson mappings
        CreateMap<ConversationHistoryResponseDto, ConversationHistoryResponse>().ReverseMap();
        CreateMap<MetadataDto, Metadata>().ReverseMap();
        CreateMap<PageInfoDto, PageInfo>().ReverseMap();
        CreateMap<ShardsStatusResultDto, ShardsStatusResult>().ReverseMap();
        CreateMap<ConversationHistoryRecordDto, ConversationHistoryRecord>().ReverseMap();
        CreateMap<ConversationInfoDto, ConversationInfo>().ReverseMap();
        CreateMap<CampaignDto, Campaign>().ReverseMap();


        // This will map the text from the MesssageRecord.MessageData.Msg.Text to the MessageText property at the time of mapping
        // instead of doing it manually
        CreateMap<MessageRecordDto, MessageRecord>()
            .ForMember(dest => dest.MessageText, opt => opt.MapFrom(src => 
                src.MessageData != null && src.MessageData.Msg != null ? src.MessageData.Msg.Text : null))
            .ReverseMap();
        
        CreateMap<MessageRecord, MessageRecord>()
            .ForMember(dest => dest.MessageText, opt => opt.MapFrom(src => 
                src.MessageData != null && src.MessageData.Msg != null ? src.MessageData.Msg.Text : null))
            .ReverseMap();
        
        CreateMap<MessageDataDto, MessageData>().ReverseMap();

        CreateMap<MessageDataDto, MessageData>().ReverseMap();
        CreateMap<MessageContentDto, MessageContent>().ReverseMap();
        CreateMap<RichContentDto, RichContent>().ReverseMap();
        CreateMap<QuickRepliesDto, QuickReplies>().ReverseMap();
        CreateMap<ContextDataDto, ContextData>().ReverseMap();
        CreateMap<AgentParticipantDto, AgentParticipant>().ReverseMap();
        CreateMap<ConsumerParticipantDto, ConsumerParticipant>().ReverseMap();
        CreateMap<TransferDto, Transfer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<Transfer, Transfer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        // Probably redundant because we are setting it after mapping but just keeping it anyways
        CreateMap<InteractionDto, Interaction>()
            .ForMember(dest => dest.ConversationId, opt => opt.Ignore())
            .ReverseMap();
        
        
        CreateMap<MessageScoreDto, MessageScore>().ReverseMap();
        CreateMap<MessageStatusDto, MessageStatus>().ReverseMap();
        CreateMap<ConversationSurveyDto, ConversationSurvey>().ReverseMap();
        CreateMap<SummaryDto, Summary>().ReverseMap();
        CreateMap<Summary, SummaryData>().ReverseMap();
        CreateMap<ConversationSummaryDto, SummaryData>().ReverseMap();
    }
}