namespace DataBridge.Models.Contentserv;

/// <summary>
/// Represents the result of an import operation.
/// </summary>
public class ImportResult
{
    /// <summary>
    /// Gets or sets the total number of items processed during the import operation.
    /// </summary>
    public int? TotalProcessed { get; set; } = 0;

    /// <summary>
    /// Gets or sets the number of new items added during the import operation.
    /// </summary>
    public int? Added { get; set; } = 0;

    /// <summary>
    /// Gets or sets the number of existing items updated during the import operation.
    /// </summary>
    public int? Updated { get; set; } = 0;

    /// <summary>
    /// Flag indicating whether changes were uploaded during the import operation.
    /// </summary>
    public bool? ChangesUploaded { get; set; } = false;
}