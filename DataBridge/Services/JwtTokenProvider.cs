using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataBridge.Helpers;
using DataBridge.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DataBridge.Services;

/// <summary>
/// Service for generating JWT tokens.
/// </summary>
public class JwtTokenGenerator
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JwtOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtTokenGenerator"/> class.
    /// </summary>
    /// <param name="options">The JWT options.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public JwtTokenGenerator(IOptions<JwtOptions> options, IHttpContextAccessor httpContextAccessor)
    {
        _options = options.Value;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Generates a JWT token with claims including the user's IP address.
    /// </summary>
    /// <returns>A JWT token string.</returns>
    public string GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret ?? string.Empty));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // IP address from the current HTTP context
        var ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique identifier for the token
            new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture), ClaimValueTypes.Integer64),
            new("ip", ip)
        };

        // token descriptor with issuer, audience, expiration, signing credentials, and claims
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _options.Issuer,
            Audience = _options.Audience,

            Expires = DateTime.MaxValue, // This token never expires
            // Expires = DateTime.Now.AddDays(_options.ExpirationInDays),
            SigningCredentials = creds,
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.UtcNow
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

/// <summary>
/// Provides token management services for authentication purposes.
/// </summary>
public class JwtTokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JwtOptions _options;
    private readonly ILogger<JwtTokenProvider> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtTokenProvider"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Provides access to the HTTP context.</param>
    /// <param name="options">Options for configuring JWT token handling.</param>
    /// <param name="logger">Logger for JwtTokenProvider</param>
    public JwtTokenProvider(IHttpContextAccessor httpContextAccessor, IOptions<JwtOptions> options,
        ILogger<JwtTokenProvider> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
        _options = options.Value;
    }

    /// <summary>
    /// Boolean flag indicating whether the token is available.
    /// </summary>
    private bool? HasToken { get; set; } = false;

    /// <summary>
    /// Sets the authentication token in the HTTP context's cookies.
    /// </summary>
    /// <param name="token">The authentication token to be set.</param>
    /// <returns>The issued token if successful, otherwise null.</returns>
    public string? IssueToken(string token)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(ProjectHelper.TokenCookie, token);
        HasToken = true;
        return HasToken == true ? token : null;
    }

    /// <summary>
    /// Retrieves the authentication token from the HTTP context's cookies.
    /// </summary>
    /// <returns>The authentication token if available; otherwise, null.</returns>
    public string? RetrieveToken()
    {
        return _httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue(ProjectHelper.TokenCookie, out var token) == true
            ? token
            : null;
    }

    /// <summary>
    /// Clears the authentication token from the HTTP context's cookies.
    /// </summary>
    /// <remarks>
    /// Sets the token to an empty string and deletes the cookie from the response.
    /// It's a redundant approach to ensure the token is cleared. Doing both ensures all browsers are covered.
    /// </remarks>
    /// <returns>True if the token was successfully cleared.</returns>
    public bool ClearToken()
    {
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(-2)
        };

        _httpContextAccessor.HttpContext?.Response.Cookies.Append(ProjectHelper.TokenCookie, "", cookieOptions);
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(ProjectHelper.TokenCookie);
        HasToken = false;
        return true;
    }

    /// <summary>
    /// Validates the given JWT token.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>True if the token is valid; otherwise, false.</returns>
    public bool ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret))
            }, out var validatedToken);

            return validatedToken != null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token validation failed: {Token}", token);
            return false;
        }
    }

    /// <summary>
    /// Invalidates the given token by setting its expiration to a past date.
    /// </summary>
    /// <param name="token">The token to invalidate.</param>
    /// <returns>True if the token was successfully invalidated, false otherwise.</returns>
    public bool InvalidateToken(string token)
    {
        if (string.IsNullOrEmpty(token)) return false;

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        var claims = jwtToken.Claims.ToList();

        // Remove the existing expiration claim
        claims.RemoveAll(claim => claim.Type == JwtRegisteredClaimNames.Exp);

        // Add a new expiration claim set to a past date
        claims.Add(new Claim(JwtRegisteredClaimNames.Exp,
            EpochTime.GetIntDate(DateTime.UtcNow.AddMinutes(-5)).ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret ?? string.Empty));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var newToken = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(-1),
            signingCredentials: creds);

        var newTokenString = tokenHandler.WriteToken(newToken);

        // Replace the old token set new invalidated one
        ClearToken();
        IssueToken(newTokenString);

        _logger.LogInformation("Token invalidated: {Token}", token);

        return true;
    }
}