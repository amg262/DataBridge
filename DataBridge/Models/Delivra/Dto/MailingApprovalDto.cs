using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra.Dto;

/// <summary>
/// Represents a Dto object received from MailingApproval requests.
/// </summary>
public record MailingApprovalDto
{
    // /// <summary>
    // /// Primary key ID for internal use.
    // /// </summary>
    // [Description("Primary key ID for internal use.")]
    // public int? PkId { get; init; }

    /// <summary>
    /// Gets or inits the body content of the mailing.
    /// </summary>
    [JsonPropertyName("Body")]
    [Description("The body content of the mailing.")]
    public string? Body { get; init; }

    /// <summary>
    /// Gets or inits the entire header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderAll")]
    [Description("The entire header of the mailing.")]
    public string? HeaderAll { get; init; }

    /// <summary>
    /// Gets or inits the date in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderDate")]
    [Description("The date in the header of the mailing.")]
    public string? HeaderDate { get; init; }

    /// <summary>
    /// Gets or inits the 'From' field in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderFrom")]
    [Description("The 'From' field in the header of the mailing.")]
    public string? HeaderFrom { get; init; }

    /// <summary>
    /// Gets or inits the email address in the 'From' field in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderFromSpc")]
    [Description("The email address in the 'From' field in the header of the mailing.")]
    public string? HeaderFromSpc { get; init; }

    /// <summary>
    /// Gets or inits the subject in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderSubject")]
    [Description("The subject in the header of the mailing.")]
    public string? HeaderSubject { get; init; }

    /// <summary>
    /// Gets or inits the 'To' field in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderTo")]
    [Description("The 'To' field in the header of the mailing.")]
    public string? HeaderTo { get; init; }

    /// <summary>
    /// Gets or inits the list associated with the mailing.
    /// </summary>
    [JsonPropertyName("List")]
    [Description("The list associated with the mailing.")]
    public string? List { get; init; }

    /// <summary>
    /// Gets or inits the maximum recipients for the mailing.
    /// </summary>
    [JsonPropertyName("MaxRecips")]
    [Description("The maximum number of recipients for the mailing.")]
    public int? MaxRecips { get; init; }

    /// <summary>
    /// Gets or inits the message ID of the mailing.
    /// </summary>
    [JsonPropertyName("MessageID")]
    [Description("The message ID of the mailing.")]
    public int? MessageID { get; init; }

    /// <summary>
    /// Gets or inits the resubmit flag for the mailing.
    /// </summary>
    [JsonPropertyName("ReSubmit")]
    [Description("The resubmit flag for the mailing.")]
    public int? ReSubmit { get; init; }

