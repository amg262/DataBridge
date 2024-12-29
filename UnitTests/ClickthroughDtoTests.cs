using DataBridge.Models.Delivra.Dto;
using Xunit;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="ClickthroughDto"/> class.
/// </summary>
public class ClickthroughDtoTests
{
    /// <summary>
    /// Tests the ToString method with default values.
    /// </summary>
    [Fact]
    public void ToString_DefaultValues_ReturnsExpectedString()
    {
        // Arrange
        var clickthroughDto = new ClickthroughDto
        {
            EmailAddress = null,
            MemberID = null,
            MailingID = null,
            EventTime = null,
            URI = null,
            Name = null,
            IPAddress = null
        };

        // Act
        var result = clickthroughDto.ToString();

        // Assert
        const string expected = "EmailAddress: , MemberID: , MailingID: , EventTime: , URI: , Name: , IPAddress: ";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with specific values.
    /// </summary>
    [Fact]
    public void ToString_SpecificValues_ReturnsExpectedString()
    {
        // Arrange
        var clickthroughDto = new ClickthroughDto
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
        var result = clickthroughDto.ToString();

        // Assert
        const string expected = "EmailAddress: test@example.com, MemberID: 123, MailingID: 456, EventTime: 6/7/2023 12:00:00 PM, URI: http://example.com, Name: TestName, IPAddress: 127.0.0.1";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the property values of the ClickthroughDto object.
    /// </summary>
    [Fact]
    public void PropertyValues_SetValues_ReturnsExpectedValues()
    {
        // Arrange
        var clickthroughDto = new ClickthroughDto
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        // Act & Assert
        Assert.Equal("test@example.com", clickthroughDto.EmailAddress);
        Assert.Equal(123, clickthroughDto.MemberID);
        Assert.Equal(456, clickthroughDto.MailingID);
        Assert.Equal(new DateTime(2023, 6, 7, 12, 0, 0), clickthroughDto.EventTime);
        Assert.Equal("http://example.com", clickthroughDto.URI);
        Assert.Equal("TestName", clickthroughDto.Name);
        Assert.Equal("127.0.0.1", clickthroughDto.IPAddress);
    }

    /// <summary>
    /// Tests the default values of the ClickthroughDto properties.
    /// </summary>
    [Fact]
    public void DefaultValues_ReturnsExpectedDefaultValues()
    {
        // Arrange
        var clickthroughDto = new ClickthroughDto();

        // Act & Assert
        Assert.Null(clickthroughDto.EmailAddress);
        Assert.Null(clickthroughDto.MemberID);
        Assert.Null(clickthroughDto.MailingID);
        Assert.Null(clickthroughDto.EventTime);
        Assert.Null(clickthroughDto.URI);
        Assert.Null(clickthroughDto.Name);
        Assert.Null(clickthroughDto.IPAddress);
    }

    /// <summary>
    /// Tests the ClickthroughDto properties with null values.
    /// </summary>
    [Fact]
    public void PropertyValues_NullValues_ReturnsExpectedNullValues()
    {
        // Arrange
        var clickthroughDto = new ClickthroughDto
        {
            EmailAddress = null,
            MemberID = null,
            MailingID = null,
            EventTime = null,
            URI = null,
            Name = null,
            IPAddress = null
        };

        // Act & Assert
        Assert.Null(clickthroughDto.EmailAddress);
        Assert.Null(clickthroughDto.MemberID);
        Assert.Null(clickthroughDto.MailingID);
        Assert.Null(clickthroughDto.EventTime);
        Assert.Null(clickthroughDto.URI);
        Assert.Null(clickthroughDto.Name);
        Assert.Null(clickthroughDto.IPAddress);
    }

    /// <summary>
    /// Tests the Equals method with identical ClickthroughDto objects.
    /// </summary>
    [Fact]
    public void Equals_IdenticalObjects_ReturnsTrue()
    {
        // Arrange
        var clickthroughDto1 = new ClickthroughDto
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        var clickthroughDto2 = new ClickthroughDto
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
        var result = clickthroughDto1.Equals(clickthroughDto2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different ClickthroughDto objects.
    /// </summary>
    [Fact]
    public void Equals_DifferentObjects_ReturnsFalse()
    {
        // Arrange
        var clickthroughDto1 = new ClickthroughDto
        {
            EmailAddress = "test1@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example1.com",
            Name = "TestName1",
            IPAddress = "127.0.0.1"
        };

        var clickthroughDto2 = new ClickthroughDto
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
        var result = clickthroughDto1.Equals(clickthroughDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with identical ClickthroughDto objects.
    /// </summary>
    [Fact]
    public void GetHashCode_IdenticalObjects_ReturnsSameHashCode()
    {
        // Arrange
        var clickthroughDto1 = new ClickthroughDto
        {
            EmailAddress = "test@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example.com",
            Name = "TestName",
            IPAddress = "127.0.0.1"
        };

        var clickthroughDto2 = new ClickthroughDto
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
        var hashCode1 = clickthroughDto1.GetHashCode();
        var hashCode2 = clickthroughDto2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different ClickthroughDto objects.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentObjects_ReturnsDifferentHashCode()
    {
        // Arrange
        var clickthroughDto1 = new ClickthroughDto
        {
            EmailAddress = "test1@example.com",
            MemberID = 123,
            MailingID = 456,
            EventTime = new DateTime(2023, 6, 7, 12, 0, 0),
            URI = "http://example1.com",
            Name = "TestName1",
            IPAddress = "127.0.0.1"
        };

        var clickthroughDto2 = new ClickthroughDto
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
        var hashCode1 = clickthroughDto1.GetHashCode();
        var hashCode2 = clickthroughDto2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
}