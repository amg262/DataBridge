using DataBridge.Models.Delivra;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="MailingApproval"/> class.
/// </summary>
public class MailingApprovalTests
{
    /// <summary>
    /// Tests the Equals method with the same MessageID.
    /// </summary>
    [Fact]
    public void Equals_SameMessageID_ReturnsTrue()
    {
        // Arrange
        var mailingApproval1 = new MailingApproval { MessageID = 1 };
        var mailingApproval2 = new MailingApproval { MessageID = 1 };

        // Act
        var result = mailingApproval1.Equals(mailingApproval2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different MessageID.
    /// </summary>
    [Fact]
    public void Equals_DifferentMessageID_ReturnsFalse()
    {
        // Arrange
        var mailingApproval1 = new MailingApproval { MessageID = 1 };
        var mailingApproval2 = new MailingApproval { MessageID = 2 };

        // Act
        var result = mailingApproval1.Equals(mailingApproval2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with the same MessageID.
    /// </summary>
    [Fact]
    public void GetHashCode_SameMessageID_ReturnsSameHashCode()
    {
        // Arrange
        var mailingApproval1 = new MailingApproval { MessageID = 1 };
        var mailingApproval2 = new MailingApproval { MessageID = 1 };

        // Act
        var hashCode1 = mailingApproval1.GetHashCode();
        var hashCode2 = mailingApproval2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different MessageID.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentMessageID_ReturnsDifferentHashCode()
    {
        // Arrange
        var mailingApproval1 = new MailingApproval { MessageID = 1 };
        var mailingApproval2 = new MailingApproval { MessageID = 2 };

        // Act
        var hashCode1 = mailingApproval1.GetHashCode();
        var hashCode2 = mailingApproval2.GetHashCode();

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
        var mailingApproval = new MailingApproval
        {
            MessageID = 1,
            PkId = 2,
            Body = "Sample Body",
            HeaderAll = "Sample Header",
            HeaderDate = "01/01/2023",
            HeaderFrom = "sender@domain.com",
            HeaderFromSpc = "Sender <sender@domain.com>",
            HeaderSubject = "Sample Subject",
            HeaderTo = "receiver@domain.com",
            List = "Sample List",
            MaxRecips = 100,
            ReSubmit = 1,
            Status = "Active",
            SubsetID = 10,
            Title = "Sample Title",
            Transact = "Sample Transaction",
            Type = "Sample Type",
            UpdatedDate = new DateTime(2023, 1, 1),
            FileUID = "UID12345",
            PublishOnSend = true,
            FacebookPost = true,
            TwitterTweet = true,
            LinkedInPost = true,
            TimeZoneSend = true,
            SendTimeOptimize = true,
            SendFrequencyOverride = true,
            Footer = 1
        };

        // Act
        var result = mailingApproval.ToString();

        // Assert
        var expected =
            "MessageID: 1, PkId: 2, Body: Sample Body, HeaderAll: Sample Header, HeaderDate: 01/01/2023, HeaderFrom: sender@domain.com, HeaderFromSpc: Sender <sender@domain.com>, HeaderSubject: Sample Subject, HeaderTo: receiver@domain.com, List: Sample List, MaxRecips: 100, ReSubmit: 1, Status: Active, SubsetID: 10, Title: Sample Title, Transact: Sample Transaction, Type: Sample Type, UpdatedDate: 1/1/2023 12:00:00 AM, FileUID: UID12345, PublishOnSend: True, FacebookPost: True, TwitterTweet: True, LinkedInPost: True, TimeZoneSend: True, SendTimeOptimize: True, SendFrequencyOverride: True, Footer: 1";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the Equals method with null.
    /// </summary>
    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var mailingApproval = new MailingApproval { MessageID = 1 };

        // Act
        var result = mailingApproval.Equals(null);

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
        var mailingApproval = new MailingApproval { MessageID = 1 };

        // Act
        var result = mailingApproval.Equals(mailingApproval);

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
        var mailingApproval = new MailingApproval { MessageID = 1 };
        var otherObject = new { MessageID = 1 };

        // Act
        var result = mailingApproval.Equals(otherObject);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the properties of the MailingApproval class.
    /// </summary>
    [Fact]
    public void Properties_AssignedCorrectValues()
    {
        // Arrange
        var mailingApproval = new MailingApproval
        {
            MessageID = 1,
            PkId = 2,
            Body = "Sample Body",
            HeaderAll = "Sample Header",
            HeaderDate = "01/01/2023",
            HeaderFrom = "sender@domain.com",
            HeaderFromSpc = "Sender <sender@domain.com>",
            HeaderSubject = "Sample Subject",
            HeaderTo = "receiver@domain.com",
            List = "Sample List",
            MaxRecips = 100,
            ReSubmit = 1,
            Status = "Active",
            SubsetID = 10,
            Title = "Sample Title",
            Transact = "Sample Transaction",
            Type = "Sample Type",
            UpdatedDate = new DateTime(2023, 1, 1),
            FileUID = "UID12345",
            PublishOnSend = true,
            FacebookPost = true,
            TwitterTweet = true,
            LinkedInPost = true,
            TimeZoneSend = true,
            SendTimeOptimize = true,
            SendFrequencyOverride = true,
            Footer = 1
        };

        // Assert
        Assert.Equal(1, mailingApproval.MessageID);
        Assert.Equal(2, mailingApproval.PkId);
        Assert.Equal("Sample Body", mailingApproval.Body);
        Assert.Equal("Sample Header", mailingApproval.HeaderAll);
        Assert.Equal("01/01/2023", mailingApproval.HeaderDate);
        Assert.Equal("sender@domain.com", mailingApproval.HeaderFrom);
        Assert.Equal("Sender <sender@domain.com>", mailingApproval.HeaderFromSpc);
        Assert.Equal("Sample Subject", mailingApproval.HeaderSubject);
        Assert.Equal("receiver@domain.com", mailingApproval.HeaderTo);
        Assert.Equal("Sample List", mailingApproval.List);
        Assert.Equal(100, mailingApproval.MaxRecips);
        Assert.Equal(1, mailingApproval.ReSubmit);
        Assert.Equal("Active", mailingApproval.Status);
        Assert.Equal(10, mailingApproval.SubsetID);
        Assert.Equal("Sample Title", mailingApproval.Title);
        Assert.Equal("Sample Transaction", mailingApproval.Transact);
        Assert.Equal("Sample Type", mailingApproval.Type);
        Assert.Equal(new DateTime(2023, 1, 1), mailingApproval.UpdatedDate);
        Assert.Equal("UID12345", mailingApproval.FileUID);
        Assert.True(mailingApproval.PublishOnSend);
        Assert.True(mailingApproval.FacebookPost);
        Assert.True(mailingApproval.TwitterTweet);
        Assert.True(mailingApproval.LinkedInPost);
        Assert.True(mailingApproval.TimeZoneSend);
        Assert.True(mailingApproval.SendTimeOptimize);
        Assert.True(mailingApproval.SendFrequencyOverride);
        Assert.Equal(1, mailingApproval.Footer);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var mailingApproval = new MailingApproval
        {
            MessageID = null,
            PkId = null,
            Body = null,
            HeaderAll = null,
            HeaderDate = null,
            HeaderFrom = null,
            HeaderFromSpc = null,
            HeaderSubject = null,
            HeaderTo = null,
            List = null,
            MaxRecips = null,
            ReSubmit = null,
            Status = null,
            SubsetID = null,
            Title = null,
            Transact = null,
            Type = null,
            UpdatedDate = null,
            FileUID = null,
            PublishOnSend = null,
            FacebookPost = null,
            TwitterTweet = null,
            LinkedInPost = null,
            TimeZoneSend = null,
            SendTimeOptimize = null,
            SendFrequencyOverride = null,
            Footer = null
        };

        // Act
        var result = mailingApproval.ToString();

        // Assert
        const string expected =
            "MessageID: , PkId: , Body: , HeaderAll: , HeaderDate: , HeaderFrom: , HeaderFromSpc: , HeaderSubject: , HeaderTo: , List: , MaxRecips: , ReSubmit: , Status: , SubsetID: , Title: , Transact: , Type: , UpdatedDate: , FileUID: , PublishOnSend: , FacebookPost: , TwitterTweet: , LinkedInPost: , TimeZoneSend: , SendTimeOptimize: , SendFrequencyOverride: , Footer: ";
        Assert.Equal(expected, result);
    }
}