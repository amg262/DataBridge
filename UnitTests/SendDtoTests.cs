using DataBridge.Models.Delivra.Dto;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="SendDto"/> record.
/// </summary>
public class SendDtoTests
{
    /// <summary>
    /// Tests the Equals method with the same EmailAddress, MemberID, MailingID, and EventTime.
    /// </summary>
    [Fact]
    public void Equals_SameProperties_ReturnsTrue()
    {
        // Arrange
        var sendDto1 = new SendDto
        {
            EmailAddress = "test@example.com",
            MemberID = 1,
            MailingID = 1,
            EventTime = new DateTime(2023, 1, 1)
        };
        var sendDto2 = new SendDto
        {
            EmailAddress = "test@example.com",
            MemberID = 1,
            MailingID = 1,
            EventTime = new DateTime(2023, 1, 1)
        };

        // Act
        var result = sendDto1.Equals(sendDto2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different EmailAddress.
    /// </summary>
    [Fact]
    public void Equals_DifferentEmailAddress_ReturnsFalse()
    {
        // Arrange
        var sendDto1 = new SendDto { EmailAddress = "test1@example.com" };
        var sendDto2 = new SendDto { EmailAddress = "test2@example.com" };

        // Act
        var result = sendDto1.Equals(sendDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the Equals method with different MemberID.
    /// </summary>
    [Fact]
    public void Equals_DifferentMemberID_ReturnsFalse()
    {
        // Arrange
        var sendDto1 = new SendDto { MemberID = 1 };
        var sendDto2 = new SendDto { MemberID = 2 };

        // Act
        var result = sendDto1.Equals(sendDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the Equals method with different MailingID.
    /// </summary>
    [Fact]
    public void Equals_DifferentMailingID_ReturnsFalse()
    {
        // Arrange
        var sendDto1 = new SendDto { MailingID = 1 };
        var sendDto2 = new SendDto { MailingID = 2 };

        // Act
        var result = sendDto1.Equals(sendDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the Equals method with different EventTime.
    /// </summary>
    [Fact]
    public void Equals_DifferentEventTime_ReturnsFalse()
    {
        // Arrange
        var sendDto1 = new SendDto { EventTime = new DateTime(2023, 1, 1) };
        var sendDto2 = new SendDto { EventTime = new DateTime(2024, 1, 1) };

        // Act
        var result = sendDto1.Equals(sendDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with the same properties.
    /// </summary>
    [Fact]
    public void GetHashCode_SameProperties_ReturnsSameHashCode()
    {
        // Arrange
        var sendDto1 = new SendDto
        {
            EmailAddress = "test@example.com",
            MemberID = 1,
            MailingID = 1,
            EventTime = new DateTime(2023, 1, 1)
        };
        var sendDto2 = new SendDto
        {
            EmailAddress = "test@example.com",
            MemberID = 1,
            MailingID = 1,
            EventTime = new DateTime(2023, 1, 1)
        };

        // Act
        var hashCode1 = sendDto1.GetHashCode();
        var hashCode2 = sendDto2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different properties.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentProperties_ReturnsDifferentHashCode()
    {
        // Arrange
        var sendDto1 = new SendDto
        {
            EmailAddress = "test1@example.com",
            MemberID = 1,
            MailingID = 1,
            EventTime = new DateTime(2023, 1, 1)
        };
        var sendDto2 = new SendDto
        {
            EmailAddress = "test2@example.com",
            MemberID = 2,
            MailingID = 2,
            EventTime = new DateTime(2024, 1, 1)
        };

        // Act
        var hashCode1 = sendDto1.GetHashCode();
        var hashCode2 = sendDto2.GetHashCode();

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
        var sendDto = new SendDto
        {
            EmailAddress = "test@example.com",
            MemberID = 1,
            MailingID = 1,
            EventTime = new DateTime(2023, 1, 1)
        };

        // Act
        var result = sendDto.ToString();

        // Assert
        var expected = "EmailAddress: test@example.com, MemberID: 1, MailingID: 1, EventTime: 1/1/2023 12:00:00 AM";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the Equals method with null.
    /// </summary>
    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var sendDto = new SendDto { EmailAddress = "test@example.com" };

        // Act
        var result = sendDto.Equals(null);

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
        var sendDto = new SendDto { EmailAddress = "test@example.com" };

        // Act
        var result = sendDto.Equals(sendDto);

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
        var sendDto = new SendDto { EmailAddress = "test@example.com" };
        var otherObject = new { EmailAddress = "test@example.com" };

        // Act
        var result = sendDto.Equals(otherObject);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the properties of the SendDto record.
    /// </summary>
    [Fact]
    public void Properties_AssignedCorrectValues()
    {
        // Arrange
        var sendDto = new SendDto
        {
            EmailAddress = "test@example.com",
            MemberID = 2,
            MailingID = 3,
            EventTime = new DateTime(2023, 1, 1)
        };

        // Assert
        Assert.Equal("test@example.com", sendDto.EmailAddress);
        Assert.Equal(2, sendDto.MemberID);
        Assert.Equal(3, sendDto.MailingID);
        Assert.Equal(new DateTime(2023, 1, 1), sendDto.EventTime);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var sendDto = new SendDto
        {
            EmailAddress = null,
            MemberID = null,
            MailingID = null,
            EventTime = null
        };

        // Act
        var result = sendDto.ToString();

        // Assert
        var expected = "EmailAddress: , MemberID: , MailingID: , EventTime: ";
        Assert.Equal(expected, result);
    }
}