using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra.Dto;

public record SegmentDto
{
    /// <summary>
    /// Gets or inits the identifier of the segment.
    /// </summary>
    [JsonPropertyName("SegmentID")]
    [Description("The unique identifier of the segment.")]
    public int SegmentID { get; init; }

    /// <summary>
    /// Gets or inits the description of the segment.
    /// </summary>
    [JsonPropertyName("Description")]
    [Description("The description of the segment.")]
    public string Description { get; init; }

    /// <summary>
    /// Gets or inits the name of the list associated with the segment.
    /// </summary>
    [JsonPropertyName("List")]
    [Description("The name of the list associated with the segment.")]
    public string List { get; init; }

    /// <summary>
    /// Gets or inits the name of the segment.
    /// </summary>
    [JsonPropertyName("Name")]
    [Description("The name of the segment.")]
    public string Name { get; init; }

    /// <summary>
    /// Gets or inits the type of the segment.
    /// </summary>
    [JsonPropertyName("SegmentType")]
    [Description("The type of the segment.")]
    public string SegmentType { get; init; }

    /// <summary>
    /// Gets or inits the date and time when the segment was created.
    /// </summary>
    [JsonPropertyName("Created")]
    [Description("The date and time when the segment was created.")]
    public DateTime Created { get; init; }

    /// <summary>
    /// Gets or inits the date and time when the segment was last modified.
    /// </summary>
    [JsonPropertyName("Modified")]
    [Description("The date and time when the segment was last modified.")]
    public DateTime Modified { get; init; }

    /// <summary>
    /// Gets or inits the date and time when the segment was last used.
    /// </summary>
    [JsonPropertyName("LastUsed")]
    [Description("The date and time when the segment was last used.")]
    public DateTime LastUsed { get; init; }

    /// <summary>
    /// Gets or inits the directory identifier associated with the segment.
    /// </summary>
    [JsonPropertyName("DirectoryID")]
    [Description("The directory identifier associated with the segment.")]
    public int DirectoryID { get; init; }

    /// <summary>
    /// Gets or inits the count of recipients last used in the segment.
    /// </summary>
    [JsonPropertyName("LastUsedRecipientCount")]
    [Description("The count of recipients last used in the segment.")]
    public int LastUsedRecipientCount { get; init; }

    /// <summary>
    /// Determines whether the specified SegmentDto is equal to the current SegmentDto.
    /// </summary>
    /// <param name="other">The SegmentDto to compare with the current SegmentDto.</param>
    /// <returns>true if the specified SegmentDto is equal to the current SegmentDto; otherwise, false.</returns>
    public virtual bool Equals(SegmentDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return SegmentID == other.SegmentID;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return SegmentID;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(SegmentID)}: {SegmentID}, {nameof(Description)}: {Description}, {nameof(List)}: {List}, {nameof(Name)}: " +
            $"{Name}, {nameof(SegmentType)}: {SegmentType}, {nameof(Created)}: {Created}, {nameof(Modified)}: {Modified}, " +
            $"{nameof(LastUsed)}: {LastUsed}, {nameof(DirectoryID)}: {DirectoryID}, {nameof(LastUsedRecipientCount)}: " +
            $"{LastUsedRecipientCount}";
    }
}