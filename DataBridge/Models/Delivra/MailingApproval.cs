using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra;

/// <summary>
/// Represents the mailing approval details.
/// </summary>
public class MailingApproval
{
    /// <summary>
    /// Gets or sets the message ID of the mailing.
    /// </summary>
    [JsonPropertyName("MessageID")]
    [Description("The message ID of the mailing.")]
    public int? MessageID { get; set; }

    /// <summary>
    /// Primary key ID for internal use.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Description("Internal Primary key for the MailingApproval table. Not from API.")]
    public int? PkId { get; set; }

    /// <summary>
    /// Gets or sets the body content of the mailing.
    /// </summary>
    [JsonPropertyName("Body")]
    [Description("The body content of the mailing.")]
    public string? Body { get; set; }

    /// <summary>
    /// Gets or sets the entire header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderAll")]
    [Description("The entire header of the mailing.")]
    public string? HeaderAll { get; set; }

    /// <summary>
    /// Gets or sets the date in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderDate")]
    [Description("The date in the header of the mailing.")]
    public string? HeaderDate { get; set; }

    /// <summary>
    /// Gets or sets the 'From' field in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderFrom")]
    [Description("The 'From' field in the header of the mailing.")]
    public string? HeaderFrom { get; set; }

    /// <summary>
    /// Gets or sets the email address in the 'From' field in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderFromSpc")]
    [Description("The email address in the 'From' field in the header of the mailing.")]
    public string? HeaderFromSpc { get; set; }

    /// <summary>
    /// Gets or sets the subject in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderSubject")]
    [Description("The subject in the header of the mailing.")]
    public string? HeaderSubject { get; set; }

    /// <summary>
    /// Gets or sets the 'To' field in the header of the mailing.
    /// </summary>
    [JsonPropertyName("HeaderTo")]
    [Description("The 'To' field in the header of the mailing.")]
    public string? HeaderTo { get; set; }

    /// <summary>
    /// Gets or sets the list associated with the mailing.
    /// </summary>
    [JsonPropertyName("List")]
    [Description("The list associated with the mailing.")]
    public string? List { get; set; }

    /// <summary>
    /// Gets or sets the maximum recipients for the mailing.
    /// </summary>
    [JsonPropertyName("MaxRecips")]
    [Description("The maximum recipients for the mailing.")]
    public int? MaxRecips { get; set; }

    /// <summary>
    /// Gets or sets the resubmit flag for the mailing.
    /// </summary>
    [JsonPropertyName("ReSubmit")]
    [Description("The resubmit flag for the mailing.")]
    public int? ReSubmit { get; set; }

    /// <summary>
    /// Gets or sets the status of the mailing.
    /// </summary>
    [JsonPropertyName("Status")]
    [Description("The status of the mailing.")]
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the subset ID of the mailing.
    /// </summary>
    [JsonPropertyName("SubsetID")]
    [Description("The subset ID of the mailing.")]
    public int? SubsetID { get; set; }

    /// <summary>
    /// Gets or sets the title of the mailing.
    /// </summary>
    [JsonPropertyName("Title")]
    [Description("The title of the mailing.")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the transaction details of the mailing.
    /// </summary>
    [JsonPropertyName("Transact")]
    [Description("The transaction details of the mailing.")]
    public string? Transact { get; set; }

    /// <summary>
    /// Gets or sets the type of the mailing.
    /// </summary>
    [JsonPropertyName("Type")]
    [Description("The type of the mailing.")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the updated date of the mailing.
    /// </summary>
    [JsonPropertyName("UpdatedDate")]
    [Description("The updated date of the mailing.")]
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Gets or sets the file unique identifier.
    /// </summary>
    [JsonPropertyName("FileUID")]
    [Description("The file unique identifier.")]
    public string? FileUID { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the mailing should be published on send.
    /// </summary>
    [JsonPropertyName("PublishOnSend")]
    [Description("Indicates whether the mailing should be published on send.")]
    public bool? PublishOnSend { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the mailing should be posted on Facebook.
    /// </summary>
    [JsonPropertyName("FacebookPost")]
    [Description("Indicates whether the mailing should be posted on Facebook.")]
    public bool? FacebookPost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the mailing should be tweeted on Twitter.
    /// </summary>
    [JsonPropertyName("TwitterTweet")]
    [Description("Indicates whether the mailing should be tweeted on Twitter.")]
    public bool? TwitterTweet { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the mailing should be posted on LinkedIn.
    /// </summary>
    [JsonPropertyName("LinkedInPost")]
    [Description("Indicates whether the mailing should be posted on LinkedIn.")]
    public bool? LinkedInPost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the mailing should be sent based on the recipient's time zone.
    /// </summary>
    [JsonPropertyName("TimeZoneSend")]
    [Description("Indicates whether the mailing should be sent based on the recipient's time zone.")]
    public bool? TimeZoneSend { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the send time should be optimized.
    /// </summary>
    [JsonPropertyName("SendTimeOptimize")]
    [Description("Indicates whether the send time should be optimized.")]
    public bool? SendTimeOptimize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the send frequency should be overridden.
    /// </summary>
    [JsonPropertyName("SendFrequencyOverride")]
    [Description("Indicates whether the send frequency should be overridden.")]
    public bool? SendFrequencyOverride { get; set; }

    /// <summary>
    /// Gets or sets the footer value of the mailing.
    /// </summary>
    [JsonPropertyName("Footer")]
    [Description("The footer value of the mailing.")]
    public int? Footer { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="MailingApproval"/> is equal to the current <see cref="MailingApproval"/>.
    /// </summary>
    /// <param name="other">The <see cref="MailingApproval"/> to compare with the current <see cref="MailingApproval"/>.</param>
    /// <returns>true if the specified <see cref="MailingApproval"/> is equal to the current <see cref="MailingApproval"/>; otherwise, false.</returns>
    private bool Equals(MailingApproval other)
    {
        return MessageID == other.MessageID;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((MailingApproval)obj);
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
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(MessageID)}: {MessageID}, {nameof(PkId)}: {PkId}, {nameof(Body)}: {Body}, {nameof(HeaderAll)}: " +
            $"{HeaderAll}, {nameof(HeaderDate)}: {HeaderDate}, {nameof(HeaderFrom)}: {HeaderFrom}, {nameof(HeaderFromSpc)}: " +
            $"{HeaderFromSpc}, {nameof(HeaderSubject)}: {HeaderSubject}, {nameof(HeaderTo)}: {HeaderTo}, {nameof(List)}: {List}, " +
            $"{nameof(MaxRecips)}: {MaxRecips}, {nameof(ReSubmit)}: {ReSubmit}, {nameof(Status)}: {Status}, {nameof(SubsetID)}: " +
            $"{SubsetID}, {nameof(Title)}: {Title}, {nameof(Transact)}: {Transact}, {nameof(Type)}: {Type}, {nameof(UpdatedDate)}: " +
            $"{UpdatedDate}, {nameof(FileUID)}: {FileUID}, {nameof(PublishOnSend)}: {PublishOnSend}, {nameof(FacebookPost)}: " +
            $"{FacebookPost}, {nameof(TwitterTweet)}: {TwitterTweet}, {nameof(LinkedInPost)}: {LinkedInPost}, " +
            $"{nameof(TimeZoneSend)}: {TimeZoneSend}, {nameof(SendTimeOptimize)}: {SendTimeOptimize}, {nameof(SendFrequencyOverride)}:" +
            $" {SendFrequencyOverride}, {nameof(Footer)}: {Footer}";
    }
}