namespace DataBridge.Options;

/// <summary>
/// Represents configuration options for LivePerson integration.
/// </summary>
public record LivePersonOptions
{
    /// <summary>
    /// Gets the base URL for the LivePerson API.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// Gets the account ID for LivePerson.
    /// </summary>
    public string? AccountId { get; init; }

    /// <summary>
    /// Gets the application key for LivePerson authentication.
    /// </summary>
    public string? AppKey { get; init; }

    /// <summary>
    /// Gets the application secret for LivePerson authentication.
    /// </summary>
    public string? AppSecret { get; init; }

    /// <summary>
    /// Gets the access token for LivePerson API calls.
    /// </summary>
    public string? AccessToken { get; init; }

    /// <summary>
    /// Gets the access token secret for LivePerson API calls.
    /// </summary>
    public string? AccessTokenSecret { get; init; }
}