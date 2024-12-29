using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra.Dto;

public record ReportDto
{
    /// <summary>
    /// Gets or inits the identifier of the report.
    /// </summary>
    [JsonPropertyName("id")]
    [Description("The unique identifier of the report.")]
    // [Required]
    public int? Id { get; init; }

    /// <summary>
    /// Gets or inits the active status of the report.
    /// </summary>
    [JsonPropertyName("active")]
    [Description("Indicates whether the report is active.")]
    public int? Active { get; init; }

    /// <summary>
    /// Gets or inits the paused status of the report.
    /// </summary>
    [JsonPropertyName("paused")]
    [Description("Indicates whether the report is paused.")]
    public int? Paused { get; init; }

    /// <summary>
    /// Gets or inits the number of emails mailed.
    /// </summary>
    [JsonPropertyName("mailed")]
    [Description("The number of emails mailed.")]
    public int? Mailed { get; init; }

    /// <summary>
    /// Gets or inits the number of emails received.
    /// </summary>
    [JsonPropertyName("received")]
    [Description("The number of emails received.")]
    public int? Received { get; init; }

    /// <summary>
    /// Gets or inits the number of email opens.
    /// </summary>
    [JsonPropertyName("opens")]
    [Description("The number of email opens.")]
    public int? Opens { get; init; }

    /// <summary>
    /// Gets or inits the total number of clicks.
    /// </summary>
    [JsonPropertyName("total_clicks")]
    [Description("The total number of clicks.")]
    public int? TotalClicks { get; init; }

    /// <summary>
    /// Gets or inits the number of unique clicks.
    /// </summary>
    [JsonPropertyName("unique_clicks")]
    [Description("The number of unique clicks.")]
    public int? UniqueClicks { get; init; }

    /// <summary>
    /// Gets or inits the number of transactions.
    /// </summary>
    [JsonPropertyName("trans")]
    [Description("The number of transactions.")]
    public int? Trans { get; init; }

    /// <summary>
    /// Gets or inits the total transaction amount.
    /// </summary>
    [JsonPropertyName("trans_amt")]
    [Description("The total transaction amount.")]
    [DataType(DataType.Currency)]
    public decimal? TransAmt { get; init; }

    /// <summary>
    /// Gets or inits the number of soft failures.
    /// </summary>
    [JsonPropertyName("soft_fails")]
    [Description("The number of soft failures.")]
    public int? SoftFails { get; init; }

    /// <summary>
    /// Gets or inits the number of hard failures.
    /// </summary>
    [JsonPropertyName("hard_fails")]
    [Description("The number of hard failures.")]
    public int? HardFails { get; init; }

    /// <summary>
    /// Gets or inits the number of permanent failures.
    /// </summary>
    [JsonPropertyName("perm_fails")]
    [Description("The number of permanent failures.")]
    public int? PermFails { get; init; }

    /// <summary>
    /// Gets or inits the number of DNS temporary failures.
    /// </summary>
    [JsonPropertyName("dns_temps")]
    [Description("The number of DNS temporary failures.")]
    public int? DnsTemps { get; init; }

    /// <summary>
    /// Gets or inits the number of bad domains.
    /// </summary>
    [JsonPropertyName("bad_doms")]
    [Description("The number of bad domains.")]
    public int? BadDoms { get; init; }

    /// <summary>
    /// Gets or inits the number of bounces.
    /// </summary>
    [JsonPropertyName("bounces")]
    [Description("The number of bounces.")]
    public int? Bounces { get; init; }

    /// <summary>
    /// Gets or inits the number of invalid email addresses.
    /// </summary>
    [JsonPropertyName("invalids")]
    [Description("The number of invalid email addresses.")]
    public int? Invalids { get; init; }

    /// <summary>
    /// Gets or inits the number of messages missing.
    /// </summary>
    [JsonPropertyName("mes_missings")]
    [Description("The number of messages missing.")]
    public int? MesMissings { get; init; }

    /// <summary>
    /// Gets or inits the number of expirations.
    /// </summary>
    [JsonPropertyName("expirations")]
    [Description("The number of expirations.")]
    public int? Expirations { get; init; }

