using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra.Dto;

/// <summary>
/// Represents a send event for a report in Delivra.
/// </summary>
public record SendDto
{
    /// <summary>
    /// Gets or inits the email address of the recipient.
    /// </summary>
    [JsonPropertyName("EmailAddress")]
    [Description("The email address of the recipient.")]
    public string? EmailAddress { get; init; }

    /// <summary>
    /// Gets or inits the ID of the member who received the email.
    /// </summary>
    [JsonPropertyName("MemberID")]
    [Description("The ID of the member who received the email.")]
    public int? MemberID { get; init; }

    /// <summary>
    /// Gets or inits the ID of the mailing that was sent.
    /// </summary>
    [JsonPropertyName("MailingID")]
    [Description("The ID of the mailing that was sent.")]
    public int? MailingID { get; init; }

    /// <summary>
    /// Gets or inits the date and time of the event.
    /// </summary>
    [JsonPropertyName("EventTime")]
    [Description("The date and time of the event.")]
    public DateTime? EventTime { get; init; }

    /// <summary>
    /// Determines whether the specified <see cref="SendDto"/> is equal to the current <see cref="SendDto"/>.
    /// </summary>
    /// <param name="other">The <see cref="SendDto"/> to compare with the current <see cref="SendDto"/>.</param>
    /// <returns>true if the specified <see cref="SendDto"/> is equal to the current <see cref="SendDto"/>; otherwise, false.</returns>
    public virtual bool Equals(SendDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EmailAddress == other.EmailAddress && MemberID == other.MemberID && MailingID == other.MailingID &&
               EventTime.Equals(other.EventTime);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current <see cref="SendDto"/>.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(EmailAddress, MemberID, MailingID, EventTime);
    }

    /// <summary>
    /// Returns a string that represents the current <see cref="SendDto"/>.
    /// </summary>
    /// <returns>A string that represents the current <see cref="SendDto"/>.</returns>
    public override string ToString()
    {
        return
            $"{nameof(EmailAddress)}: {EmailAddress}, {nameof(MemberID)}: {MemberID}, {nameof(MailingID)}: {MailingID}, {nameof(EventTime)}: {EventTime}";
    }
}