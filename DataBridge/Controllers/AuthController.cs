using Asp.Versioning;
using DataBridge.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataBridge.Controllers;

/// <summary>
/// Controller responsible for handling JWT token operations.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="authService">The authentication service.</param>
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Generates a new JWT token and stores it.
    /// </summary>
    /// <returns>An IActionResult containing the generated JWT token.</returns>
    [HttpPost("IssueToken")]
    public IActionResult IssueToken()
    {
        var token = _authService.IssueToken();
        return token != null ? Ok(new { Token = token }) : StatusCode(500, "Failed to issue token");
    }

    /// <summary>
    /// Validates a given JWT token and sets it if valid.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>An IActionResult indicating whether the token is valid and set.</returns>
    [HttpPost("Validate/{token}")]
    public IActionResult ValidateToken(string token)
    {
        var isValid = _authService.ValidateToken(token);
        return isValid == true
            ? Ok(new { IsValid = true, Message = "Token validated and set successfully.", Token = token })
            : BadRequest("Invalid token");
    }

    /// <summary>
    /// Retrieves the stored JWT token.
    /// </summary>
    /// <returns>An IActionResult containing the stored JWT token.</returns>
    [HttpGet("RetrieveToken")]
    public IActionResult RetrieveToken()
    {
        var token = _authService.RetrieveToken();
        return token != null ? Ok(new { Token = token }) : NotFound("No token found");
    }

    /// <summary>
    /// Clears the stored JWT token.
    /// </summary>
    /// <returns>An IActionResult with a confirmation message indicating the token has been cleared.</returns>
    [HttpDelete("ClearToken")]
    public IActionResult ClearToken()
    {
        var cleared = _authService.ClearToken();
        return cleared == true ? Ok("Token cleared") : StatusCode(500, "Failed to clear token");
    }

    /// <summary>
    /// Invalidates a given JWT token by manipulating its expiration time.
    /// </summary>
    /// <param name="token">The JWT token to invalidate.</param>
    /// <returns>An IActionResult indicating whether the token was successfully invalidated.</returns>
    [HttpDelete("InvalidateToken")]
    public IActionResult InvalidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return BadRequest("Token is required");
        }

        var invalidated = _authService.InvalidateToken(token);
        return invalidated == true ? Ok("Token invalidated successfully") : StatusCode(500, "Failed to invalidate token");
    }
}