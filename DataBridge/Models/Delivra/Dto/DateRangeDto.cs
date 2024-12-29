using System.ComponentModel;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace DataBridge.Models.Delivra.Dto;

/// <summary>
/// Represents a date range for a report with start and end dates.
/// </summary>
public record DateRangeDto
{
    /// <summary>
    /// Gets or sets the start date of the report. Format: YYYY-MM-DD.
    /// </summary>
    [JsonPropertyName("startDate")]
    [Description("The start date of the report. Format: YYYY-MM-DD")]
    [SwaggerSchema(Description = "The start date of the report. Format: YYYY-MM-DD", Title = "Start Date")]
    [DefaultValue("2023-06-07")]
    public DateTime? StartDate { get; init; }

    /// <summary>
    /// Gets or sets the end date of the report. Format: YYYY-MM-DD.
    /// </summary>
    [JsonPropertyName("endDate")]
    [Description("The end date of the report. Format: YYYY-MM-DD")]
    [SwaggerSchema(Description = "The end date of the report. Format: YYYY-MM-DD", Title = "End Date")]
    [DefaultValue("2024-06-07")]
    public DateTime? EndDate { get; init; }

    /// <summary>
    /// Returns a string that represents the current DateRangeDto.
    /// </summary>
    /// <returns>A string that represents the current DateRangeDto.</returns>
    public override string ToString()
    {
        return $"{nameof(StartDate)}: {StartDate}, {nameof(EndDate)}: {EndDate}";
    }
}