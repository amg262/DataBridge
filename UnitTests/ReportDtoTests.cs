using DataBridge.Models.Delivra.Dto;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="ReportDto"/> class.
/// </summary>
public class ReportDtoTests
{
    /// <summary>
    /// Tests the Equals method when comparing two ReportDto objects with the same Id.
    /// </summary>
    [Fact]
    public void Equals_SameId_ReturnsTrue()
    {
        // Arrange
        var reportDto1 = new ReportDto { Id = 1 };
        var reportDto2 = new ReportDto { Id = 1 };

        // Act
        var result = reportDto1.Equals(reportDto2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method when comparing two ReportDto objects with different Ids.
    /// </summary>
    [Fact]
    public void Equals_DifferentId_ReturnsFalse()
    {
        // Arrange
        var reportDto1 = new ReportDto { Id = 1 };
        var reportDto2 = new ReportDto { Id = 2 };

        // Act
        var result = reportDto1.Equals(reportDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method when comparing two ReportDto objects with the same Id.
    /// </summary>
    [Fact]
    public void GetHashCode_SameId_ReturnsSameHashCode()
    {
        // Arrange
        var reportDto1 = new ReportDto { Id = 1 };
        var reportDto2 = new ReportDto { Id = 1 };

        // Act
        var hashCode1 = reportDto1.GetHashCode();
        var hashCode2 = reportDto2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method when comparing two ReportDto objects with different Ids.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentId_ReturnsDifferentHashCode()
    {
        // Arrange
        var reportDto1 = new ReportDto { Id = 1 };
        var reportDto2 = new ReportDto { Id = 2 };

        // Act
        var hashCode1 = reportDto1.GetHashCode();
        var hashCode2 = reportDto2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the ToString method with default values.
    /// </summary>
    [Fact]
    public void ToString_DefaultValues_ReturnsExpectedString()
    {
        // Arrange
        var reportDto = new ReportDto
        {
            Id = 0,
            Active = 0,
            Paused = 0,
            Mailed = 0,
            Received = 0,
            Opens = 0,
            TotalClicks = 0,
            UniqueClicks = 0,
            Trans = 0,
            TransAmt = 0,
            SoftFails = 0,
            HardFails = 0,
            PermFails = 0,
            DnsTemps = 0,
            BadDoms = 0,
            Bounces = 0,
            Invalids = 0,
            MesMissings = 0,
            Expirations = 0,
            Skips = 0,
            Aborts = 0,
            Unsubs = 0,
            Forwards = 0,
            Referrals = 0,
            Created = DateTime.MinValue,
            InmailBodySize = 0,
            SubinitID = 0,
            InmailHdrFrom = string.Empty,
            OutmailFrom = string.Empty,
            List = string.Empty,
            Title = string.Empty,
            OutmailTo = string.Empty,
            Subject = string.Empty,
            Type = string.Empty,
            UniqueOpens = 0,
            UniqueTrans = 0,
            Units = 0,
            Streams = 0,
            UniqueStreams = 0,
            Engagement = 0,
            Complaints = 0,
            Attempted = 0,
            FinishDate = DateTime.MinValue,
            SocialShares = 0,
            SocialImpressions = 0,
            Completed = DateTime.MinValue,
            MobileOpens = 0,
            WebOpens = 0,
            DesktopOpens = 0,
            UnknownOpens = 0,
            UniqueMobileOpens = 0,
            UniqueWebOpens = 0,
            UniqueDesktopOpens = 0,
            UniqueUnknownOpens = 0,
            IsTriggered = false,
            ModerateId = 0
        };

        // Act
        var result = reportDto.ToString();

        // Assert
        const string expected =
            "Id: 0, Active: 0, Paused: 0, Mailed: 0, Received: 0, Opens: 0, TotalClicks: 0, UniqueClicks: 0, Trans: 0, TransAmt: 0, SoftFails: 0, HardFails: 0, PermFails: 0, DnsTemps: 0, BadDoms: 0, Bounces: 0, Invalids: 0, MesMissings: 0, Expirations: 0, Skips: 0, Aborts: 0, Unsubs: 0, Forwards: 0, Referrals: 0, Created: 1/1/0001 12:00:00 AM, InmailBodySize: 0, SubinitID: 0, InmailHdrFrom: , OutmailFrom: , List: , Title: , OutmailTo: , Subject: , Type: , UniqueOpens: 0, UniqueTrans: 0, Units: 0, Streams: 0, UniqueStreams: 0, Engagement: 0, Complaints: 0, Attempted: 0, FinishDate: 1/1/0001 12:00:00 AM, SocialShares: 0, SocialImpressions: 0, Completed: 1/1/0001 12:00:00 AM, MobileOpens: 0, WebOpens: 0, DesktopOpens: 0, UnknownOpens: 0, UniqueMobileOpens: 0, UniqueWebOpens: 0, UniqueDesktopOpens: 0, UniqueUnknownOpens: 0, IsTriggered: False, ModerateId: 0";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var reportDto = new ReportDto
        {
            Id = null,
            Active = null,
            Paused = null,
            Mailed = null,
            Received = null,
            Opens = null,
            TotalClicks = null,
            UniqueClicks = null,
            Trans = null,
            TransAmt = null,
            SoftFails = null,
            HardFails = null,
            PermFails = null,
            DnsTemps = null,
            BadDoms = null,
            Bounces = null,
            Invalids = null,
            MesMissings = null,
            Expirations = null,
            Skips = null,
            Aborts = null,
            Unsubs = null,
            Forwards = null,
            Referrals = null,
            Created = null,
            InmailBodySize = null,
            SubinitID = null,
            InmailHdrFrom = null,
            OutmailFrom = null,
            List = null,
            Title = null,
            OutmailTo = null,
            Subject = null,
            Type = null,
            UniqueOpens = null,
            UniqueTrans = null,
            Units = null,
            Streams = null,
            UniqueStreams = null,
            Engagement = null,
            Complaints = null,
            Attempted = null,
            FinishDate = null,
            SocialShares = null,
            SocialImpressions = null,
            Completed = null,
            MobileOpens = null,
            WebOpens = null,
            DesktopOpens = null,
            UnknownOpens = null,
            UniqueMobileOpens = null,
            UniqueWebOpens = null,
            UniqueDesktopOpens = null,
            UniqueUnknownOpens = null,
            IsTriggered = null,
            ModerateId = null
        };

        // Act
        var result = reportDto.ToString();

        // Assert
        const string expected =
            "Id: , Active: , Paused: , Mailed: , Received: , Opens: , TotalClicks: , UniqueClicks: , Trans: , TransAmt: , SoftFails: , HardFails: , PermFails: , DnsTemps: , BadDoms: , Bounces: , Invalids: , MesMissings: , Expirations: , Skips: , Aborts: , Unsubs: , Forwards: , Referrals: , Created: , InmailBodySize: , SubinitID: , InmailHdrFrom: , OutmailFrom: , List: , Title: , OutmailTo: , Subject: , Type: , UniqueOpens: , UniqueTrans: , Units: , Streams: , UniqueStreams: , Engagement: , Complaints: , Attempted: , FinishDate: , SocialShares: , SocialImpressions: , Completed: , MobileOpens: , WebOpens: , DesktopOpens: , UnknownOpens: , UniqueMobileOpens: , UniqueWebOpens: , UniqueDesktopOpens: , UniqueUnknownOpens: , IsTriggered: , ModerateId: ";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the property values of the ReportDto object.
    /// </summary>
    [Fact]
    public void PropertyValues_SetValues_ReturnsExpectedValues()
    {
        // Arrange
        var reportDto = new ReportDto
        {
            Id = 1,
            Active = 1,
            Paused = 0,
            Mailed = 100,
            Received = 90,
            Opens = 80,
            TotalClicks = 70,
            UniqueClicks = 60,
            Trans = 50,
            TransAmt = 1000.50m,
            SoftFails = 40,
            HardFails = 30,
            PermFails = 20,
            DnsTemps = 10,
            BadDoms = 5,
            Bounces = 4,
            Invalids = 3,
            MesMissings = 2,
            Expirations = 1,
            Skips = 0,
            Aborts = 0,
            Unsubs = 0,
            Forwards = 0,
            Referrals = 0,
            Created = new DateTime(2023, 1, 1),
            InmailBodySize = 1000,
            SubinitID = 1,
            InmailHdrFrom = "test@domain.com",
            OutmailFrom = "no-reply@domain.com",
            List = "Test List",
            Title = "Test Title",
            OutmailTo = "recipient@domain.com",
            Subject = "Test Subject",
            Type = "Test Type",
            UniqueOpens = 50,
            UniqueTrans = 40,
            Units = 30,
            Streams = 20,
            UniqueStreams = 10,
            Engagement = 5.5m,
            Complaints = 2,
            Attempted = 100,
            FinishDate = new DateTime(2023, 12, 31),
            SocialShares = 5,
            SocialImpressions = 10,
            Completed = new DateTime(2023, 12, 31),
            MobileOpens = 20,
            WebOpens = 30,
            DesktopOpens = 40,
            UnknownOpens = 50,
            UniqueMobileOpens = 10,
            UniqueWebOpens = 20,
            UniqueDesktopOpens = 30,
            UniqueUnknownOpens = 40,
            IsTriggered = true,
            ModerateId = 1
        };

        // Act & Assert
        Assert.Equal(1, reportDto.Id);
        Assert.Equal(1, reportDto.Active);
        Assert.Equal(0, reportDto.Paused);
        Assert.Equal(100, reportDto.Mailed);
        Assert.Equal(90, reportDto.Received);
        Assert.Equal(80, reportDto.Opens);
        Assert.Equal(70, reportDto.TotalClicks);
        Assert.Equal(60, reportDto.UniqueClicks);
        Assert.Equal(50, reportDto.Trans);
        Assert.Equal(1000.50m, reportDto.TransAmt);
        Assert.Equal(40, reportDto.SoftFails);
        Assert.Equal(30, reportDto.HardFails);
        Assert.Equal(20, reportDto.PermFails);
        Assert.Equal(10, reportDto.DnsTemps);
        Assert.Equal(5, reportDto.BadDoms);
        Assert.Equal(4, reportDto.Bounces);
        Assert.Equal(3, reportDto.Invalids);
        Assert.Equal(2, reportDto.MesMissings);
        Assert.Equal(1, reportDto.Expirations);
        Assert.Equal(0, reportDto.Skips);
        Assert.Equal(0, reportDto.Aborts);
        Assert.Equal(0, reportDto.Unsubs);
        Assert.Equal(0, reportDto.Forwards);
        Assert.Equal(0, reportDto.Referrals);
        Assert.Equal(new DateTime(2023, 1, 1), reportDto.Created);
        Assert.Equal(1000, reportDto.InmailBodySize);
        Assert.Equal(1, reportDto.SubinitID);
        Assert.Equal("test@domain.com", reportDto.InmailHdrFrom);
        Assert.Equal("no-reply@domain.com", reportDto.OutmailFrom);
        Assert.Equal("Test List", reportDto.List);
        Assert.Equal("Test Title", reportDto.Title);
        Assert.Equal("recipient@domain.com", reportDto.OutmailTo);
        Assert.Equal("Test Subject", reportDto.Subject);
        Assert.Equal("Test Type", reportDto.Type);
        Assert.Equal(50, reportDto.UniqueOpens);
        Assert.Equal(40, reportDto.UniqueTrans);
        Assert.Equal(30, reportDto.Units);
        Assert.Equal(20, reportDto.Streams);
        Assert.Equal(10, reportDto.UniqueStreams);
        Assert.Equal(5.5m, reportDto.Engagement);
        Assert.Equal(2, reportDto.Complaints);
        Assert.Equal(100, reportDto.Attempted);
        Assert.Equal(new DateTime(2023, 12, 31), reportDto.FinishDate);
        Assert.Equal(5, reportDto.SocialShares);
        Assert.Equal(10, reportDto.SocialImpressions);
        Assert.Equal(new DateTime(2023, 12, 31), reportDto.Completed);
        Assert.Equal(20, reportDto.MobileOpens);
        Assert.Equal(30, reportDto.WebOpens);
        Assert.Equal(40, reportDto.DesktopOpens);
        Assert.Equal(50, reportDto.UnknownOpens);
        Assert.Equal(10, reportDto.UniqueMobileOpens);
        Assert.Equal(20, reportDto.UniqueWebOpens);
        Assert.Equal(30, reportDto.UniqueDesktopOpens);
        Assert.Equal(40, reportDto.UniqueUnknownOpens);
        Assert.True(reportDto.IsTriggered);
        Assert.Equal(1, reportDto.ModerateId);
    }
}