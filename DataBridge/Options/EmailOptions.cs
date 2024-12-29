namespace DataBridge.Options;

/// <summary>
/// Represents configuration options for email functionality.
/// </summary>
public record EmailOptions
{
    /// <summary>
    /// Gets the secret key used for email authentication or encryption.
    /// </summary>
    public string? SecretKey { get; init; }

    /// <summary>
    /// Gets the email address used as the sender's address.
    /// </summary>
    public string? FromEmail { get; init; }

    /// <summary>
    /// Gets the display name of the email sender.
    /// </summary>
    public string? FromName { get; init; }
}