    /// <summary>
    /// Gets or inits the number of skips.
    /// </summary>
    [JsonPropertyName("skips")]
    [Description("The number of skips.")]
    public int? Skips { get; init; }

    /// <summary>
    /// Gets or inits the number of aborts.
    /// </summary>
    [JsonPropertyName("aborts")]
    [Description("The number of aborts.")]
    public int? Aborts { get; init; }

    /// <summary>
    /// Gets or inits the number of unsubscribes.
    /// </summary>
    [JsonPropertyName("unsubs")]
    [Description("The number of unsubscribes.")]
    public int? Unsubs { get; init; }

    /// <summary>
    /// Gets or inits the number of forwards.
    /// </summary>
    [JsonPropertyName("forwards")]
    [Description("The number of forwards.")]
    public int? Forwards { get; init; }

    /// <summary>
    /// Gets or inits the number of referrals.
    /// </summary>
    [JsonPropertyName("referrals")]
    [Description("The number of referrals.")]
    public int? Referrals { get; init; }

    /// <summary>
    /// Gets or inits the creation date of the report.
    /// </summary>
    [JsonPropertyName("Created")]
    [Description("The creation date of the report.")]
    [DataType(DataType.DateTime)]
    public DateTime? Created { get; init; }

    /// <summary>
    /// Gets or inits the size of the inmail body.
    /// </summary>
    [JsonPropertyName("InmailBodySize")]
    [Description("The size of the inmail body.")]
    public int? InmailBodySize { get; init; }

    /// <summary>
    /// Gets or inits the subinit ID.
    /// </summary>
    [JsonPropertyName("SubinitID")]
    [Description("The subinit ID.")]
    public int? SubinitID { get; init; }

    /// <summary>
    /// Gets or inits the inmail header from information.
    /// </summary>
    [JsonPropertyName("InmailHdrFrom")]
    [Description("The inmail header from information.")]
    public string? InmailHdrFrom { get; init; }

    /// <summary>
    /// Gets or inits the outmail from information.
    /// </summary>
    [JsonPropertyName("OutmailFrom")]
    [Description("The outmail from information.")]
    public string? OutmailFrom { get; init; }

    /// <summary>
    /// Gets or inits the list name.
    /// </summary>
    [JsonPropertyName("List")]
    [Description("The list name.")]
    public string? List { get; init; }

