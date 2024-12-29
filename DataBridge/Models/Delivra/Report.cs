using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra;

/// <summary>
/// Represents a report with various metrics and properties.
/// </summary>
public class Report
{
    // /// <summary>
    // /// Gets or sets the identifier of the report.
    // /// </summary>
    // [Key]
    // public int? PkId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the report.
    /// </summary>
    [Key]
    [JsonPropertyName("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the active status of the report.
    /// </summary>
    [JsonPropertyName("active")]
    public int? Active { get; set; }

    /// <summary>
    /// Gets or sets the paused status of the report.
    /// </summary>
    [JsonPropertyName("paused")]
    public int? Paused { get; set; }

    /// <summary>
    /// Gets or sets the number of emails mailed.
    /// </summary>
    [JsonPropertyName("mailed")]
    public int? Mailed { get; set; }

    /// <summary>
    /// Gets or sets the number of emails received.
    /// </summary>
    [JsonPropertyName("received")]
    public int? Received { get; set; }

    /// <summary>
    /// Gets or sets the number of email opens.
    /// </summary>
    [JsonPropertyName("opens")]
    public int? Opens { get; set; }

    /// <summary>
    /// Gets or sets the total number of clicks.
    /// </summary>
    [JsonPropertyName("total_clicks")]
    public int? TotalClicks { get; set; }

    /// <summary>
    /// Gets or sets the number of unique clicks.
    /// </summary>
    [JsonPropertyName("unique_clicks")]
    public int? UniqueClicks { get; set; }

    /// <summary>
    /// Gets or sets the number of transactions.
    /// </summary>
    [JsonPropertyName("trans")]
    public int? Trans { get; set; }

    /// <summary>
    /// Gets or sets the total transaction amount.
    /// </summary>
    [JsonPropertyName("trans_amt")]
    public decimal? TransAmt { get; set; }

    /// <summary>
    /// Gets or sets the number of soft failures.
    /// </summary>
    [JsonPropertyName("soft_fails")]
    public int? SoftFails { get; set; }

    /// <summary>
    /// Gets or sets the number of hard failures.
    /// </summary>
    [JsonPropertyName("hard_fails")]
    public int? HardFails { get; set; }

    /// <summary>
    /// Gets or sets the number of permanent failures.
    /// </summary>
    [JsonPropertyName("perm_fails")]
    public int? PermFails { get; set; }

    /// <summary>
    /// Gets or sets the number of DNS temporary failures.
    /// </summary>
    [JsonPropertyName("dns_temps")]
    public int? DnsTemps { get; set; }

    /// <summary>
    /// Gets or sets the number of bad domains.
    /// </summary>
    [JsonPropertyName("bad_doms")]
    public int? BadDoms { get; set; }

    /// <summary>
    /// Gets or sets the number of bounces.
    /// </summary>
    [JsonPropertyName("bounces")]
    public int? Bounces { get; set; }

    /// <summary>
    /// Gets or sets the number of invalid email addresses.
    /// </summary>
    [JsonPropertyName("invalids")]
    public int? Invalids { get; set; }

    /// <summary>
    /// Gets or sets the number of messages missing.
    /// </summary>
    [JsonPropertyName("mes_missings")]
    public int? MesMissings { get; set; }

    /// <summary>
    /// Gets or sets the number of expirations.
    /// </summary>
    [JsonPropertyName("expirations")]
    public int? Expirations { get; set; }

    /// <summary>
    /// Gets or sets the number of skips.
    /// </summary>
    [JsonPropertyName("skips")]
    public int? Skips { get; set; }

    /// <summary>
    /// Gets or sets the number of aborts.
    /// </summary>
    [JsonPropertyName("aborts")]
    public int? Aborts { get; set; }

    /// <summary>
    /// Gets or sets the number of unsubscribes.
    /// </summary>
    [JsonPropertyName("unsubs")]
    public int? Unsubs { get; set; }

    /// <summary>
    /// Gets or sets the number of forwards.
    /// </summary>
    [JsonPropertyName("forwards")]
    public int? Forwards { get; set; }

    /// <summary>
    /// Gets or sets the number of referrals.
    /// </summary>
    [JsonPropertyName("referrals")]
    public int? Referrals { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the report.
    /// </summary>
    [JsonPropertyName("Created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// Gets or sets the size of the inmail body.
    /// </summary>
    [JsonPropertyName("InmailBodySize")]
    public int? InmailBodySize { get; set; }

    /// <summary>
    /// Gets or sets the subset ID.
    /// </summary>
    [JsonPropertyName("SubsetID")]
    public int? SubsetID { get; set; }

    /// <summary>
    /// Gets or sets the inmail header from information.
    /// </summary>
    [JsonPropertyName("InmailHdrFrom")]
    public string? InmailHdrFrom { get; set; }

    /// <summary>
    /// Gets or sets the outmail from information.
    /// </summary>
    [JsonPropertyName("OutmailFrom")]
    public string? OutmailFrom { get; set; }

    /// <summary>
    /// Gets or sets the list name.
    /// </summary>
    [JsonPropertyName("List")]
    public string? List { get; set; }

    /// <summary>
    /// Gets or sets the title of the report.
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the outmail to information.
    /// </summary>
    [JsonPropertyName("OutmailTo")]
    public string? OutmailTo { get; set; }

    /// <summary>
    /// Gets or sets the subject of the email.
    /// </summary>
    [JsonPropertyName("Subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the type of the report.
    /// </summary>
    [JsonPropertyName("Type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the number of unique opens.
    /// </summary>
    [JsonPropertyName("unique_opens")]
    public int? UniqueOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of unique transactions.
    /// </summary>
    [JsonPropertyName("unique_trans")]
    public int? UniqueTrans { get; set; }

    /// <summary>
    /// Gets or sets the number of units.
    /// </summary>
    [JsonPropertyName("units")]
    public int? Units { get; set; }

    /// <summary>
    /// Gets or sets the number of streams.
    /// </summary>
    [JsonPropertyName("streams")]
    public int? Streams { get; set; }

    /// <summary>
    /// Gets or sets the number of unique streams.
    /// </summary>
    [JsonPropertyName("unique_streams")]
    public int? UniqueStreams { get; set; }

    /// <summary>
    /// Gets or sets the engagement rate.
    /// </summary>
    [JsonPropertyName("engagement")]
    public decimal? Engagement { get; set; }

    /// <summary>
    /// Gets or sets the number of complaint?s.
    /// </summary>
    [JsonPropertyName("complaints")]
    public int? Complaints { get; set; }

    /// <summary>
    /// Gets or sets the number of attempts.
    /// </summary>
    [JsonPropertyName("attempted")]
    public int? Attempted { get; set; }

    /// <summary>
    /// Gets or sets the finish date of the report.
    /// </summary>
    [JsonPropertyName("finish_date")]
    public DateTime? FinishDate { get; set; }

    /// <summary>
    /// Gets or sets the number of social shares.
    /// </summary>
    [JsonPropertyName("social_shares")]
    public int? SocialShares { get; set; }

    /// <summary>
    /// Gets or sets the number of social impressions.
    /// </summary>
    [JsonPropertyName("social_impressions")]
    public int? SocialImpressions { get; set; }

    /// <summary>
    /// Gets or sets the completed date of the report.
    /// </summary>
    [JsonPropertyName("completed")]
    public DateTime? Completed { get; set; }

    /// <summary>
    /// Gets or sets the number of mobile opens.
    /// </summary>
    [JsonPropertyName("MobileOpens")]
    public int? MobileOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of web opens.
    /// </summary>
    [JsonPropertyName("WebOpens")]
    public int? WebOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of desktop opens.
    /// </summary>
    [JsonPropertyName("DesktopOpens")]
    public int? DesktopOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of unknown opens.
    /// </summary>
    [JsonPropertyName("UnknownOpens")]
    public int? UnknownOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of unique mobile opens.
    /// </summary>
    [JsonPropertyName("UniqueMobileOpens")]
    public int? UniqueMobileOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of unique web opens.
    /// </summary>
    [JsonPropertyName("UniqueWebOpens")]
    public int? UniqueWebOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of unique desktop opens.
    /// </summary>
    [JsonPropertyName("UniqueDesktopOpens")]
    public int? UniqueDesktopOpens { get; set; }

    /// <summary>
    /// Gets or sets the number of unique unknown opens.
    /// </summary>
    [JsonPropertyName("UniqueUnknownOpens")]
    public int? UniqueUnknownOpens { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the report is triggered.
    /// </summary>
    [JsonPropertyName("IsTriggered")]
    public bool? IsTriggered { get; set; }

    /// <summary>
    /// Gets or sets the moderate ID.
    /// </summary>
    [JsonPropertyName("ModerateID")]
    public int? ModerateId { get; set; }

    /// <summary>
    /// Determines whether the specified Report is equal to the current Report.
    /// </summary>
    /// <param name="other">The Report to compare with the current Report.</param>
    /// <returns>true if the specified Report is equal to the current Report; otherwise, false.</returns>
    private bool Equals(Report other)
    {
        return Id == other.Id;
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
        return obj.GetType() == GetType() && Equals((Report)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id}, {nameof(Active)}: {Active}, {nameof(Paused)}: {Paused}, {nameof(Mailed)}: " +
            $"{Mailed}, {nameof(Received)}: {Received}, {nameof(Opens)}: {Opens}, {nameof(TotalClicks)}: {TotalClicks}, " +
            $"{nameof(UniqueClicks)}: {UniqueClicks}, {nameof(Trans)}: {Trans}, {nameof(TransAmt)}: {TransAmt}, {nameof(SoftFails)}: " +
            $"{SoftFails}, {nameof(HardFails)}: {HardFails}, {nameof(PermFails)}: {PermFails}, {nameof(DnsTemps)}: {DnsTemps}, " +
            $"{nameof(BadDoms)}: {BadDoms}, {nameof(Bounces)}: {Bounces}, {nameof(Invalids)}: {Invalids}, {nameof(MesMissings)}: " +
            $"{MesMissings}, {nameof(Expirations)}: {Expirations}, {nameof(Skips)}: {Skips}, {nameof(Aborts)}: {Aborts}, " +
            $"{nameof(Unsubs)}: {Unsubs}, {nameof(Forwards)}: {Forwards}, {nameof(Referrals)}: {Referrals}, {nameof(Created)}: " +
            $"{Created}, {nameof(InmailBodySize)}: {InmailBodySize}, {nameof(SubsetID)}: {SubsetID}, {nameof(InmailHdrFrom)}: " +
            $"{InmailHdrFrom}, {nameof(OutmailFrom)}: {OutmailFrom}, {nameof(List)}: {List}, {nameof(Title)}: {Title}, " +
            $"{nameof(OutmailTo)}: {OutmailTo}, {nameof(Subject)}: {Subject}, {nameof(Type)}: {Type}, {nameof(UniqueOpens)}: " +
            $"{UniqueOpens}, {nameof(UniqueTrans)}: {UniqueTrans}, {nameof(Units)}: {Units}, {nameof(Streams)}: {Streams}, " +
            $"{nameof(UniqueStreams)}: {UniqueStreams}, {nameof(Engagement)}: {Engagement}, {nameof(Complaints)}: {Complaints}, " +
            $"{nameof(Attempted)}: {Attempted}, {nameof(FinishDate)}: {FinishDate}, {nameof(SocialShares)}: {SocialShares}, " +
            $"{nameof(SocialImpressions)}: {SocialImpressions}, {nameof(Completed)}: {Completed}, {nameof(MobileOpens)}:" +
            $" {MobileOpens}, {nameof(WebOpens)}: {WebOpens}, {nameof(DesktopOpens)}: {DesktopOpens}, {nameof(UnknownOpens)}: " +
            $"{UnknownOpens}, {nameof(UniqueMobileOpens)}: {UniqueMobileOpens}, {nameof(UniqueWebOpens)}: {UniqueWebOpens}, " +
            $"{nameof(UniqueDesktopOpens)}: {UniqueDesktopOpens}, {nameof(UniqueUnknownOpens)}: {UniqueUnknownOpens}, " +
            $"{nameof(IsTriggered)}: {IsTriggered}, {nameof(ModerateId)}: {ModerateId}";
    }
}