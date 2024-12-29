using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DataBridge.Models.Liveperson;

/// <summary>
/// Represents the root object of the Conversation History API response.
/// </summary>
public class ConversationHistoryResponse
{
    /// <summary>
    /// Metadata about the API response.
    /// </summary>
    [JsonPropertyName("_metadata")]
    public Metadata? Metadata { get; set; }

    /// <summary>
    /// List of conversation history records.
    /// </summary>
    [JsonPropertyName("conversationHistoryRecords")]
    public List<ConversationHistoryRecord>? ConversationHistoryRecords { get; set; }
}

/// <summary>
/// Represents metadata about the API response.
/// </summary>
public class Metadata
{
    /// <summary>
    /// The total count of records.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <summary>
    /// Information about the next page of results.
    /// </summary>
    [JsonPropertyName("next")]
    public PageInfo? Next { get; set; }

    /// <summary>
    /// Information about the last page of results.
    /// </summary>
    [JsonPropertyName("last")]
    public PageInfo? Last { get; set; }

    /// <summary>
    /// Information about the current page of results.
    /// </summary>
    [JsonPropertyName("self")]
    public PageInfo? Self { get; set; }

    /// <summary>
    /// Status of shards processing.
    /// </summary>
    [JsonPropertyName("shardsStatusResult")]
    public ShardsStatusResult? ShardsStatusResult { get; set; }
}

/// <summary>
/// Represents pagination information.
/// </summary>
public class PageInfo
{
    /// <summary>
    /// The relation of the page (e.g., "next", "last", "self").
    /// </summary>
    [JsonPropertyName("rel")]
    public string? Rel { get; set; }

    /// <summary>
    /// The URL for the page.
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; set; }
}

/// <summary>
/// Represents the status of shards processing.
/// </summary>
public class ShardsStatusResult
{
    /// <summary>
    /// Indicates if the result is partial.
    /// </summary>
    [JsonPropertyName("partialResult")]
    public bool? PartialResult { get; set; }
}

/// <summary>
/// Represents a single conversation history record.
/// </summary>
public class ConversationHistoryRecord
{
    /// <summary>
    /// General information about the conversation.
    /// </summary>
    [JsonPropertyName("info")]
    public ConversationInfo? Info { get; set; }

    /// <summary>
    /// Information about the campaign associated with the conversation.
    /// </summary>
    [JsonPropertyName("campaign")]
    public Campaign? Campaign { get; set; }

    /// <summary>
    /// List of messages in the conversation.
    /// </summary>
    [JsonPropertyName("messageRecords")]
    public List<MessageRecord>? MessageRecords { get; set; }

    /// <summary>
    /// List of agent participants in the conversation.
    /// </summary>
    [JsonPropertyName("agentParticipants")]
    public List<AgentParticipant>? AgentParticipants { get; set; }

    /// <summary>
    /// List of consumer participants in the conversation.
    /// </summary>
    [JsonPropertyName("consumerParticipants")]
    public List<ConsumerParticipant>? ConsumerParticipants { get; set; }

    /// <summary>
    /// List of transfers in the conversation.
    /// </summary>
    [JsonPropertyName("transfers")]
    public List<Transfer>? Transfers { get; set; }

    /// <summary>
    /// List of interactions in the conversation.
    /// </summary>
    [JsonPropertyName("interactions")]
    public List<Interaction>? Interactions { get; set; }

    /// <summary>
    /// List of message scores in the conversation.
    /// </summary>
    [JsonPropertyName("messageScores")]
    public List<MessageScore>? MessageScores { get; set; }

    /// <summary>
    /// List of message statuses in the conversation.
    /// </summary>
    [JsonPropertyName("messageStatuses")]
    public List<MessageStatus>? MessageStatuses { get; set; }

    /// <summary>
    /// List of conversation surveys.
    /// </summary>
    [JsonPropertyName("conversationSurveys")]
    public List<ConversationSurvey>? ConversationSurveys { get; set; }

    /// <summary>
    /// Summary of the conversation.
    /// </summary>
    [JsonPropertyName("summary")]
    public Summary? Summary { get; set; }
}

/// <summary>
/// Represents general information about a conversation.
/// </summary>
[Table("LP_ConversationInfo")]
public class ConversationInfo
{
    /// <summary>
    /// The unique identifier of the conversation.
    /// </summary>
    [Key]
    [JsonPropertyName("conversationId")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ConversationId { get; set; }

    // [Key]
    // [Column(Order = 1)]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("campaignId")] public string? CampaignId { get; set; }

    /// <summary>
    ///
    /// </summary>
    // [NotMapped]
    [ForeignKey("CampaignId")]
    public Campaign? Campaign { get; set; }

    /// <summary>
    /// The start time of the conversation.
    /// </summary>
    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }

    /// <summary>
    /// The start time of the conversation in long format.
    /// </summary>
    [JsonPropertyName("startTimeL")]
    public long? StartTimeL { get; set; }

    /// <summary>
    /// The end time of the conversation.
    /// </summary>
    [JsonPropertyName("endTime")]
    public string? EndTime { get; set; }