    /// <summary>
    /// Gets or inits the status of the mailing.
    /// </summary>
    [JsonPropertyName("Status")]
    [Description("The status of the mailing.")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets or inits the subinit ID of the mailing.
    /// </summary>
    [JsonPropertyName("SubinitID")]
    [Description("The subinit ID of the mailing.")]
    public int? SubinitID { get; init; }

    /// <summary>
    /// Gets or inits the title of the mailing.
    /// </summary>
    [JsonPropertyName("Title")]
    [Description("The title of the mailing.")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets or inits the transaction details of the mailing.
    /// </summary>
    [JsonPropertyName("Transact")]
    [Description("The transaction details of the mailing.")]
    public string? Transact { get; init; }

    /// <summary>
    /// Gets or inits the type of the mailing.
    /// </summary>
    [JsonPropertyName("Type")]
    [Description("The type of the mailing.")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets or inits the updated date of the mailing.
    /// </summary>
    [JsonPropertyName("UpdatedDate")]
    [Description("The updated date of the mailing.")]
    public DateTime? UpdatedDate { get; init; }

    /// <summary>
    /// Gets or inits the file unique identifier.
    /// </summary>
    [JsonPropertyName("FileUID")]
    [Description("The unique identifier for the file associated with the mailing.")]
    public string? FileUID { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the mailing should be published on send.
    /// </summary>
    [JsonPropertyName("PublishOnSend")]
    [Description("Indicates whether the mailing should be published on send.")]
    public bool? PublishOnSend { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the mailing should be posted on Facebook.
    /// </summary>
    [JsonPropertyName("FacebookPost")]
    [Description("Indicates whether the mailing should be posted on Facebook.")]
    public bool? FacebookPost { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the mailing should be tweeted on Twitter.
    /// </summary>
    [JsonPropertyName("TwitterTweet")]
    [Description("Indicates whether the mailing should be tweeted on Twitter.")]
    public bool? TwitterTweet { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the mailing should be posted on LinkedIn.
    /// </summary>
    [JsonPropertyName("LinkedInPost")]
    [Description("Indicates whether the mailing should be posted on LinkedIn.")]
    public bool? LinkedInPost { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the mailing should be sent based on the recipient's time zone.
    /// </summary>
    [JsonPropertyName("TimeZoneSend")]
    [Description("Indicates whether the mailing should be sent based on the recipient's time zone.")]
    public bool? TimeZoneSend { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the send time should be optimized.
    /// </summary>
    [JsonPropertyName("SendTimeOptimize")]
    [Description("Indicates whether the send time should be optimized.")]
    public bool? SendTimeOptimize { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the send frequency should be overridden.
    /// </summary>
    [JsonPropertyName("SendFrequencyOverride")]
    [Description("Indicates whether the send frequency should be overridden.")]
    public bool? SendFrequencyOverride { get; init; }

    /// <summary>
    /// Gets or inits the footer value of the mailing.
    /// </summary>
    [JsonPropertyName("Footer")]
    [Description("The footer value of the mailing.")]
    public int? Footer { get; init; }

    /// <summary>
    /// Determines whether the specified MailingApprovalDto is equal to the current MailingApprovalDto.
    /// </summary>
    /// <param name="other">The MailingApprovalDto to compare with the current MailingApprovalDto.</param>
    /// <returns>true if the specified MailingApprovalDto is equal to the current MailingApprovalDto; otherwise, false.</returns>
    public virtual bool Equals(MailingApprovalDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return MessageID == other.MessageID;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return MessageID.GetHashCode();
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents a <see cref="MailingApprovalDto"/></returns>
    public override string ToString()
    {
        return
            $"{nameof(Body)}: {Body}, {nameof(HeaderAll)}: {HeaderAll}, {nameof(HeaderDate)}: " +
            $"{HeaderDate}, {nameof(HeaderFrom)}: {HeaderFrom}, {nameof(HeaderFromSpc)}: {HeaderFromSpc}, " +
            $"{nameof(HeaderSubject)}: {HeaderSubject}, {nameof(HeaderTo)}: {HeaderTo}, {nameof(List)}: {List}, " +
            $"{nameof(MaxRecips)}: {MaxRecips}, {nameof(MessageID)}: {MessageID}, {nameof(ReSubmit)}: {ReSubmit}, " +
            $"{nameof(Status)}: {Status}, {nameof(SubinitID)}: {SubinitID}, {nameof(Title)}: {Title}, {nameof(Transact)}: " +
            $"{Transact}, {nameof(Type)}: {Type}, {nameof(UpdatedDate)}: {UpdatedDate}, {nameof(FileUID)}: {FileUID}, " +
            $"{nameof(PublishOnSend)}: {PublishOnSend}, {nameof(FacebookPost)}: {FacebookPost}, {nameof(TwitterTweet)}: " +
            $"{TwitterTweet}, {nameof(LinkedInPost)}: {LinkedInPost}, {nameof(TimeZoneSend)}: {TimeZoneSend}, " +
            $"{nameof(SendTimeOptimize)}: {SendTimeOptimize}, {nameof(SendFrequencyOverride)}: {SendFrequencyOverride}, " +
            $"{nameof(Footer)}: {Footer}";
    }
}