namespace DataBridge.Options;

/// <summary>
/// Represents configuration options for Contentserv integration.
/// </summary>
public record ContentservOptions
{
    /// <summary>
    /// Gets the base URL for the Contentserv API.
    /// </summary>
    public string? BaseUrl { get; init; } = string.Empty;

    /// <summary>
    /// Gets the API key for Contentserv authentication.
    /// </summary>
    public string? ApiKey { get; init; } = string.Empty;

    /// <summary>
    /// Gets the secret key for Contentserv authentication.
    /// </summary>
    public string? Secret { get; init; } = string.Empty;

    /// <summary>
    /// Gets the interval for token checking, in an unspecified time unit.
    /// </summary>
    public double TokenIntervalCheck { get; init; }

    /// <summary>
    /// Gets the access token for Contentserv API calls.
    /// </summary>
    public string? AcccesToken { get; init; }

    /// <summary>
    /// Gets the refresh token for Contentserv authentication.
    /// </summary>
    public string? RefreshToken { get; init; }

    /// <summary>
    /// Gets the expiration date and time of the access token.
    /// </summary>
    public DateTime AccessTokenExpiry { get; init; }

    /// <summary>
    /// Gets the Ellsworth authentication key.
    /// </summary>
    public string? AuthKey { get; init; }
}