    /// <summary>
    /// The end time of the conversation in long format.
    /// </summary>
    [JsonPropertyName("endTimeL")]
    public long? EndTimeL { get; set; }

    /// <summary>
    /// The end time of the conversation.
    /// </summary>
    [JsonPropertyName("conversationEndTime")]
    public string? ConversationEndTime { get; set; }

    /// <summary>
    /// The end time of the conversation in long format.
    /// </summary>
    [JsonPropertyName("conversationEndTimeL")]
    public long? ConversationEndTimeL { get; set; }

    /// <summary>
    /// The duration of the conversation.
    /// </summary>
    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    /// <summary>
    /// The brand identifier.
    /// </summary>
    [JsonPropertyName("brandId")]
    public string? BrandId { get; set; }

    /// <summary>
    /// The identifier of the latest agent in the conversation.
    /// </summary>
    [JsonPropertyName("latestAgentId")]
    public string? LatestAgentId { get; set; }

    /// <summary>
    /// The nickname of the latest agent in the conversation.
    /// </summary>
    [JsonPropertyName("latestAgentNickname")]
    public string? LatestAgentNickname { get; set; }

    /// <summary>
    /// The full name of the latest agent in the conversation.
    /// </summary>
    [JsonPropertyName("latestAgentFullName")]
    public string? LatestAgentFullName { get; set; }

    /// <summary>
    /// The login name of the latest agent in the conversation.
    /// </summary>
    [JsonPropertyName("latestAgentLoginName")]
    public string? LatestAgentLoginName { get; set; }

    /// <summary>
    /// Indicates if the agent has been deleted.
    /// </summary>
    [JsonPropertyName("agentDeleted")]
    public bool? AgentDeleted { get; set; }

    /// <summary>
    /// The identifier of the latest skill used in the conversation.
    /// </summary>
    [JsonPropertyName("latestSkillId")]
    public long? LatestSkillId { get; set; }

    /// <summary>
    /// The name of the latest skill used in the conversation.
    /// </summary>
    [JsonPropertyName("latestSkillName")]
    public string? LatestSkillName { get; set; }

    /// <summary>
    /// The source of the conversation.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// The reason for closing the conversation.
    /// </summary>
    [JsonPropertyName("closeReason")]
    public string? CloseReason { get; set; }

    /// <summary>
    /// The description of the close reason.
    /// </summary>
    [JsonPropertyName("closeReasonDescription")]
    public string? CloseReasonDescription { get; set; }

    /// <summary>
    /// The MCS (Meaningful Conversation Score) of the conversation.
    /// </summary>
    [JsonPropertyName("mcs")]
    public int? Mcs { get; set; }

    /// <summary>
    /// The alerted MCS of the conversation.
    /// </summary>
    [JsonPropertyName("alertedMCS")]
    public int? AlertedMCS { get; set; }

    /// <summary>
    /// The status of the conversation.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The full dialog status of the conversation.
    /// </summary>
    [JsonPropertyName("fullDialogStatus")]
    public string? FullDialogStatus { get; set; }

    /// <summary>
    /// Indicates if this is the first conversation.
    /// </summary>
    [JsonPropertyName("firstConversation")]
    public bool? FirstConversation { get; set; }

    /// <summary>
    /// The device used in the conversation.
    /// </summary>
    [JsonPropertyName("device")]
    public string? Device { get; set; }

    /// <summary>
    /// The browser used in the conversation.
    /// </summary>
    [JsonPropertyName("browser")]
    public string? Browser { get; set; }

    /// <summary>
    /// The version of the browser used in the conversation.
    /// </summary>
    [JsonPropertyName("browserVersion")]
    public string? BrowserVersion { get; set; }

    /// <summary>
    /// The operating system used in the conversation.
    /// </summary>
    [JsonPropertyName("operatingSystem")]
    public string? OperatingSystem { get; set; }

    /// <summary>
    /// The version of the operating system used in the conversation.
    /// </summary>
    [JsonPropertyName("operatingSystemVersion")]
    public string? OperatingSystemVersion { get; set; }

    /// <summary>
    /// The identifier of the latest agent group in the conversation.
    /// </summary>
    [JsonPropertyName("latestAgentGroupId")]
    public long? LatestAgentGroupId { get; set; }

    /// <summary>
    /// The name of the latest agent group in the conversation.
    /// </summary>
    [JsonPropertyName("latestAgentGroupName")]
    public string? LatestAgentGroupName { get; set; }

    /// <summary>
    /// The latest queue state of the conversation.
    /// </summary>
    [JsonPropertyName("latestQueueState")]
    public string? LatestQueueState { get; set; }

    /// <summary>
    /// Indicates if the conversation data is partial.
    /// </summary>
    [JsonPropertyName("isPartial")]
    public bool? IsPartial { get; set; }

    /// <summary>
    /// The visitor identifier.
    /// </summary>
    [JsonPropertyName("visitorId")]
    public string? VisitorId { get; set; }

    /// <summary>
    /// The session identifier.
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    /// <summary>
    /// The interaction context identifier.
    /// </summary>
    [JsonPropertyName("interactionContextId")]
    public string? InteractionContextId { get; set; }

