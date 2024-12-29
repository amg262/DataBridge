using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra;

/// <summary>
/// Represents the model for the JSON response containing clickthrough details.
/// </summary>
public class Clickthrough
{
    /// <summary>
    /// Gets or sets the internal ID - primary key ID.
    /// </summary>
    [Key]
    [Description("Internal Primary key for the Clickthrough table. Not from API")]
    public int? PkId { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the event.
    /// </summary>
    [JsonPropertyName("EmailAddress")]
    [Description("The email address associated with the event")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the member ID associated with the event.
    /// </summary>
    [JsonPropertyName("MemberID")]
    [Description("The member ID associated with the event")]
    public int? MemberID { get; set; }

    /// <summary>
    /// Gets or sets the mailing ID associated with the event.
    /// </summary>
    [JsonPropertyName("MailingID")]
    [Description("The mailing ID associated with the event")]
    public int? MailingID { get; set; }

    /// <summary>
    /// Gets or sets the event time.
    /// </summary>
    [JsonPropertyName("EventTime")]
    [Description("The date and time of the event")]
    public DateTime? EventTime { get; set; }

    /// <summary>
    /// Gets or sets the URI associated with the event.
    /// </summary>
    [JsonPropertyName("URI")]
    [Description("The URI associated with the event")]
    public string? URI { get; set; }

    /// <summary>
    /// Gets or sets the name associated with the event.
    /// </summary>
    [JsonPropertyName("Name")]
    [Description("The name associated with the event")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the IP address associated with the event.
    /// </summary>
    [JsonPropertyName("IPAddress")]
    [Description("The IP address associated with the event")]
    public string? IPAddress { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="Clickthrough"/> is equal to the current <see cref="Clickthrough"/>.
    /// </summary>
    /// <param name="other">The <see cref="Clickthrough"/> to compare with the current <see cref="Clickthrough"/>.</param>
    /// <returns>true if the specified <see cref="Clickthrough"/> is equal to the current <see cref="Clickthrough"/>; otherwise, false.</returns>
    private bool Equals(Clickthrough other)
    {
        return EmailAddress == other.EmailAddress && MemberID == other.MemberID && MailingID == other.MailingID &&
               Nullable.Equals(EventTime, other.EventTime) && URI == other.URI && Name == other.Name &&
               IPAddress == other.IPAddress;
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
        return obj.GetType() == GetType() && Equals((Clickthrough)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(EmailAddress, MemberID, MailingID, EventTime, URI, Name, IPAddress);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(PkId)}: {PkId}, {nameof(EmailAddress)}: {EmailAddress}, {nameof(MemberID)}: {MemberID}, " +
            $"{nameof(MailingID)}: {MailingID}, {nameof(EventTime)}: {EventTime}, {nameof(URI)}: {URI}, {nameof(Name)}: " +
            $"{Name}, {nameof(IPAddress)}: {IPAddress}";
    }
}