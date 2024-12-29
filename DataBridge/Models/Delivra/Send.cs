using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra;

/// <summary>
/// Represents a send event for a report in Delivra.
/// </summary>
public class Send
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Description("Internal Primary key for the Send table. Not from API")]
    public int PkId { get; set; }

    /// <summary>
    /// Gets or sets the email address of the recipient.
    /// </summary>
    [JsonPropertyName("EmailAddress")]
    [Description("The email address of the recipient.")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the ID of the member who received the email.
    /// </summary>
    [JsonPropertyName("MemberID")]
    [Description("The ID of the member who received the email.")]
    public int? MemberID { get; set; }

    /// <summary>
    /// Gets or sets the ID of the mailing that was sent.
    /// </summary>
    [JsonPropertyName("MailingID")]
    [Description("The ID of the mailing that was sent.")]
    public int? MailingID { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the event.
    /// </summary>
    [JsonPropertyName("EventTime")]
    [Description("The date and time of the event.")]
    public DateTime? EventTime { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="Send"/> is equal to the current <see cref="Send"/>.
    /// </summary>
    /// <param name="other">The <see cref="Send"/> to compare with the current <see cref="Send"/>.</param>
    /// <returns>true if the specified <see cref="Send"/> is equal to the current <see cref="Send"/>; otherwise, false.</returns>
    private bool Equals(Send other)
    {
        return EmailAddress == other.EmailAddress && MemberID == other.MemberID && MailingID == other.MailingID &&
               EventTime.Equals(other.EventTime);
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
        return obj.GetType() == GetType() && Equals((Send)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(EmailAddress, MemberID, MailingID, EventTime);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(EmailAddress)}: {EmailAddress}, {nameof(MemberID)}: {MemberID}, {nameof(MailingID)}: {MailingID}, {nameof(EventTime)}: {EventTime}";
    }
}