    /// <summary>
    /// The time zone of the conversation.
    /// </summary>
    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    /// <summary>
    /// The features used in the conversation.
    /// </summary>
    [JsonPropertyName("features")]
    public List<string>? Features { get; set; }

    /// <summary>
    /// The language of the conversation.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// The integration type used in the conversation.
    /// </summary>
    [JsonPropertyName("integration")]
    public string? Integration { get; set; }

    /// <summary>
    /// The version of the integration used in the conversation.
    /// </summary>
    [JsonPropertyName("integrationVersion")]
    public string? IntegrationVersion { get; set; }

    /// <summary>
    /// The application identifier.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// The IP address of the visitor.
    /// </summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    /// <summary>
    /// The identifier of the latest handler account.
    /// </summary>
    [JsonPropertyName("latestHandlerAccountId")]
    public string? LatestHandlerAccountId { get; set; }

    /// <summary>
    /// The identifier of the latest handler skill.
    /// </summary>
    [JsonPropertyName("latestHandlerSkillId")]
    public long? LatestHandlerSkillId { get; set; }

    private bool Equals(ConversationInfo other)
    {
        return ConversationId.Equals(other.ConversationId);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((ConversationInfo)obj);
    }

    public override int GetHashCode()
    {
        return ConversationId.GetHashCode();
    }
}

/// <summary>
/// Represents campaign information for a conversation.
/// </summary>
[Table("LP_Campaigns")]
public class Campaign
{
    /// <summary>
    /// The identifier of the campaign.
    /// </summary>
    [Key]
    [JsonPropertyName("campaignId")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string CampaignId { get; set; }

    /// <summary>
    /// The identifier of the campaign engagement.
    /// </summary>
    [JsonPropertyName("campaignEngagementId")]
    public string? CampaignEngagementId { get; set; }

    /// <summary>
    /// The name of the campaign engagement.
    /// </summary>
    [JsonPropertyName("campaignEngagementName")]
    public string? CampaignEngagementName { get; set; }

    /// <summary>
    /// The name of the campaign.
    /// </summary>
    [JsonPropertyName("campaignName")]
    public string? CampaignName { get; set; }

    /// <summary>
    /// The identifier of the goal.
    /// </summary>
    [JsonPropertyName("goalId")]
    public string? GoalId { get; set; }

    /// <summary>
    /// The name of the goal.
    /// </summary>
    [JsonPropertyName("goalName")]
    public string? GoalName { get; set; }

    /// <summary>
    /// The source of the engagement.
    /// </summary>
    [JsonPropertyName("engagementSource")]
    public string? EngagementSource { get; set; }

    /// <summary>
    /// The identifier of the visitor behavior.
    /// </summary>
    [JsonPropertyName("visitorBehaviorId")]
    public string? VisitorBehaviorId { get; set; }

    /// <summary>
    /// The name of the visitor behavior.
    /// </summary>
    [JsonPropertyName("visitorBehaviorName")]
    public string? VisitorBehaviorName { get; set; }

    /// <summary>
    /// The identifier of the visitor profile.
    /// </summary>
    [JsonPropertyName("visitorProfileId")]
    public string? VisitorProfileId { get; set; }

    /// <summary>
    /// The name of the visitor profile.
    /// </summary>
    [JsonPropertyName("visitorProfileName")]
    public string? VisitorProfileName { get; set; }

    /// <summary>
    /// The identifier of the line of business.
    /// </summary>
    [JsonPropertyName("lobId")]
    public long? LobId { get; set; }

    /// <summary>
    /// The name of the line of business.
    /// </summary>
    [JsonPropertyName("lobName")]
    public string? LobName { get; set; }

    /// <summary>
    /// The identifier of the location.
    /// </summary>
    [JsonPropertyName("locationId")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The name of the location.
    /// </summary>
    [JsonPropertyName("locationName")]
    public string? LocationName { get; set; }

    /// <summary>
    /// Indicates if the profile is a system default.
    /// </summary>
    [JsonPropertyName("profileSystemDefault")]
    public bool? ProfileSystemDefault { get; set; }

    /// <summary>
    /// Indicates if the behavior is a system default.
    /// </summary>
    [JsonPropertyName("behaviorSystemDefault")]
    public bool? BehaviorSystemDefault { get; set; }

    // private bool Equals(Campaign other)
    // {
    //     return CampaignId == other.CampaignId;
    // }
    //
    // public override bool Equals(object? obj)
    // {
    //     if (obj is null) return false;
    //     if (ReferenceEquals(this, obj)) return true;
    //     return obj.GetType() == GetType() && Equals((Campaign)obj);
    // }
    //
    // public override int GetHashCode()
    // {
    //     return CampaignId.GetHashCode();
    // }

    private bool Equals(Campaign other)
    {
        return CampaignId == other.CampaignId;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Campaign)obj);
    }

    public override int GetHashCode()
    {
        return CampaignId.GetHashCode();
    }
}

/// <summary>
/// Represents a message record in a conversation.
/// </summary>
[Table("LP_MessageRecords")]
public class MessageRecord
{
    /// <summary>
    /// The unique identifier of the message.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    // [Key]
    // [Column(Order = 1)]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("conversationId")] public Guid? ConversationId { get; set; }

