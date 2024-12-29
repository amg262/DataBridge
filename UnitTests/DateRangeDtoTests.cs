using DataBridge.Models.Delivra.Dto;
using Xunit;

namespace UnitTests;

/// <summary>
/// Tests for the <see cref="DateRangeDto"/> class.
/// </summary>
public class DateRangeDtoTests
{
    /// <summary>
    /// Tests the ToString method with default values.
    /// </summary>
    [Fact]
    public void ToString_DefaultValues_ReturnsExpectedString()
    {
        // Arrange
        var dateRangeDto = new DateRangeDto
        {
            StartDate = DateTime.MinValue,
            EndDate = DateTime.MinValue
        };

        // Act
        var result = dateRangeDto.ToString();

        // Assert
        const string expected = "StartDate: 1/1/0001 12:00:00 AM, EndDate: 1/1/0001 12:00:00 AM";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with null values.
    /// </summary>
    [Fact]
    public void ToString_NullValues_ReturnsExpectedString()
    {
        // Arrange
        var dateRangeDto = new DateRangeDto
        {
            StartDate = null,
            EndDate = null
        };

        // Act
        var result = dateRangeDto.ToString();

        // Assert
        const string expected = "StartDate: , EndDate: ";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the ToString method with specific values.
    /// </summary>
    [Fact]
    public void ToString_SpecificValues_ReturnsExpectedString()
    {
        // Arrange
        var dateRangeDto = new DateRangeDto
        {
            StartDate = new DateTime(2023, 6, 7),
            EndDate = new DateTime(2024, 6, 7)
        };

        // Act
        var result = dateRangeDto.ToString();

        // Assert
        const string expected = "StartDate: 6/7/2023 12:00:00 AM, EndDate: 6/7/2024 12:00:00 AM";
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests the property values of the DateRangeDto object.
    /// </summary>
    [Fact]
    public void PropertyValues_SetValues_ReturnsExpectedValues()
    {
        // Arrange
        var dateRangeDto = new DateRangeDto
        {
            StartDate = new DateTime(2023, 6, 7),
            EndDate = new DateTime(2024, 6, 7)
        };

        // Act & Assert
        Assert.Equal(new DateTime(2023, 6, 7), dateRangeDto.StartDate);
        Assert.Equal(new DateTime(2024, 6, 7), dateRangeDto.EndDate);
    }

    /// <summary>
    /// Tests the default values of the DateRangeDto properties.
    /// </summary>
    [Fact]
    public void DefaultValues_ReturnsExpectedDefaultValues()
    {
        // Arrange
        var dateRangeDto = new DateRangeDto();

        // Act & Assert
        Assert.Null(dateRangeDto.StartDate);
        Assert.Null(dateRangeDto.EndDate);
    }

    /// <summary>
    /// Tests the DateRangeDto properties with null values.
    /// </summary>
    [Fact]
    public void PropertyValues_NullValues_ReturnsExpectedNullValues()
    {
        // Arrange
        var dateRangeDto = new DateRangeDto
        {
            StartDate = null,
            EndDate = null
        };

        // Act & Assert
        Assert.Null(dateRangeDto.StartDate);
        Assert.Null(dateRangeDto.EndDate);
    }
}