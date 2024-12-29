﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra;

/// <summary>
/// Represents an open event for a report in Delivra.
/// </summary>
public class Open
{
    /// <summary>
    /// Gets the internal primary key for the Open table. This value is generated by the database and is not from the API.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Description("Internal Primary key for the Open table. Not from API")]
    public int PkId { get; set; }

    /// <summary>
    /// Gets or sets the email address of the recipient who opened the email.
    /// </summary>
    [JsonPropertyName("EmailAddress")]
    [Description("The email address of the recipient who opened the email")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the event.
    /// </summary>
    [JsonPropertyName("EventTime")]
    [Description("The date and time of the event")]
    public DateTime? EventTime { get; set; }

    /// <summary>
    /// Gets or sets the ID of the mailing that was opened.
    /// </summary>
    [JsonPropertyName("MailingID")]
    [Description("The ID of the mailing that was opened")]
    public int? MailingID { get; set; }

    /// <summary>
    /// Gets or sets the ID of the member who opened the email.
    /// </summary>
    [JsonPropertyName("MemberID")]
    [Description("The ID of the member who opened the email")]
    public int? MemberID { get; set; }

    /// <summary>
    /// Gets or sets the IP address of the recipient who opened the email.
    /// </summary>
    [JsonPropertyName("IPAddress")]
    [Description("The IP address of the recipient who opened the email")]
    public string? IPAddress { get; set; }

    /// <summary>
    /// Gets or sets the contact engagement score.
    /// </summary>
    [JsonPropertyName("ContactEngagement")]
    [Description("The contact engagement score")]
    public double? ContactEngagement { get; set; }

    /// <summary>
    /// Gets or sets the platform used to open the email.
    /// </summary>
    [JsonPropertyName("Platform")]
    [Description("The platform used to open the email")]
    public string? Platform { get; set; }

    /// <summary>
    /// Gets or sets the platform version used to open the email.
    /// </summary>
    [JsonPropertyName("PlatformVersion")]
    [Description("The platform version used to open the email")]
    public string? PlatformVersion { get; set; }

    /// <summary>
    /// Gets or sets the browser used to open the email.
    /// </summary>
    [JsonPropertyName("Browser")]
    [Description("The browser used to open the email")]
    public string? Browser { get; set; }

    /// <summary>
    /// Gets or sets the browser version used to open the email.
    /// </summary>
    [JsonPropertyName("BrowserVersion")]
    [Description("The browser version used to open the email")]
    public string? BrowserVersion { get; set; }

    /// <summary>
    /// Gets or sets the reading environment in which the email was opened.
    /// </summary>
    [JsonPropertyName("ReadingEnvironment")]
    [Description("The reading environment in which the email was opened")]
    public string? ReadingEnvironment { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="Open"/> is equal to the current <see cref="Open"/>.
    /// </summary>
    /// <param name="other">The <see cref="Open"/> to compare with the current <see cref="Open"/>.</param>
    /// <returns>true if the specified <see cref="Open"/> is equal to the current <see cref="Open"/>; otherwise, false.</returns>
    private bool Equals(Open other)
    {
        return EmailAddress == other.EmailAddress && Nullable.Equals(EventTime, other.EventTime) &&
               MailingID == other.MailingID && MemberID == other.MemberID && IPAddress == other.IPAddress &&
               Nullable.Equals(ContactEngagement, other.ContactEngagement) && Platform == other.Platform &&
               PlatformVersion == other.PlatformVersion && Browser == other.Browser && BrowserVersion == other.BrowserVersion &&
               ReadingEnvironment == other.ReadingEnvironment;
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
        return obj.GetType() == GetType() && Equals((Open)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
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
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(PkId)}: {PkId}, {nameof(EmailAddress)}: {EmailAddress}, {nameof(EventTime)}: {EventTime}," +
            $" {nameof(MailingID)}: {MailingID}, {nameof(MemberID)}: {MemberID}, {nameof(IPAddress)}: {IPAddress}," +
            $" {nameof(ContactEngagement)}: {ContactEngagement}, {nameof(Platform)}: {Platform}, {nameof(PlatformVersion)}: {PlatformVersion}," +
            $" {nameof(Browser)}: {Browser}, {nameof(BrowserVersion)}: {BrowserVersion}, {nameof(ReadingEnvironment)}: {ReadingEnvironment}";
    }
}