    /// <summary>
    ///
    /// </summary>
    // [NotMapped]
    [ForeignKey("ConversationId")]
    public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// MessageText set to the value of MessageData.Msg.Text via AutoMapper
    /// </summary>
    [JsonPropertyName("messageText")]
    public string? MessageText { get; set; }

    public string? MessageStatus { get; set; }

    /// <summary>
    /// The dialog identifier associated with the message.
    /// </summary>
    [JsonPropertyName("dialogId")]
    public string? DialogId { get; set; }

    /// <summary>
    /// The identifier of the participant who sent the message.
    /// </summary>
    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; set; }

    /// <summary>
    /// The type of the message.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The raw score of the message.
    /// </summary>
    [JsonPropertyName("messageRawScore")]
    public int? MessageRawScore { get; set; }

    /// <summary>
    /// The MCS (Meaningful Conversation Score) of the message.
    /// </summary>
    [JsonPropertyName("mcs")]
    public int? Mcs { get; set; }

    /// <summary>
    /// The data content of the message.
    /// </summary>
    [JsonPropertyName("messageData")]
    [NotMapped]
    public MessageData? MessageData { get; set; }

    /// <summary>
    /// The audience of the message.
    /// </summary>
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    /// <summary>
    /// The sequence number of the message.
    /// </summary>
    [JsonPropertyName("seq")]
    public int? Seq { get; set; }

    /// <summary>
    /// The source of the message.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// The timestamp of the message.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// The timestamp of the message in long format.
    /// </summary>
    [JsonPropertyName("timeL")]
    public long? TimeL { get; set; }

    /// <summary>
    /// The integration source of the message.
    /// </summary>
    [JsonPropertyName("integrationSource")]
    public string? IntegrationSource { get; set; }

    /// <summary>
    /// The device used to send the message.
    /// </summary>
    [JsonPropertyName("device")]
    public string? Device { get; set; }

    /// <summary>
    /// Indicates who sent the message (e.g., "Consumer" or "Agent").
    /// </summary>
    [JsonPropertyName("sentBy")]
    public string? SentBy { get; set; }

    /// <summary>
    /// Context data associated with the message.
    /// </summary>
    [JsonPropertyName("contextData")]
    [NotMapped]
    public ContextData? ContextData { get; set; }

    /// <summary>
    /// Indicates if the message is predefined content.
    /// </summary>
    [JsonPropertyName("predefinedContent")]
    public bool? PredefinedContent { get; set; }

    /// <summary>
    /// The language of the predefined content.
    /// </summary>
    [JsonPropertyName("predefinedContentLanguage")]
    public string? PredefinedContentLanguage { get; set; }

    /// <summary>
    /// The category ID of the predefined content.
    /// </summary>
    [JsonPropertyName("predefinedContentCategoryId")]
    public string? PredefinedContentCategoryId { get; set; }

    /// <summary>
    /// The ID of the predefined content.
    /// </summary>
    [JsonPropertyName("predefinedContentId")]
    public string? PredefinedContentId { get; set; }

    /// <summary>
    /// Indicates if the predefined content was edited.
    /// </summary>
    [JsonPropertyName("predefinedContentEdited")]
    public bool? PredefinedContentEdited { get; set; }

    private bool Equals(MessageRecord other)
    {
        return MessageId == other.MessageId;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((MessageRecord)obj);
    }

    public override int GetHashCode()
    {
        return MessageId.GetHashCode();
    }
}

/// <summary>
/// Represents the data content of a message.
/// </summary>
public class MessageData
{
    /// <summary>
    /// The message content.
    /// </summary>
    [JsonPropertyName("msg")]
    public MessageContent? Msg { get; set; }

    /// <summary>
    /// The rich content of the message.
    /// </summary>
    [JsonPropertyName("richContent")]
    public RichContent? RichContent { get; set; }

    /// <summary>
    /// Quick replies associated with the message.
    /// </summary>
    [JsonPropertyName("quickReplies")]
    public QuickReplies? QuickReplies { get; set; }
}

/// <summary>
/// Represents the content of a message.
/// </summary>
public class MessageContent
{
    /// <summary>
    /// The text content of the message.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

/// <summary>
/// Represents rich content in a message.
/// </summary>
public class RichContent
{
    /// <summary>
    /// The content of the rich message.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}

/// <summary>
/// Represents quick replies in a message.
/// </summary>
public class QuickReplies
{
    /// <summary>
    /// The content of the quick replies.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}

/// <summary>
/// Represents context data associated with a message.
/// </summary>
public class ContextData
{
    [Key] public int PkId { get; set; }

    /// <summary>
    /// Raw metadata associated with the message.
    /// </summary>
    [JsonPropertyName("rawMetadata")]
    public string? RawMetadata { get; set; }

    /// <summary>
    /// Structured metadata associated with the message.
    /// </summary>
    [JsonPropertyName("structuredMetadata")]
    public List<object>? StructuredMetadata { get; set; }
}

/// <summary>
/// Represents an agent participant in a conversation.
/// </summary>
public class AgentParticipant
{
    /// <summary>
    /// The full name of the agent.
    /// </summary>
    [JsonPropertyName("agentFullName")]
    public string? AgentFullName { get; set; }

