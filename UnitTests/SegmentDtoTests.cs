using DataBridge.Models.Delivra.Dto;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="SegmentDto"/> class.
/// </summary>
public class SegmentDtoTests
{
    /// <summary>
    /// Tests the Equals method with the same SegmentID.
    /// </summary>
    [Fact]
    public void Equals_SameSegmentID_ReturnsTrue()
    {
        // Arrange
        var segmentDto1 = new SegmentDto { SegmentID = 1 };
        var segmentDto2 = new SegmentDto { SegmentID = 1 };

        // Act
        var result = segmentDto1.Equals(segmentDto2);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests the Equals method with different SegmentID.
    /// </summary>
    [Fact]
    public void Equals_DifferentSegmentID_ReturnsFalse()
    {
        // Arrange
        var segmentDto1 = new SegmentDto { SegmentID = 1 };
        var segmentDto2 = new SegmentDto { SegmentID = 2 };

        // Act
        var result = segmentDto1.Equals(segmentDto2);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the GetHashCode method with the same SegmentID.
    /// </summary>
    [Fact]
    public void GetHashCode_SameSegmentID_ReturnsSameHashCode()
    {
        // Arrange
        var segmentDto1 = new SegmentDto { SegmentID = 1 };
        var segmentDto2 = new SegmentDto { SegmentID = 1 };

        // Act
        var hashCode1 = segmentDto1.GetHashCode();
        var hashCode2 = segmentDto2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    /// <summary>
    /// Tests the GetHashCode method with different SegmentID.
    /// </summary>
    [Fact]
    public void GetHashCode_DifferentSegmentID_ReturnsDifferentHashCode()
    {
        // Arrange
        var segmentDto1 = new SegmentDto { SegmentID = 1 };
        var segmentDto2 = new SegmentDto { SegmentID = 2 };

        // Act
        var hashCode1 = segmentDto1.GetHashCode();
        var hashCode2 = segmentDto2.GetHashCode();

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
        var segmentDto = new SegmentDto
        {
            SegmentID = 1,
            Description = "Test Description",
            List = "Test List",
            Name = "Test Name",
            SegmentType = "Test Type",
            Created = new DateTime(2023, 1, 1),
            Modified = new DateTime(2023, 2, 1),
            LastUsed = new DateTime(2023, 3, 1),
            DirectoryID = 10,
            LastUsedRecipientCount = 100
        };

        // Act
        var result = segmentDto.ToString();

        // Assert
        var expected = "SegmentID: 1, Description: Test Description, List: Test List, Name: Test Name, SegmentType: Test Type, Created: 1/1/2023 12:00:00 AM, Modified: 2/1/2023 12:00:00 AM, LastUsed: 3/1/2023 12:00:00 AM, DirectoryID: 10, LastUsedRecipientCount: 100";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the Equals method with null.
    /// </summary>
    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var segmentDto = new SegmentDto { SegmentID = 1 };

        // Act
        var result = segmentDto.Equals(null);

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
        var segmentDto = new SegmentDto { SegmentID = 1 };

        // Act
        var result = segmentDto.Equals(segmentDto);

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
        var segmentDto = new SegmentDto { SegmentID = 1 };
        var otherObject = new { SegmentID = 1 };

        // Act
        var result = segmentDto.Equals(otherObject);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the properties of the SegmentDto class.
    /// </summary>
    [Fact]
    public void Properties_AssignedCorrectValues()
    {
        // Arrange
        var segmentDto = new SegmentDto
        {
            SegmentID = 1,
            Description = "Test Description",
            List = "Test List",
            Name = "Test Name",
            SegmentType = "Test Type",
            Created = new DateTime(2023, 1, 1),
            Modified = new DateTime(2023, 2, 1),
            LastUsed = new DateTime(2023, 3, 1),
            DirectoryID = 10,
            LastUsedRecipientCount = 100
        };

        // Assert
        Assert.Equal(1, segmentDto.SegmentID);
        Assert.Equal("Test Description", segmentDto.Description);
        Assert.Equal("Test List", segmentDto.List);
        Assert.Equal("Test Name", segmentDto.Name);
        Assert.Equal("Test Type", segmentDto.SegmentType);
        Assert.Equal(new DateTime(2023, 1, 1), segmentDto.Created);
        Assert.Equal(new DateTime(2023, 2, 1), segmentDto.Modified);
        Assert.Equal(new DateTime(2023, 3, 1), segmentDto.LastUsed);
        Assert.Equal(10, segmentDto.DirectoryID);
        Assert.Equal(100, segmentDto.LastUsedRecipientCount);
    }

    /// <summary>
    /// Tests the ToString method with default values.
    /// </summary>
    [Fact]
    public void ToString_DefaultValues_ReturnsExpectedString()
    {
        // Arrange
        var segmentDto = new SegmentDto
        {
            SegmentID = 0,
            Description = string.Empty,
            List = string.Empty,
            Name = string.Empty,
            SegmentType = string.Empty,
            Created = DateTime.MinValue,
            Modified = DateTime.MinValue,
            LastUsed = DateTime.MinValue,
            DirectoryID = 0,
            LastUsedRecipientCount = 0
        };

        // Act
        var result = segmentDto.ToString();

        // Assert
        var expected = "SegmentID: 0, Description: , List: , Name: , SegmentType: , Created: 1/1/0001 12:00:00 AM, Modified: 1/1/0001 12:00:00 AM, LastUsed: 1/1/0001 12:00:00 AM, DirectoryID: 0, LastUsedRecipientCount: 0";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var segmentDto = new SegmentDto
        {
            SegmentID = 0,
            Description = null,
            List = null,
            Name = null,
            SegmentType = null,
            Created = DateTime.MinValue,
            Modified = DateTime.MinValue,
            LastUsed = DateTime.MinValue,
            DirectoryID = 0,
            LastUsedRecipientCount = 0
        };

        // Act
        var result = segmentDto.ToString();

        // Assert
        var expected = "SegmentID: 0, Description: , List: , Name: , SegmentType: , Created: 1/1/0001 12:00:00 AM, Modified: 1/1/0001 12:00:00 AM, LastUsed: 1/1/0001 12:00:00 AM, DirectoryID: 0, LastUsedRecipientCount: 0";
        Assert.Equal(expected, result);
    }
}