using DataBridge.Models.Delivra;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="Segment"/> class.
/// </summary>
public class SegmentTests
{
    /// <summary>
    /// Tests the Equals method with the same SegmentID.
    /// </summary>
    [Fact]
    public void Equals_SameSegmentID_ReturnsTrue()
    {
        // Arrange
        var segment1 = new Segment { SegmentID = 1 };
        var segment2 = new Segment { SegmentID = 1 };

        // Act
        var result = segment1.Equals(segment2);

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
        var segment1 = new Segment { SegmentID = 1 };
        var segment2 = new Segment { SegmentID = 2 };

        // Act
        var result = segment1.Equals(segment2);

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
        var segment1 = new Segment { SegmentID = 1 };
        var segment2 = new Segment { SegmentID = 1 };

        // Act
        var hashCode1 = segment1.GetHashCode();
        var hashCode2 = segment2.GetHashCode();

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
        var segment1 = new Segment { SegmentID = 1 };
        var segment2 = new Segment { SegmentID = 2 };

        // Act
        var hashCode1 = segment1.GetHashCode();
        var hashCode2 = segment2.GetHashCode();

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
        var segment = new Segment
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
        var result = segment.ToString();

        // Assert
        var expected =
            "SegmentID: 1, Description: Test Description, List: Test List, Name: Test Name, SegmentType: Test Type, Created: 1/1/2023 12:00:00 AM, Modified: 2/1/2023 12:00:00 AM, LastUsed: 3/1/2023 12:00:00 AM, DirectoryID: 10, LastUsedRecipientCount: 100";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the Equals method with null.
    /// </summary>
    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        // Arrange
        var segment = new Segment { SegmentID = 1 };

        // Act
        var result = segment.Equals(null);

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
        var segment = new Segment { SegmentID = 1 };

        // Act
        var result = segment.Equals(segment);

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
        var segment = new Segment { SegmentID = 1 };
        var otherObject = new { SegmentID = 1 };

        // Act
        var result = segment.Equals(otherObject);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests the properties of the Segment class.
    /// </summary>
    [Fact]
    public void Properties_AssignedCorrectValues()
    {
        // Arrange
        var segment = new Segment
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
        Assert.Equal(1, segment.SegmentID);
        Assert.Equal("Test Description", segment.Description);
        Assert.Equal("Test List", segment.List);
        Assert.Equal("Test Name", segment.Name);
        Assert.Equal("Test Type", segment.SegmentType);
        Assert.Equal(new DateTime(2023, 1, 1), segment.Created);
        Assert.Equal(new DateTime(2023, 2, 1), segment.Modified);
        Assert.Equal(new DateTime(2023, 3, 1), segment.LastUsed);
        Assert.Equal(10, segment.DirectoryID);
        Assert.Equal(100, segment.LastUsedRecipientCount);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var segment = new Segment
        {
            SegmentID = null,
            Description = null,
            List = null,
            Name = null,
            SegmentType = null,
            Created = null,
            Modified = null,
            LastUsed = DateTime.MinValue,
            DirectoryID = null,
            LastUsedRecipientCount = null
        };

        // Act
        var result = segment.ToString();

        // Assert
        var expected =
            "SegmentID: , Description: , List: , Name: , SegmentType: , Created: , Modified: , LastUsed: 1/1/0001 12:00:00 AM, DirectoryID: , LastUsedRecipientCount: ";
        Assert.Equal(expected, result);
    }
}