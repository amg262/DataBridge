using Microsoft.Extensions.Options;

namespace DataBridge.Options;

/// <summary>
/// Represents configuration options for backend services.
/// </summary>
public record BackendOptions
{
    /// <summary>
    /// Gets or initializes the base URL for the backend services.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// Gets or initializes the API URL for the backend services.
    /// </summary>
    public string? ApiUrl { get; init; }

    /// <summary>
    /// Gets or initializes the Hangfire dashboard URL.
    /// </summary>
    public string? HangfireUrl { get; init; }

    /// <summary>
    /// Gets or initializes the SignalR URL for real-time notifications.
    /// </summary>
    public string? SignalRUrl { get; init; }

    /// <summary>
    /// Gets or initializes the health check URL for monitoring service health.
    /// </summary>
    public string? HealthCheckUrl { get; init; }

    /// <summary>
    /// Gets or initializes the authentication token for accessing backend services.
    /// </summary>
    public string? Token { get; init; }
}