    /// <summary>
    /// The nickname of the agent.
    /// </summary>
    [JsonPropertyName("agentNickname")]
    public string? AgentNickname { get; set; }

    /// <summary>
    /// The login name of the agent.
    /// </summary>
    [JsonPropertyName("agentLoginName")]
    public string? AgentLoginName { get; set; }

    /// <summary>
    /// Indicates if the agent has been deleted.
    /// </summary>
    [JsonPropertyName("agentDeleted")]
    public bool? AgentDeleted { get; set; }

    /// <summary>
    /// The unique identifier of the agent.
    /// </summary>
    [JsonPropertyName("agentId")]
    public string? AgentId { get; set; }

    /// <summary>
    /// The participant identifier of the agent.
    /// </summary>
    [JsonPropertyName("agentPid")]
    public string? AgentPid { get; set; }

    /// <summary>
    /// The type of user (e.g., "0" for System, "1" for Human, "2" for Bot).
    /// </summary>
    [JsonPropertyName("userType")]
    public string? UserType { get; set; }

    /// <summary>
    /// The name of the user type.
    /// </summary>
    [JsonPropertyName("userTypeName")]
    public string? UserTypeName { get; set; }

    /// <summary>
    /// The role of the agent in the conversation.
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// The name of the agent group.
    /// </summary>
    [JsonPropertyName("agentGroupName")]
    public string? AgentGroupName { get; set; }

    /// <summary>
    /// The identifier of the agent group.
    /// </summary>
    [JsonPropertyName("agentGroupId")]
    public long? AgentGroupId { get; set; }

    /// <summary>
    /// The timestamp when the agent joined the conversation.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// The timestamp when the agent joined the conversation in long format.
    /// </summary>
    [JsonPropertyName("timeL")]
    public long? TimeL { get; set; }

    /// <summary>
    /// The permission level of the agent in the conversation.
    /// </summary>
    [JsonPropertyName("permission")]
    public string? Permission { get; set; }

    /// <summary>
    /// The dialog identifier associated with the agent's participation.
    /// </summary>
    [JsonPropertyName("dialogId")]
    public string? DialogId { get; set; }
}

/// <summary>
/// Represents a consumer participant in a conversation.
/// </summary>
[Table("LP_ConsumerParticipants")]
public class ConsumerParticipant
{
    [Key] public int Id { get; set; }

    // [Key]
    // [Column(Order = 1)]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("conversationId")] public Guid? ConversationId { get; set; }

    /// <summary>
    ///
    /// </summary>
    // [NotMapped]
    [ForeignKey("ConversationId")]
    public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// The unique identifier of the participant.
    /// </summary>
    [JsonPropertyName("participantId")]
    public string ParticipantId { get; set; }

    /// <summary>
    /// The first name of the consumer.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the consumer.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// The token associated with the consumer.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    /// <summary>
    /// The email of the consumer.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The phone number of the consumer.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The URL of the consumer's avatar.
    /// </summary>
    [JsonPropertyName("avatarURL")]
    public string? AvatarURL { get; set; }

    /// <summary>
    /// The timestamp when the consumer joined the conversation.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// The timestamp when the consumer joined the conversation in long format.
    /// </summary>
    [JsonPropertyName("timeL")]
    public long? TimeL { get; set; }

    /// <summary>
    /// The timestamp when the consumer joined the conversation.
    /// </summary>
    [JsonPropertyName("joinTime")]
    public string? JoinTime { get; set; }

    /// <summary>
    /// The timestamp when the consumer joined the conversation in long format.
    /// </summary>
    [JsonPropertyName("joinTimeL")]
    public long? JoinTimeL { get; set; }

    /// <summary>
    /// The name of the consumer.
    /// </summary>
    [JsonPropertyName("consumerName")]
    public string? ConsumerName { get; set; }

    /// <summary>
    /// The dialog identifier associated with the consumer's participation.
    /// </summary>
    [JsonPropertyName("dialogId")]
    public string? DialogId { get; set; }

    private bool Equals(ConsumerParticipant other)
    {
        return Nullable.Equals(ConversationId, other.ConversationId) && ParticipantId == other.ParticipantId &&
               FirstName == other.FirstName && LastName == other.LastName && Token == other.Token && Email == other.Email &&
               Phone == other.Phone && AvatarURL == other.AvatarURL && Time == other.Time && TimeL == other.TimeL &&
               JoinTime == other.JoinTime && JoinTimeL == other.JoinTimeL && ConsumerName == other.ConsumerName &&
               DialogId == other.DialogId;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((ConsumerParticipant)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(ConversationId);
        hashCode.Add(ParticipantId);
        hashCode.Add(FirstName);
        hashCode.Add(LastName);
        hashCode.Add(Token);
        hashCode.Add(Email);
        hashCode.Add(Phone);
        hashCode.Add(AvatarURL);
        hashCode.Add(Time);
        hashCode.Add(TimeL);
        hashCode.Add(JoinTime);
        hashCode.Add(JoinTimeL);
        hashCode.Add(ConsumerName);
        hashCode.Add(DialogId);
        return hashCode.ToHashCode();
    }
}

/// <summary>
/// Represents a transfer in a conversation.
/// </summary>
[Table("LP_Transfers")]
public class Transfer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }

