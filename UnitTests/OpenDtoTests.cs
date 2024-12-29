using DataBridge.Models.Delivra.Dto;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="OpenDto"/> class.
/// </summary>
public class OpenDtoTests
{
    /// <summary>
    /// Tests the Equals method with the same values.
    /// </summary>
    [Fact]
    public void Equals_SameValues_ReturnsTrue()
    {
        // Arrange
        var openDto1 = new OpenDto
        {
            EmailAddress = "test@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        var openDto2 = new OpenDto
        {
            EmailAddress = "test@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        // Act
        var result = openDto1.Equals(openDto2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different values.
    /// </summary>
    [Fact]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        // Arrange
        var openDto1 = new OpenDto
        {
            EmailAddress = "test1@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        var openDto2 = new OpenDto
        {
            EmailAddress = "test2@domain.com",
            EventTime = new DateTime(2023, 1, 2),
            MailingID = 124,
            MemberID = 457,
            IPAddress = "127.0.0.2",
            ContactEngagement = 80.0,
            Platform = "Mac",
            PlatformVersion = "11",
            Browser = "Safari",
            BrowserVersion = "14.0",
            ReadingEnvironment = "Mobile"
        };

        // Act
        var result = openDto1.Equals(openDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with the same values.
    /// </summary>
    [Fact]
    public void GetHashCode_SameValues_ReturnsSameHashCode()
    {
        // Arrange
        var openDto1 = new OpenDto
        {
            EmailAddress = "test@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        var openDto2 = new OpenDto
        {
            EmailAddress = "test@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        // Act
        var hashCode1 = openDto1.GetHashCode();
        var hashCode2 = openDto2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different values.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentValues_ReturnsDifferentHashCode()
    {
        // Arrange
        var openDto1 = new OpenDto
        {
            EmailAddress = "test1@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        var openDto2 = new OpenDto
        {
            EmailAddress = "test2@domain.com",
            EventTime = new DateTime(2023, 1, 2),
            MailingID = 124,
            MemberID = 457,
            IPAddress = "127.0.0.2",
            ContactEngagement = 80.0,
            Platform = "Mac",
            PlatformVersion = "11",
            Browser = "Safari",
            BrowserVersion = "14.0",
            ReadingEnvironment = "Mobile"
        };

        // Act
        var hashCode1 = openDto1.GetHashCode();
        var hashCode2 = openDto2.GetHashCode();

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
        var openDto = new OpenDto
        {
            EmailAddress = "test@domain.com",
            EventTime = new DateTime(2023, 1, 1),
            MailingID = 123,
            MemberID = 456,
            IPAddress = "127.0.0.1",
            ContactEngagement = 75.5,
            Platform = "Windows",
            PlatformVersion = "10",
            Browser = "Chrome",
            BrowserVersion = "90.0.4430.212",
            ReadingEnvironment = "Desktop"
        };

        // Act
        var result = openDto.ToString();

        // Assert
        const string expected =
            " EmailAddress: test@domain.com, EventTime: 1/1/2023 12:00:00 AM, MailingID: 123, MemberID: 456, IPAddress: 127.0.0.1, ContactEngagement: 75.5, Platform: Windows, PlatformVersion: 10, Browser: Chrome, BrowserVersion: 90.0.4430.212, ReadingEnvironment: Desktop";
        Assert.Equal(expected, result);
    }
}