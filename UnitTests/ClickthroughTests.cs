using DataBridge.Models.Delivra;
using Xunit;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="Clickthrough"/> class.
/// </summary>
public class ClickthroughTests
{
    /// <summary>
    /// Tests the ToString method with default values.
    /// </summary>
    [Fact]
    public void ToString_DefaultValues_ReturnsExpectedString()
    {
        // Arrange
        var clickthrough = new Clickthrough
        {
            PkId = null,
            EmailAddress = null,
            MemberID = null,
            MailingID = null,
            EventTime = null,
            URI = null,
            Name = null,
            IPAddress = null
        };

        // Act
        var result = clickthrough.ToString();

        // Assert
        const string expected = "PkId: , EmailAddress: , MemberID: , MailingID: , EventTime: , URI: , Name: , IPAddress: ";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with specific values.
    /// </summary>
    [Fact]
    public void ToString_SpecificValues_ReturnsExpectedString()
    {
        // Arrange
        var clickthrough = new Clickthrough
        {
            PkId = 1,
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        // Act
        var result = clickthrough.ToString();

        // Assert
        const string expected =
            "PkId: 1, EmailAddress: test@example.com, MemberID: 123, MailingID: 456, EventTime: 6/7/2023 12:00:00 PM, URI: http://example.com, Name: TestName, IPAddress: 127.0.0.1";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the property values of the Clickthrough object.
    /// </summary>
    [Fact]
    public void PropertyValues_SetValues_ReturnsExpectedValues()
    {
        // Arrange
        var clickthrough = new Clickthrough
        {
            PkId = 1,
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        // Act & Assert
        Assert.Equal(1, clickthrough.PkId);
        Assert.Equal("test@example.com", clickthrough.EmailAddress);
        Assert.Equal(123, clickthrough.MemberID);
        Assert.Equal(456, clickthrough.MailingID);
        Assert.Equal(new DateTime(2023, 6, 7, 12, 0, 0), clickthrough.EventTime);
        Assert.Equal("http://example.com", clickthrough.URI);
        Assert.Equal("TestName", clickthrough.Name);
        Assert.Equal("127.0.0.1", clickthrough.IPAddress);
    }

    /// <summary>
    /// Tests the default values of the Clickthrough properties.
    /// </summary>
    [Fact]
    public void DefaultValues_ReturnsExpectedDefaultValues()
    {
        // Arrange
        var clickthrough = new Clickthrough();

        // Act & Assert
        Assert.Null(clickthrough.PkId);
        Assert.Null(clickthrough.EmailAddress);
        Assert.Null(clickthrough.MemberID);
        Assert.Null(clickthrough.MailingID);
        Assert.Null(clickthrough.EventTime);
        Assert.Null(clickthrough.URI);
        Assert.Null(clickthrough.Name);
        Assert.Null(clickthrough.IPAddress);
    }

    /// <summary>
    /// Tests the Clickthrough properties with null values.
    /// </summary>
    [Fact]
    public void PropertyValues_NullValues_ReturnsExpectedNullValues()
    {
        // Arrange
        var clickthrough = new Clickthrough
        {
            PkId = null,
            EmailAddress = null,
            MemberID = null,
            MailingID = null,
            EventTime = null,
            URI = null,
            Name = null,
            IPAddress = null
        };

        // Act & Assert
        Assert.Null(clickthrough.PkId);
        Assert.Null(clickthrough.EmailAddress);
        Assert.Null(clickthrough.MemberID);
        Assert.Null(clickthrough.MailingID);
        Assert.Null(clickthrough.EventTime);
        Assert.Null(clickthrough.URI);
        Assert.Null(clickthrough.Name);
        Assert.Null(clickthrough.IPAddress);
    }

    /// <summary>
    /// Tests the Equals method with identical Clickthrough objects.
    /// </summary>
    [Fact]
    public void Equals_IdenticalObjects_ReturnsTrue()
    {
        // Arrange
        var clickthrough1 = new Clickthrough
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        var clickthrough2 = new Clickthrough
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        // Act
        var result = clickthrough1.Equals(clickthrough2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different Clickthrough objects.
    /// </summary>
    [Fact]
    public void Equals_DifferentObjects_ReturnsFalse()
    {
        // Arrange
        var clickthrough1 = new Clickthrough
        {
            EmailAddress = "test1@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example1.com",
            Name = "TestName1",
            IPAddress = "127.0.0.1"
        };

        var clickthrough2 = new Clickthrough
        {
            EmailAddress = "test2@example.com",
            MemberID = 124,
            MailingID = 457,
            EventTime = new DateTime(2023, 6, 8, 12, 0, 0),
            URI = "http://example2.com",
            Name = "TestName2",
            IPAddress = "127.0.0.2"
        };

        // Act
        var result = clickthrough1.Equals(clickthrough2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with identical Clickthrough objects.
    /// </summary>
    [Fact]
    public void GetHashCode_IdenticalObjects_ReturnsSameHashCode()
    {
        // Arrange
        var clickthrough1 = new Clickthrough
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        var clickthrough2 = new Clickthrough
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        // Act
        var hashCode1 = clickthrough1.GetHashCode();
        var hashCode2 = clickthrough2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different Clickthrough objects.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentObjects_ReturnsDifferentHashCode()
    {
        // Arrange
        var clickthrough1 = new Clickthrough
        {
            EmailAddress = "test1@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example1.com",
            Name = "TestName1",
            IPAddress = "127.0.0.1"
        };

        var clickthrough2 = new Clickthrough
        {
            EmailAddress = "test2@example.com",
            MemberID = 124,
            MailingID = 457,
            EventTime = new DateTime(2023, 6, 8, 12, 0, 0),
            URI = "http://example2.com",
            Name = "TestName2",
            IPAddress = "127.0.0.2"
        };

        // Act
        var hashCode1 = clickthrough1.GetHashCode();
        var hashCode2 = clickthrough2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
}