    /// <summary>
    /// The dialog identifier associated with the transfer.
    /// </summary>
    // [Key]
    // [Column(Order = 0)]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("dialogId")]
    public string? DialogId { get; set; }

    // [Key]
    // [Column(Order = 1)]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("conversationId")] public Guid? ConversationId { get; set; }

    /// <summary>
    ///
    /// </summary>
    // [NotMapped]
    [ForeignKey("ConversationId")]
    public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// The timestamp of the transfer in long format.
    /// </summary>
    [JsonPropertyName("timeL")]
    public long? TimeL { get; set; }

    /// <summary>
    /// The timestamp of the transfer.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// The ID of the assigned agent.
    /// </summary>
    [JsonPropertyName("assignedAgentId")]
    public string? AssignedAgentId { get; set; }

    /// <summary>
    /// The ID of the target skill.
    /// </summary>
    [JsonPropertyName("targetSkillId")]
    public long? TargetSkillId { get; set; }

    /// <summary>
    /// The name of the target skill.
    /// </summary>
    [JsonPropertyName("targetSkillName")]
    public string? TargetSkillName { get; set; }

    /// <summary>
    /// The reason for the transfer.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// The ID of the agent who initiated the transfer.
    /// </summary>
    [JsonPropertyName("by")]
    public string? By { get; set; }

    /// <summary>
    /// The ID of the source skill.
    /// </summary>
    [JsonPropertyName("sourceSkillId")]
    public long? SourceSkillId { get; set; }

    /// <summary>
    /// The name of the source skill.
    /// </summary>
    [JsonPropertyName("sourceSkillName")]
    public string? SourceSkillName { get; set; }

    /// <summary>
    /// The ID of the source agent.
    /// </summary>
    [JsonPropertyName("sourceAgentId")]
    public string? SourceAgentId { get; set; }

    /// <summary>
    /// The full name of the source agent.
    /// </summary>
    [JsonPropertyName("sourceAgentFullName")]
    public string? SourceAgentFullName { get; set; }

    /// <summary>
    /// The login name of the source agent.
    /// </summary>
    [JsonPropertyName("sourceAgentLoginName")]
    public string? SourceAgentLoginName { get; set; }

    /// <summary>
    /// The nickname of the source agent.
    /// </summary>
    [JsonPropertyName("sourceAgentNickname")]
    public string? SourceAgentNickname { get; set; }

    private bool Equals(Transfer other)
    {
        return DialogId == other.DialogId && ConversationId.Equals(other.ConversationId) &&
               Equals(ConversationInfo, other.ConversationInfo) && TimeL == other.TimeL && Time == other.Time &&
               AssignedAgentId == other.AssignedAgentId && TargetSkillId == other.TargetSkillId &&
               TargetSkillName == other.TargetSkillName && Reason == other.Reason && By == other.By &&
               SourceSkillId == other.SourceSkillId && SourceSkillName == other.SourceSkillName &&
               SourceAgentId == other.SourceAgentId && SourceAgentFullName == other.SourceAgentFullName &&
               SourceAgentLoginName == other.SourceAgentLoginName && SourceAgentNickname == other.SourceAgentNickname;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Transfer)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(DialogId);
        hashCode.Add(ConversationId);
        hashCode.Add(ConversationInfo);
        hashCode.Add(TimeL);
        hashCode.Add(Time);
        hashCode.Add(AssignedAgentId);
        hashCode.Add(TargetSkillId);
        hashCode.Add(TargetSkillName);
        hashCode.Add(Reason);
        hashCode.Add(By);
        hashCode.Add(SourceSkillId);
        hashCode.Add(SourceSkillName);
        hashCode.Add(SourceAgentId);
        hashCode.Add(SourceAgentFullName);
        hashCode.Add(SourceAgentLoginName);
        hashCode.Add(SourceAgentNickname);
        return hashCode.ToHashCode();
    }
}

/// <summary>
/// Represents an interaction in a conversation.
/// </summary>
[Table("LP_Interaction")]
public class Interaction
{
    /// <summary>
    /// The dialog identifier associated with the interaction.
    /// </summary>
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("dialogId")]
    public string DialogId { get; set; }

