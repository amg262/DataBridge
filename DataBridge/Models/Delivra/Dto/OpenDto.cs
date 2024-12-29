using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra.Dto;

/// <summary>
/// Represents an open event for a report in Delivra.
/// </summary>
public record OpenDto
{
    // /// <summary>
    // /// Gets or inits the internal primary key for the Open table. This value is not from the API.
    // /// </summary>
    // [Description("Internal Primary key for the Open table. Not from API")]
    // public int PkId { get; init; }

    /// <summary>
    /// Gets or inits the email address of the recipient who opened the email.
    /// </summary>
    [JsonPropertyName("EmailAddress")]
    [Description("The email address of the recipient who opened the email")]
    public string? EmailAddress { get; init; }

    /// <summary>
    /// Gets or inits the date and time of the event.
    /// </summary>
    [JsonPropertyName("EventTime")]
    [Description("The date and time of the event")]
    public DateTime? EventTime { get; init; }

    /// <summary>
    /// Gets or inits the ID of the mailing that was opened.
    /// </summary>
    [JsonPropertyName("MailingID")]
    [Description("The ID of the mailing that was opened")]
    public int? MailingID { get; init; }

    /// <summary>
    /// Gets or inits the ID of the member who opened the email.
    /// </summary>
    [JsonPropertyName("MemberID")]
    [Description("The ID of the member who opened the email")]
    public int? MemberID { get; init; }

    /// <summary>
    /// Gets or inits the IP address of the recipient who opened the email.
    /// </summary>
    [JsonPropertyName("IPAddress")]
    [Description("The IP address of the recipient who opened the email")]
    public string? IPAddress { get; init; }

    /// <summary>
    /// Gets or inits the contact engagement score.
    /// </summary>
    [JsonPropertyName("ContactEngagement")]
    [Description("The contact engagement score")]
    public double? ContactEngagement { get; init; }

    /// <summary>
    /// Gets or inits the platform used to open the email.
    /// </summary>
    [JsonPropertyName("Platform")]
    [Description("The platform used to open the email")]
    public string? Platform { get; init; }

    /// <summary>
    /// Gets or inits the platform version used to open the email.
    /// </summary>
    [JsonPropertyName("PlatformVersion")]
    [Description("The platform version used to open the email")]
    public string? PlatformVersion { get; init; }

    /// <summary>
    /// Gets or inits the browser used to open the email.
    /// </summary>
    [JsonPropertyName("Browser")]
    [Description("The browser used to open the email")]
    public string? Browser { get; init; }

    /// <summary>
    /// Gets or inits the browser version used to open the email.
    /// </summary>
    [JsonPropertyName("BrowserVersion")]
    [Description("The browser version used to open the email")]
    public string? BrowserVersion { get; init; }

    /// <summary>
    /// Gets or inits the reading environment in which the email was opened.
    /// </summary>
    [JsonPropertyName("ReadingEnvironment")]
    [Description("The reading environment in which the email was opened")]
    public string? ReadingEnvironment { get; init; }

    /// <summary>
    /// Determines whether the specified <see cref="OpenDto"/> is equal to the current <see cref="OpenDto"/>.
    /// </summary>
    /// <param name="other">The <see cref="OpenDto"/> to compare with the current <see cref="OpenDto"/>.</param>
    /// <returns>true if the specified <see cref="OpenDto"/> is equal to the current <see cref="OpenDto"/>; otherwise, false.</returns>
    public virtual bool Equals(OpenDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EmailAddress == other.EmailAddress && Nullable.Equals(EventTime, other.EventTime) &&
               MailingID == other.MailingID && MemberID == other.MemberID && IPAddress == other.IPAddress &&
               Nullable.Equals(ContactEngagement, other.ContactEngagement) && Platform == other.Platform &&
               PlatformVersion == other.PlatformVersion && Browser == other.Browser && BrowserVersion == other.BrowserVersion &&
               ReadingEnvironment == other.ReadingEnvironment;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current <see cref="OpenDto"/>.</returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(EmailAddress);
        hashCode.Add(EventTime);
        hashCode.Add(MailingID);
        hashCode.Add(MemberID);
        hashCode.Add(IPAddress);
        hashCode.Add(ContactEngagement);
        hashCode.Add(Platform);
        hashCode.Add(PlatformVersion);
        hashCode.Add(Browser);
        hashCode.Add(BrowserVersion);
        hashCode.Add(ReadingEnvironment);
        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Returns a string that represents the current <see cref="OpenDto"/>.
    /// </summary>
    /// <returns>A string that represents the current <see cref="OpenDto"/>.</returns>
    public override string ToString()
    {
        return
            $" {nameof(EmailAddress)}: {EmailAddress}, {nameof(EventTime)}: {EventTime}," +
            $" {nameof(MailingID)}: {MailingID}, {nameof(MemberID)}: {MemberID}, {nameof(IPAddress)}: {IPAddress}," +
            $" {nameof(ContactEngagement)}: {ContactEngagement}, {nameof(Platform)}: {Platform}, {nameof(PlatformVersion)}: {PlatformVersion}," +
            $" {nameof(Browser)}: {Browser}, {nameof(BrowserVersion)}: {BrowserVersion}, {nameof(ReadingEnvironment)}: {ReadingEnvironment}";
    }
}