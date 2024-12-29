using System.Text.Json.Serialization;

namespace DataBridge.Models.Contentserv;

/// <summary>
/// Represents the response structure for token-related API calls to ContentServ.
/// </summary>
public class TokenResponse
{
    /// <summary>
    /// Gets or sets the access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets the ID token.
    /// The ID token is used to provide information about the authenticated user.
    /// It contains claims about the authentication event and other user information.
    /// </summary>
    [JsonPropertyName("id_token")]
    public string? IdToken { get; set; }

    /// <summary>
    /// Gets or sets the expiration time of the access token in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }

    /// <summary>
    /// Gets or sets the expiration time of the refresh token in seconds.
    /// </summary>
    [JsonPropertyName("refresh_expires_in")]
    public int? RefreshExpiresIn { get; set; }

    /// <summary>
    /// Gets or sets the token type.
    /// </summary>
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    /// <summary>
    /// Gets or sets the not-before policy timestamp.
    /// </summary>
    [JsonPropertyName("not-before-policy")]
    public long? NotBeforePolicy { get; set; }

    /// <summary>
    /// Gets or sets the session state.
    /// </summary>
    [JsonPropertyName("session_state")]
    public string? SessionState { get; set; }

    /// <summary>
    /// Gets or sets the scope of the token.
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}