    /// <summary>
    /// Gets or inits the title of the report.
    /// </summary>
    [JsonPropertyName("Title")]
    [Description("The title of the report.")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets or inits the outmail to information.
    /// </summary>
    [JsonPropertyName("OutmailTo")]
    [Description("The outmail to information.")]
    public string? OutmailTo { get; init; }

    /// <summary>
    /// Gets or inits the subject of the email.
    /// </summary>
    [JsonPropertyName("Subject")]
    [Description("The subject of the email.")]
    public string? Subject { get; init; }

    /// <summary>
    /// Gets or inits the type of the report.
    /// </summary>
    [JsonPropertyName("Type")]
    [Description("The type of the report.")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets or inits the number of unique opens.
    /// </summary>
    [JsonPropertyName("unique_opens")]
    [Description("The number of unique opens.")]
    public int? UniqueOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of unique transactions.
    /// </summary>
    [JsonPropertyName("unique_trans")]
    [Description("The number of unique transactions.")]
    public int? UniqueTrans { get; init; }

    /// <summary>
    /// Gets or inits the number of units.
    /// </summary>
    [JsonPropertyName("units")]
    [Description("The number of units.")]
    public int? Units { get; init; }

    /// <summary>
    /// Gets or inits the number of streams.
    /// </summary>
    [JsonPropertyName("streams")]
    [Description("The number of streams.")]
    public int? Streams { get; init; }

    /// <summary>
    /// Gets or inits the number of unique streams.
    /// </summary>
    [JsonPropertyName("unique_streams")]
    [Description("The number of unique streams.")]
    public int? UniqueStreams { get; init; }

    /// <summary>
    /// Gets or inits the engagement rate.
    /// </summary>
    [JsonPropertyName("engagement")]
    [Description("The engagement rate.")]
    [DataType(DataType.Currency)]
    public decimal? Engagement { get; init; }

    /// <summary>
    /// Gets or inits the number of complaints.
    /// </summary>
    [JsonPropertyName("complaints")]
    [Description("The number of complaints.")]
    public int? Complaints { get; init; }

    /// <summary>
    /// Gets or inits the number of attempts.
    /// </summary>
    [JsonPropertyName("attempted")]
    [Description("The number of attempts.")]
    public int? Attempted { get; init; }

    /// <summary>
    /// Gets or inits the finish date of the report.
    /// </summary>
    [JsonPropertyName("finish_date")]
    [Description("The finish date of the report.")]
    [DataType(DataType.DateTime)]
    public DateTime? FinishDate { get; init; }

    /// <summary>
    /// Gets or inits the number of social shares.
    /// </summary>
    [JsonPropertyName("social_shares")]
    [Description("The number of social shares.")]
    public int? SocialShares { get; init; }

    /// <summary>
    /// Gets or inits the number of social impressions.
    /// </summary>
    [JsonPropertyName("social_impressions")]
    [Description("The number of social impressions.")]
    public int? SocialImpressions { get; init; }

    /// <summary>
    /// Gets or inits the completed date of the report.
    /// </summary>
    [JsonPropertyName("completed")]
    [Description("The completed date of the report.")]
    [DataType(DataType.DateTime)]
    public DateTime? Completed { get; init; }

    /// <summary>
    /// Gets or inits the number of mobile opens.
    /// </summary>
    [JsonPropertyName("MobileOpens")]
    [Description("The number of mobile opens.")]
    public int? MobileOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of web opens.
    /// </summary>
    [JsonPropertyName("WebOpens")]
    [Description("The number of web opens.")]
    public int? WebOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of desktop opens.
    /// </summary>
    [JsonPropertyName("DesktopOpens")]
    [Description("The number of desktop opens.")]
    public int? DesktopOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of unknown opens.
    /// </summary>
    [JsonPropertyName("UnknownOpens")]
    [Description("The number of unknown opens.")]
    public int? UnknownOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of unique mobile opens.
    /// </summary>
    [JsonPropertyName("UniqueMobileOpens")]
    [Description("The number of unique mobile opens.")]
    public int? UniqueMobileOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of unique web opens.
    /// </summary>
    [JsonPropertyName("UniqueWebOpens")]
    [Description("The number of unique web opens.")]
    public int? UniqueWebOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of unique desktop opens.
    /// </summary>
    [JsonPropertyName("UniqueDesktopOpens")]
    [Description("The number of unique desktop opens.")]
    public int? UniqueDesktopOpens { get; init; }

    /// <summary>
    /// Gets or inits the number of unique unknown opens.
    /// </summary>
    [JsonPropertyName("UniqueUnknownOpens")]
    [Description("The number of unique unknown opens.")]
    public int? UniqueUnknownOpens { get; init; }

    /// <summary>
    /// Gets or inits a value indicating whether the report is triggered.
    /// </summary>
    [JsonPropertyName("IsTriggered")]
    [Description("Indicates whether the report is triggered.")]
    public bool? IsTriggered { get; init; }

    /// <summary>
    /// Gets or inits the moderate ID.
    /// </summary>
    [JsonPropertyName("ModerateID")]
    [Description("The moderate ID.")]
    public int? ModerateId { get; init; }

    /// <summary>
    /// Determines whether the specified ReportDto is equal to the current ReportDto.
    /// </summary>
    /// <param name="other">The ReportDto to compare with the current ReportDto.</param>
    /// <returns>true if the specified ReportDto is equal to the current ReportDto; otherwise, false.</returns>
    public virtual bool Equals(ReportDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
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
            $"{Created}, {nameof(InmailBodySize)}: {InmailBodySize}, {nameof(SubinitID)}: {SubinitID}, {nameof(InmailHdrFrom)}: " +
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