    /// <summary>
    /// The sequence number of the interaction.
    /// </summary>
    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("interactiveSequence")]
    public int? InteractiveSequence { get; set; }

    [JsonPropertyName("conversationId")] public Guid ConversationId { get; set; }

    /// <summary>
    ///
    /// </summary>
    // [NotMapped]
    [ForeignKey("ConversationId")]
    public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// The identifier of the assigned agent.
    /// </summary>
    [JsonPropertyName("assignedAgentId")]
    public string? AssignedAgentId { get; set; }

    /// <summary>
    /// The full name of the assigned agent.
    /// </summary>
    [JsonPropertyName("assignedAgentFullName")]
    public string? AssignedAgentFullName { get; set; }

    /// <summary>
    /// The login name of the assigned agent.
    /// </summary>
    [JsonPropertyName("assignedAgentLoginName")]
    public string? AssignedAgentLoginName { get; set; }

    /// <summary>
    /// The nickname of the assigned agent.
    /// </summary>
    [JsonPropertyName("assignedAgentNickname")]
    public string? AssignedAgentNickname { get; set; }

    /// <summary>
    /// The timestamp of the interaction in long format.
    /// </summary>
    [JsonPropertyName("interactionTimeL")]
    public long? InteractionTimeL { get; set; }

    /// <summary>
    /// The timestamp of the interaction.
    /// </summary>
    [JsonPropertyName("interactionTime")]
    public string? InteractionTime { get; set; }

    private bool Equals(Interaction other)
    {
        return DialogId.Equals(other.DialogId) && InteractiveSequence == other.InteractiveSequence;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Interaction)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DialogId, InteractiveSequence);
    }
}

/// <summary>
/// Represents a score for a message in a conversation.
/// </summary>
public class MessageScore
{
    /// <summary>
    /// The unique identifier of the message.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    /// <summary>
    /// The raw score of the message.
    /// </summary>
    [JsonPropertyName("messageRawScore")]
    public int? MessageRawScore { get; set; }

    /// <summary>
    /// The MCS (Meaningful Conversation Score) of the message.
    /// </summary>
    [JsonPropertyName("mcs")]
    public int? Mcs { get; set; }

    /// <summary>
    /// The timestamp of the score.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// The timestamp of the score in long format.
    /// </summary>
    [JsonPropertyName("timeL")]
    public long? TimeL { get; set; }
}

/// <summary>
/// Represents the status of a message in a conversation.
/// </summary>
public class MessageStatus
{
    /// <summary>
    /// The unique identifier of the message.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    /// <summary>
    /// The sequence number of the message.
    /// </summary>
    [JsonPropertyName("seq")]
    public int? Seq { get; set; }

    /// <summary>
    /// The dialog identifier associated with the message.
    /// </summary>
    [JsonPropertyName("dialogId")]
    public string? DialogId { get; set; }

    /// <summary>
    /// The timestamp of the status update.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// The timestamp of the status update in long format.
    /// </summary>
    [JsonPropertyName("timeL")]
    public long? TimeL { get; set; }

    /// <summary>
    /// The identifier of the participant associated with the status.
    /// </summary>
    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; set; }

    /// <summary>
    /// The type of participant (e.g., "Agent" or "Consumer").
    /// </summary>
    [JsonPropertyName("participantType")]
    public string? ParticipantType { get; set; }

    /// <summary>
    /// The delivery status of the message (e.g., "READ", "ACCEPT", "ACTION").
    /// </summary>
    [JsonPropertyName("messageDeliveryStatus")]
    public string? MessageDeliveryStatus { get; set; }

    /// <summary>
    /// Context data associated with the message status.
    /// </summary>
    [JsonPropertyName("contextData")]
    public ContextData? ContextData { get; set; }
}

/// <summary>
/// Represents a survey in a conversation.
/// </summary>
// [Table("LP_ConversationSurvey")]
public class ConversationSurvey
{
    /// <summary>
    /// The type of the survey.
    /// </summary>
    [JsonPropertyName("surveyType")]
    public string? SurveyType { get; set; }

    /// <summary>
    /// The identifier of the survey.
    /// </summary>
    [Key]
    [Column(Order = 0)]
    [JsonPropertyName("surveyId")]
    public string? SurveyId { get; set; }

    [Key]
    [Column(Order = 1)]
    [JsonPropertyName("conversationId")]
    public Guid ConversationId { get; set; }

    [ForeignKey("ConversationId")] public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// The data associated with the survey.
    /// </summary>
    [JsonPropertyName("surveyData")]
    public List<ConversationSurveyData>? SurveyData { get; set; }
}

/// <summary>
/// Represents survey data associated with a conversation in the Liveperson platform.
/// This class is mapped to the "LP_ConversationSurveyData" table in the database.
/// </summary>
[Table("LP_ConversationSurveyData")]
public class ConversationSurveyData
{
    /// <summary>
    /// Gets or sets the primary key identifier for the survey data.
    /// </summary>
    [Key]
    public int PkId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the answer.
    /// </summary>
    [JsonPropertyName("answerId")]
    public string? AnswerId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the conversation this survey is associated with.
    /// </summary>
    [JsonPropertyName("conversationId")]
    public Guid ConversationId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated ConversationInfo.
    /// </summary>
    [ForeignKey("ConversationId")]
    public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// Gets or sets the question text of the survey.
    /// </summary>
    [JsonPropertyName("question")]
    public string? Question { get; set; }

    /// <summary>
    /// Gets or sets the answer text provided in the survey.
    /// </summary>
    [JsonPropertyName("answer")]
    public string? Answer { get; set; }

    /// <summary>
    /// Gets or sets the numeric score derived from the answer.
    /// This property attempts to extract a single-digit score from the beginning of the Answer string.
    /// </summary>
    public int? AnswerScore
    {
        get
        {
            if (string.IsNullOrEmpty(Answer)) return null;

            var chars = Answer.ToCharArray();

            if (chars.Length >= 2 && char.IsDigit(chars[0]) && char.IsWhiteSpace(chars[1]))
            {
                return chars[0] - '0';
            }
            else return null;
        }
        set { }
    }

