namespace DataBridge.Options;

/// <summary>
/// Represents configuration options for ElevenLabs integration.
/// </summary>
public record ElevenLabsOptions
{
    /// <summary>
    /// Gets the base URL for the ElevenLabs API.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// Gets the API key for ElevenLabs authentication.
    /// </summary>
    public string? ApiKey { get; init; }
}