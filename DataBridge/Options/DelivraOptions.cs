namespace DataBridge.Options;

/// <summary>
/// Represents the settings for Delivra integration.
/// This class is used in the Options pattern to bind configuration settings.
/// </summary>
public record DelivraOptions
{
    /// <summary>
    /// Gets or sets the base URL for the Delivra API.
    /// </summary>
    public string? BaseUrl { get; init; } = string.Empty; //= "https://integration.delivra.com/DelivraRESTServices/Services.svc/";

    /// <summary>
    /// Gets or sets the username for the Delivra API.
    /// </summary>
    public string? Username { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for the Delivra API.
    /// </summary>
    public string? Password { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the list name for the Delivra API.
    /// </summary>
    public string? Listname { get; init; } = string.Empty;
}