    /// <summary>
    /// Gets or sets the unique identifier for the question.
    /// </summary>
    [JsonPropertyName("questionId")]
    public string? QuestionId { get; set; }

    /// <summary>
    /// Gets or sets the type of the question.
    /// </summary>
    [JsonPropertyName("questionType")]
    public string? QuestionType { get; set; }

    /// <summary>
    /// Gets or sets the format of the question.
    /// </summary>
    [JsonPropertyName("questionFormat")]
    public string? QuestionFormat { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the answer is valid.
    /// </summary>
    [JsonPropertyName("isValidAnswer")]
    public bool IsValidAnswer { get; set; }

    /// <summary>
    /// Gets or sets the sequence number of the answer.
    /// </summary>
    [JsonPropertyName("answerSeq")]
    public string? AnswerSeq { get; set; }

    /// <summary>
    /// Gets or sets the name of the question.
    /// </summary>
    [JsonPropertyName("questionName")]
    public string? QuestionName { get; set; }

    /// <summary>
    /// Determines whether the specified ConversationSurveyData is equal to the current ConversationSurveyData.
    /// </summary>
    /// <param name="other">The ConversationSurveyData to compare with the current ConversationSurveyData.</param>
    /// <returns>true if the specified ConversationSurveyData is equal to the current ConversationSurveyData; otherwise, false.</returns>
    private bool Equals(ConversationSurveyData other)
    {
        return AnswerId == other.AnswerId && ConversationId.Equals(other.ConversationId) && QuestionId == other.QuestionId &&
               AnswerSeq == other.AnswerSeq;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current ConversationSurveyData.
    /// </summary>
    /// <param name="obj">The object to compare with the current ConversationSurveyData.</param>
    /// <returns>true if the specified object is equal to the current ConversationSurveyData; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((ConversationSurveyData)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current ConversationSurveyData.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(AnswerId, ConversationId, QuestionId, AnswerSeq);
    }
}

/// <summary>
/// Represents a summary of the conversation.
/// </summary>
public class Summary
{
    /// <summary>
    /// The text content of the summary.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// The timestamp of the last update to the summary.
    /// </summary>
    [JsonPropertyName("lastUpdatedTime")]
    public long? LastUpdatedTime { get; set; }

    /// <summary>
    /// The processed conversation summary.
    /// </summary>
    [JsonIgnore]
    public SummaryData? ProcessedSummary
    {
        get
        {
            if (string.IsNullOrEmpty(Text) || Text.Length < 2) return null;
            var processedText = Text.Substring(1, Text.Length - 2);
            return JsonSerializer.Deserialize<SummaryData>(processedText);
        }
    }
}

/// <summary>
/// Represents summary data for a conversation in the Liveperson platform.
/// This class is mapped to the "LP_SummaryData" table in the database.
/// </summary>
[Table("LP_SummaryData")]
public class SummaryData
{
    /// <summary>
    /// Gets or sets the primary key identifier for the summary data.
    /// This is an auto-generated identity column in the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PkId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the conversation this summary is associated with.
    /// </summary>
    [JsonPropertyName("conversationId")]
    public Guid? ConversationId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated ConversationInfo.
    /// This property is used to establish a foreign key relationship with the ConversationInfo table.
    /// </summary>
    [ForeignKey("ConversationId")]
    public ConversationInfo? ConversationInfo { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the agent associated with this summary.
    /// </summary>
    [JsonPropertyName("agentId")]
    public string? AgentId { get; set; }

    /// <summary>
    /// Gets or sets the name associated with this summary.
    /// This could be the name of the agent or another relevant identifier.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the content of the note or summary.
    /// </summary>
    [JsonPropertyName("noteContent")]
    public string? NoteContent { get; set; }

    /// <summary>
    /// Gets or sets the timestamp associated with this summary.
    /// This is likely stored as a Unix timestamp (milliseconds since epoch).
    /// </summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for this note or summary.
    /// </summary>
    [JsonPropertyName("noteId")]
    public string? NoteId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this summary was automatically generated.
    /// </summary>
    [JsonPropertyName("isAutoSummary")]
    public bool? IsAutoSummary { get; set; }

    /// <summary>
    /// Determines whether the specified SummaryData is equal to the current SummaryData.
    /// </summary>
    /// <param name="other">The SummaryData to compare with the current SummaryData.</param>
    /// <returns>true if the specified SummaryData is equal to the current SummaryData; otherwise, false.</returns>
    protected bool Equals(SummaryData other)
    {
        return AgentId == other.AgentId && Name == other.Name && NoteContent == other.NoteContent && Time == other.Time &&
               NoteId == other.NoteId && IsAutoSummary == other.IsAutoSummary;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current SummaryData.
    /// </summary>
    /// <param name="obj">The object to compare with the current SummaryData.</param>
    /// <returns>true if the specified object is equal to the current SummaryData; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((SummaryData)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current SummaryData.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(AgentId, Name, NoteContent, Time, NoteId, IsAutoSummary);
    }
}