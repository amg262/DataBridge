using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Delivra;

/// <summary>
/// Represents the details of a segment.
/// </summary>
public class Segment
{
    /// <summary>
    /// Gets or sets the identifier of the segment.
    /// </summary>
    [JsonPropertyName("SegmentID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int? SegmentID { get; set; }

    // /// <summary>
    // /// Gets or sets the iternal identifier of the segment.
    // /// </summary>
    // [Key]
    // public int? PkId { get; set; }

    /// <summary>
    /// Gets or sets the description of the segment.
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the name of the list associated with the segment.
    /// </summary>
    [JsonPropertyName("List")]
    public string? List { get; set; }

    /// <summary>
    /// Gets or sets the name of the segment.
    /// </summary>
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the segment.
    /// </summary>
    [JsonPropertyName("SegmentType")]
    public string? SegmentType { get; set; }


    /// <summary>
    /// Gets or sets the date and time when the segment was created.
    /// </summary>
    [JsonPropertyName("Created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the segment was last modified.
    /// </summary>
    [JsonPropertyName("Modified")]
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the segment was last used.
    /// </summary>
    [JsonPropertyName("LastUsed")]
    public DateTime LastUsed { get; set; }

    /// <summary>
    /// Gets or sets the directory identifier associated with the segment.
    /// </summary>
    [JsonPropertyName("DirectoryID")]
    public int? DirectoryID { get; set; }

    /// <summary>
    /// Gets or sets the count of recipients last used in the segment.
    /// </summary>
    [JsonPropertyName("LastUsedRecipientCount")]
    public int? LastUsedRecipientCount { get; set; }


    /// <summary>
    /// Determines whether the specified Segment is equal to the current Segment.
    /// </summary>
    /// <param name="other">The Segment to compare with the current Segment.</param>
    /// <returns>true if the specified Segment is equal to the current Segment; otherwise, false.</returns>
    private bool Equals(Segment other)
    {
        return SegmentID == other.SegmentID;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Segment)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return SegmentID.GetHashCode();
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return
            $"{nameof(SegmentID)}: {SegmentID}, {nameof(Description)}: {Description}, {nameof(List)}: {List}, {nameof(Name)}:" +
            $" {Name}, {nameof(SegmentType)}: {SegmentType}, {nameof(Created)}: {Created}, {nameof(Modified)}: {Modified}, " +
            $"{nameof(LastUsed)}: {LastUsed}, {nameof(DirectoryID)}: {DirectoryID}, {nameof(LastUsedRecipientCount)}: " +
            $"{LastUsedRecipientCount}";
    }
}