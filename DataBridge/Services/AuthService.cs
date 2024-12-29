using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DataBridge.Services;

/// <summary>
/// Provides authentication services for managing JWT tokens.
/// </summary>
public class AuthService
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly JwtTokenProvider _jwtTokenProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="jwtTokenGenerator">The JWT token generator service.</param>
    /// <param name="jwtTokenProvider">The JWT token provider service.</param>
    public AuthService(JwtTokenGenerator jwtTokenGenerator, JwtTokenProvider jwtTokenProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _jwtTokenProvider = jwtTokenProvider;
    }

    /// <summary>
    /// Issues a new JWT token.
    /// </summary>
    /// <returns>The issued JWT token as a string, or null if the operation fails.</returns>
    public string? IssueToken() => _jwtTokenProvider.IssueToken(_jwtTokenGenerator.GenerateToken());

    /// <summary>
    /// Validates a given JWT token.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>True if the token is valid, false if invalid, or null if the operation fails.</returns>
    public bool? ValidateToken(string token) => _jwtTokenProvider.ValidateToken(token);

    /// <summary>
    /// Invalidates a given JWT token.
    /// </summary>
    /// <param name="token">The JWT token to invalidate.</param>
    /// <returns>True if the token was successfully invalidated, false if not, or null if the operation fails.</returns>
    public bool? InvalidateToken(string token) => _jwtTokenProvider.InvalidateToken(token);

    /// <summary>
    /// Retrieves the current JWT token.
    /// </summary>
    /// <returns>The current JWT token as a string, or null if no token is available or the operation fails.</returns>
    public string? RetrieveToken() => _jwtTokenProvider.RetrieveToken();

    /// <summary>
    /// Clears the current JWT token.
    /// </summary>
    /// <returns>True if the token was successfully cleared, false if not, or null if the operation fails.</returns>
    public bool? ClearToken() => _jwtTokenProvider.ClearToken();
}