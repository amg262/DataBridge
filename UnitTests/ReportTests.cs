using DataBridge.Models.Delivra;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="Report"/> class.
/// </summary>
public class ReportTests
{
    /// <summary>
    /// Tests the Equals method with the same Id.
    /// </summary>
    [Fact]
    public void Equals_SameId_ReturnsTrue()
    {
        // Arrange
        var report1 = new Report { Id = 1 };
        var report2 = new Report { Id = 1 };

        // Act
        var result = report1.Equals(report2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different Id.
    /// </summary>
    [Fact]
    public void Equals_DifferentId_ReturnsFalse()
    {
        // Arrange
        var report1 = new Report { Id = 1 };
        var report2 = new Report { Id = 2 };

        // Act
        var result = report1.Equals(report2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with the same Id.
    /// </summary>
    [Fact]
    public void GetHashCode_SameId_ReturnsSameHashCode()
    {
        // Arrange
        var report1 = new Report { Id = 1 };
        var report2 = new Report { Id = 1 };

        // Act
        var hashCode1 = report1.GetHashCode();
        var hashCode2 = report2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different Id.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentId_ReturnsDifferentHashCode()
    {
        // Arrange
        var report1 = new Report { Id = 1 };
        var report2 = new Report { Id = 2 };

        // Act
        var hashCode1 = report1.GetHashCode();
        var hashCode2 = report2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the ToString method.
    /// </summary>
    [Fact]
    public void ToString_ReturnsExpectedString()
    {
        // Arrange
        var report = new Report
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
            SubsetID = 1,
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

        // Act
        var result = report.ToString();

        // Assert
        const string expected =
            "Id: 1, Active: 1, Paused: 0, Mailed: 100, Received: 90, Opens: 80, TotalClicks: 70, UniqueClicks: 60, Trans: 50, TransAmt: 1000.50, SoftFails: 40, HardFails: 30, PermFails: 20, DnsTemps: 10, BadDoms: 5, Bounces: 4, Invalids: 3, MesMissings: 2, Expirations: 1, Skips: 0, Aborts: 0, Unsubs: 0, Forwards: 0, Referrals: 0, Created: 1/1/2023 12:00:00 AM, InmailBodySize: 1000, SubsetID: 1, InmailHdrFrom: test@domain.com, OutmailFrom: no-reply@domain.com, List: Test List, Title: Test Title, OutmailTo: recipient@domain.com, Subject: Test Subject, Type: Test Type, UniqueOpens: 50, UniqueTrans: 40, Units: 30, Streams: 20, UniqueStreams: 10, Engagement: 5.5, Complaints: 2, Attempted: 100, FinishDate: 12/31/2023 12:00:00 AM, SocialShares: 5, SocialImpressions: 10, Completed: 12/31/2023 12:00:00 AM, MobileOpens: 20, WebOpens: 30, DesktopOpens: 40, UnknownOpens: 50, UniqueMobileOpens: 10, UniqueWebOpens: 20, UniqueDesktopOpens: 30, UniqueUnknownOpens: 40, IsTriggered: True, ModerateId: 1";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the Equals method with null.
    /// </summary>
    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var report = new Report { Id = 1 };

        // Act
        var result = report.Equals(null);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the Equals method with the same reference.
    /// </summary>
    [Fact]
    public void Equals_SameReference_ReturnsTrue()
    {
        // Arrange
        var report = new Report { Id = 1 };

        // Act
        var result = report.Equals(report);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different types.
    /// </summary>
    [Fact]
    public void Equals_DifferentType_ReturnsFalse()
    {
        // Arrange
        var report = new Report { Id = 1 };
        var otherObject = new { Id = 1 };

        // Act
        var result = report.Equals(otherObject);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the properties of the Report class.
    /// </summary>
    [Fact]
    public void Properties_AssignedCorrectValues()
    {
        // Arrange
        var report = new Report
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
            SubsetID = 1,
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

        // Assert
        Assert.Equal(1, report.Id);
        Assert.Equal(1, report.Active);
        Assert.Equal(0, report.Paused);
        Assert.Equal(100, report.Mailed);
        Assert.Equal(90, report.Received);
        Assert.Equal(80, report.Opens);
        Assert.Equal(70, report.TotalClicks);
        Assert.Equal(60, report.UniqueClicks);
        Assert.Equal(50, report.Trans);
        Assert.Equal(1000.50m, report.TransAmt);
        Assert.Equal(40, report.SoftFails);
        Assert.Equal(30, report.HardFails);
        Assert.Equal(20, report.PermFails);
        Assert.Equal(10, report.DnsTemps);
        Assert.Equal(5, report.BadDoms);
        Assert.Equal(4, report.Bounces);
        Assert.Equal(3, report.Invalids);
        Assert.Equal(2, report.MesMissings);
        Assert.Equal(1, report.Expirations);
        Assert.Equal(0, report.Skips);
        Assert.Equal(0, report.Aborts);
        Assert.Equal(0, report.Unsubs);
        Assert.Equal(0, report.Forwards);
        Assert.Equal(0, report.Referrals);
        Assert.Equal(new DateTime(2023, 1, 1), report.Created);
        Assert.Equal(1000, report.InmailBodySize);
        Assert.Equal(1, report.SubsetID);
        Assert.Equal("test@domain.com", report.InmailHdrFrom);
        Assert.Equal("no-reply@domain.com", report.OutmailFrom);
        Assert.Equal("Test List", report.List);
        Assert.Equal("Test Title", report.Title);
        Assert.Equal("recipient@domain.com", report.OutmailTo);
        Assert.Equal("Test Subject", report.Subject);
        Assert.Equal("Test Type", report.Type);
        Assert.Equal(50, report.UniqueOpens);
        Assert.Equal(40, report.UniqueTrans);
        Assert.Equal(30, report.Units);
        Assert.Equal(20, report.Streams);
        Assert.Equal(10, report.UniqueStreams);
        Assert.Equal(5.5m, report.Engagement);
        Assert.Equal(2, report.Complaints);
        Assert.Equal(100, report.Attempted);
        Assert.Equal(new DateTime(2023, 12, 31), report.FinishDate);
        Assert.Equal(5, report.SocialShares);
        Assert.Equal(10, report.SocialImpressions);
        Assert.Equal(new DateTime(2023, 12, 31), report.Completed);
        Assert.Equal(20, report.MobileOpens);
        Assert.Equal(30, report.WebOpens);
        Assert.Equal(40, report.DesktopOpens);
        Assert.Equal(50, report.UnknownOpens);
        Assert.Equal(10, report.UniqueMobileOpens);
        Assert.Equal(20, report.UniqueWebOpens);
        Assert.Equal(30, report.UniqueDesktopOpens);
        Assert.Equal(40, report.UniqueUnknownOpens);
        Assert.True(report.IsTriggered);
        Assert.Equal(1, report.ModerateId);
    }

    /// <summary>
    /// Tests the ToString method with default values.
    /// </summary>
    [Fact]
    public void ToString_DefaultValues_ReturnsExpectedString()
    {
        // Arrange
        var report = new Report
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
            SubsetID = 0,
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
        var result = report.ToString();

        // Assert
        const string expected =
            "Id: 0, Active: 0, Paused: 0, Mailed: 0, Received: 0, Opens: 0, TotalClicks: 0, UniqueClicks: 0, Trans: 0, TransAmt: 0, SoftFails: 0, HardFails: 0, PermFails: 0, DnsTemps: 0, BadDoms: 0, Bounces: 0, Invalids: 0, MesMissings: 0, Expirations: 0, Skips: 0, Aborts: 0, Unsubs: 0, Forwards: 0, Referrals: 0, Created: 1/1/0001 12:00:00 AM, InmailBodySize: 0, SubsetID: 0, InmailHdrFrom: , OutmailFrom: , List: , Title: , OutmailTo: , Subject: , Type: , UniqueOpens: 0, UniqueTrans: 0, Units: 0, Streams: 0, UniqueStreams: 0, Engagement: 0, Complaints: 0, Attempted: 0, FinishDate: 1/1/0001 12:00:00 AM, SocialShares: 0, SocialImpressions: 0, Completed: 1/1/0001 12:00:00 AM, MobileOpens: 0, WebOpens: 0, DesktopOpens: 0, UnknownOpens: 0, UniqueMobileOpens: 0, UniqueWebOpens: 0, UniqueDesktopOpens: 0, UniqueUnknownOpens: 0, IsTriggered: False, ModerateId: 0";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var report = new Report
        {
            Id = 0,
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
            SubsetID = null,
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
        var result = report.ToString();

        // Assert
        const string expected =
            "Id: 0, Active: , Paused: , Mailed: , Received: , Opens: , TotalClicks: , UniqueClicks: , Trans: , TransAmt: , SoftFails: , HardFails: , PermFails: , DnsTemps: , BadDoms: , Bounces: , Invalids: , MesMissings: , Expirations: , Skips: , Aborts: , Unsubs: , Forwards: , Referrals: , Created: , InmailBodySize: , SubsetID: , InmailHdrFrom: , OutmailFrom: , List: , Title: , OutmailTo: , Subject: , Type: , UniqueOpens: , UniqueTrans: , Units: , Streams: , UniqueStreams: , Engagement: , Complaints: , Attempted: , FinishDate: , SocialShares: , SocialImpressions: , Completed: , MobileOpens: , WebOpens: , DesktopOpens: , UnknownOpens: , UniqueMobileOpens: , UniqueWebOpens: , UniqueDesktopOpens: , UniqueUnknownOpens: , IsTriggered: , ModerateId: ";
        Assert.Equal(expected, result);
    }
}