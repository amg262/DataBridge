using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra.Dto;

/// <summary>
/// Represents the model for the JSON response containing clickthrough details.
/// </summary>
public record ClickthroughDto
{
    // /// <summary>
    // /// Gets or inits the internal ID - primary key ID.
    // /// </summary>
    // [Key]
    // [Description("The internal ID - primary key ID.")]
    // public int? PkId { get; init; }

    /// <summary>
    /// Gets or inits the email address associated with the event.
    /// </summary>
    [JsonPropertyName("EmailAddress")]
    [Description("The email address associated with the event.")]
    public string? EmailAddress { get; init; }

    /// <summary>
    /// Gets or inits the member ID associated with the event.
    /// </summary>
    [JsonPropertyName("MemberID")]
    [Description("The member ID associated with the event.")]
    public int? MemberID { get; init; }

    /// <summary>
    /// Gets or inits the mailing ID associated with the event.
    /// </summary>
    [JsonPropertyName("MailingID")]
    [Description("The mailing ID associated with the event.")]
    public int? MailingID { get; init; }

    /// <summary>
    /// Gets or inits the event time.
    /// </summary>
    [JsonPropertyName("EventTime")]
    [Description("The event time.")]
    public DateTime? EventTime { get; init; }

    /// <summary>
    /// Gets or inits the URI associated with the event.
    /// </summary>
    [JsonPropertyName("URI")]
    [Description("The URI associated with the event.")]
    public string? URI { get; init; }

    /// <summary>
    /// Gets or inits the name associated with the event.
    /// </summary>
    [JsonPropertyName("Name")]
    [Description("The name associated with the event.")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or inits the IP address associated with the event.
    /// </summary>
    [JsonPropertyName("IPAddress")]
    [Description("The IP address associated with the event.")]
    public string? IPAddress { get; init; }


    /// <summary>
    /// Determines whether the specified <see cref="ClickthroughDto"/> is equal to the current <see cref="ClickthroughDto"/>.
    /// </summary>
    /// <param name="other">The <see cref="ClickthroughDto"/> to compare with the current <see cref="ClickthroughDto"/>.</param>
    /// <returns>true if the specified <see cref="ClickthroughDto"/> is equal to the current <see cref="ClickthroughDto"/>; otherwise, false.</returns>
    public virtual bool Equals(ClickthroughDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EmailAddress == other.EmailAddress && MemberID == other.MemberID && MailingID == other.MailingID &&
               Nullable.Equals(EventTime, other.EventTime) && URI == other.URI && Name == other.Name &&
               IPAddress == other.IPAddress;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current <see cref="ClickthroughDto"/>.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(EmailAddress, MemberID, MailingID, EventTime, URI, Name, IPAddress);
    }

    /// <summary>
    /// Returns a string that represents the current ClickthroughDto.
    /// </summary>
    /// <returns>A string that represents the current ClickthroughDto.</returns>
    public override string ToString()
    {
        return
            $"{nameof(EmailAddress)}: {EmailAddress}, {nameof(MemberID)}: {MemberID}, " +
            $"{nameof(MailingID)}: {MailingID}, {nameof(EventTime)}: {EventTime}, {nameof(URI)}: {URI}, {nameof(Name)}: " +
            $"{Name}, {nameof(IPAddress)}: {IPAddress}";
    }
}