using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataBridge.Helpers;
using DataBridge.Models;
using DataBridge.Models.Contentserv;
using DataBridge.Options;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace DataBridge.Services;

/// <summary>
/// Manages authentication tokens for ContentServ API integration.
/// This service runs as a background process to ensure valid access tokens are always available.
/// </summary>
/// <remarks>
/// This service implements the following key features:
/// - Automatic token refresh
/// - Thread-safe token management
/// - Periodic token validity checks
/// - Fallback mechanism for token acquisition failures
/// 
/// The service uses a semaphore to ensure thread-safety when multiple threads
/// attempt to access or refresh tokens simultaneously.
/// </remarks>
public class ContentservTokenService : BackgroundService, IHealthCheck
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ContentservTokenService> _logger;
    private readonly ContentservOptions _options;
    private string? _accessToken = string.Empty;
    private string? _refreshToken = string.Empty;
    private DateTime _accessTokenExpiry;
    private DateTime _refreshTokenExpiry;
    private bool _isApiHealthy = true;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentservTokenService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory for creating HTTP clients.</param>
    /// <param name="logger">The logger for logging information and errors.</param>
    /// <param name="options">The options containing API credentials.</param>
    /// <param name="httpClient">The HTTP client for making API requests.</param>
    public ContentservTokenService(IHttpClientFactory httpClientFactory, ILogger<ContentservTokenService> logger,
        IOptions<ContentservOptions> options, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
        _httpClient = httpClientFactory.CreateClient(ProjectHelper.ContentservClient);
        _options = options.Value;
    }

    /// <summary>
    /// Executes the background service logic.
    /// </summary>
    /// <param name="stoppingToken">The cancellation token that can be used to stop the service.</param>
    /// <remarks>
    /// This method runs in a continuous loop, periodically checking and refreshing tokens
    /// until the application is stopped.
    /// </remarks>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ContentservTokenService started");

        while (!stoppingToken.IsCancellationRequested)
        {
            await EnsureValidTokenAsync(stoppingToken);

            // Calculate the time until the token expires 
            var timeUntilExpiry = _accessTokenExpiry - DateTime.UtcNow;
            if (timeUntilExpiry > TimeSpan.Zero)
            {
                _logger.LogDebug("Token valid. Next check scheduled in {TimeUntilExpiry}", timeUntilExpiry);
                await Task.Delay(timeUntilExpiry, stoppingToken);
            }
            else
            {
                _logger.LogWarning("Token expired or close to expiry. Immediate refresh required");
            }
        }

        _logger.LogInformation("ContentservTokenService stopped");
    }

    /// <summary>
    /// Ensures that a valid access token is available.
    /// </summary>
    /// <remarks>
    /// This method checks if the current access token is valid. If not, it attempts to refresh
    /// the token or acquire a new token pair if necessary. This method is thread-safe.
    /// </remarks>
    private async Task EnsureValidTokenAsync(CancellationToken stoppingToken = default)
    {
        try
        {
            await _semaphore.WaitAsync(stoppingToken);
            _logger.LogDebug("Checking token validity");

            if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _accessTokenExpiry)
            {
                if (string.IsNullOrEmpty(_refreshToken))
                {
                    _logger.LogInformation("No tokens available. Acquiring new token pair");
                    await GetNewTokenPairAsync();
                }
                else
                {
                    try
                    {
                        _logger.LogInformation("Access token expired. Attempting refresh");
                        await RefreshTokenAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Token refresh failed. Falling back to new token acquisition");
                        await GetNewTokenPairAsync();
                    }
                }
            }
            else
            {
                _logger.LogDebug("Token is still valid. Expires at: {ExpiryTime}", _accessTokenExpiry);
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <summary>
    /// Acquires a new pair of access and refresh tokens from the ContentServ API.
    /// </summary>
    /// <remarks>
    /// This method is called when there are no existing tokens or when token refresh fails.
    /// It updates the internal token state with the newly acquired tokens.
    /// </remarks>
    private async Task GetNewTokenPairAsync()
    {
        try
        {
            _logger.LogInformation("Acquiring new token pair");

            // var client = _httpClientFactory.CreateClient("ContentServ");
            var request = new HttpRequestMessage(HttpMethod.Get, "pxc/auth/v1/token");

            request.Headers.Authorization = new AuthenticationHeaderValue("CSAuth", $"{_options.ApiKey}:{_options.Secret}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

            // var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(content);

            if (tokenResponse != null)
            {
                _isApiHealthy = true;
                _accessToken = tokenResponse.AccessToken;
                _refreshToken = tokenResponse.RefreshToken;
                _accessTokenExpiry = DateTime.UtcNow.AddMinutes((double)(tokenResponse.RefreshExpiresIn / 60.0 - 2));

                // _accessTokenExpiry = DateTime.UtcNow.AddSeconds(60);

                // _accessTokenExpiry = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);
                _logger.LogInformation("New token pair acquired successfully. Expires at: {ExpiryTime}", _accessTokenExpiry);
            }
            else
            {
                _isApiHealthy = false;
                _logger.LogError("Failed to deserialize token response");
                throw new InvalidOperationException("Invalid token response from server.");
            }
        }
        catch (Exception ex)
        {
            _isApiHealthy = false;
            _logger.LogError(ex, "Failed to acquire new token pair");
            throw;
        }
    }

    /// <summary>
    /// Refreshes the access token using the current refresh token.
    /// </summary>
    /// <remarks>
    /// This method is called when the access token is nearing expiration but a valid refresh token is available.
    /// It updates the internal token state with the refreshed tokens.
    /// </remarks>
    private async Task RefreshTokenAsync()
    {
        // var client = _httpClientFactory.CreateClient("ContentServ");
        _logger.LogInformation("Refreshing token");

        var request = new HttpRequestMessage(HttpMethod.Get, "pxc/auth/v1/refresh");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _refreshToken);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

        if (tokenResponse != null)
        {
            _isApiHealthy = true;
            _accessToken = tokenResponse.AccessToken;
            if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
            {
                _refreshToken = tokenResponse.RefreshToken;
                _logger.LogDebug("Refresh token updated");
            }

            if (!string.IsNullOrEmpty(tokenResponse.IdToken))
            {
                _logger.LogDebug("ID token received: {IdToken}", tokenResponse.IdToken);
            }

            _isApiHealthy = true;
            _accessTokenExpiry = DateTime.UtcNow.AddMinutes((double)(tokenResponse.RefreshExpiresIn / 60.0 - 2));
            _logger.LogInformation("Token refreshed successfully. New expiry: {ExpiryTime}", _accessTokenExpiry);
        }
        else
        {
            _isApiHealthy = false;
            _logger.LogError("Failed to deserialize token response during refresh");
            throw new InvalidOperationException("Invalid token response from server during refresh.");
        }
    }

    /// <summary>
    /// Retrieves the current access and refresh tokens.
    /// </summary>
    /// <returns>A tuple containing the access token and refresh token.</returns>
    /// <remarks>
    /// This method ensures that a valid token pair is available before returning.
    /// It's the primary method for other parts of the application to obtain authentication tokens.
    /// </remarks>
    public async Task<(string AccessToken, string RefreshToken)> GetTokensAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetTokensAsync called");

        await EnsureValidTokenAsync(cancellationToken);
        return (_accessToken ?? throw new InvalidOperationException("Access token is null"),
            _refreshToken ?? throw new InvalidOperationException("Refresh token is null"));
    }

    /// <summary>
    /// Checks the health of the ContentServ API.
    /// </summary>
    /// <param name="context">A context object for the health check.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.
    /// The task result contains a <see cref="HealthCheckResult"/> indicating the health status of the ContentServ API.
    /// </returns>
    /// <remarks>
    /// This method returns a healthy status if the API is accessible and tokens can be acquired or refreshed successfully.
    /// It returns an unhealthy status if there have been issues with token acquisition or refresh.
    /// The method respects the provided cancellation token and will throw an OperationCanceledException if cancellation is requested.
    /// </remarks>
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Immediately honor cancellation request to prevent unnecessary work
        // This is important for responsiveness in health check scenarios
        cancellationToken.ThrowIfCancellationRequested();

        // Perform a quick check to ensure we have a valid token
        // This could potentially be expanded to make a lightweight API call to verify connectivity
        try
        {
            // Attempt to retrieve tokens. This will trigger a refresh or new token acquisition if necessary,
            // effectively testing the core functionality of the ContentservTokenService and Contentserv API.
            // var tokenTask = GetTokensAsync(cancellationToken);
            //
            // // Wait for the token retrieval to complete. This could timeout if the API is unresponsive,
            // // so we pass the cancellationToken to allow for cancellation during the wait
            // tokenTask.Wait(cancellationToken);

            // return Task.FromResult(!string.IsNullOrEmpty(tokenTask.Result.AccessToken) // && _isApiHealthy
            return _isApiHealthy || !string.IsNullOrEmpty(_accessToken)
                ? Task.FromResult(HealthCheckResult.Healthy("ContentServ API is up and token is valid."))
                : Task.FromResult(
                    HealthCheckResult.Unhealthy("ContentServ API is accessible but there are issues with token management."));

            // return Task.FromResult(!string.IsNullOrEmpty(tokenTask.Result.AccessToken) // && _isApiHealthy
            //     ? HealthCheckResult.Healthy("ContentServ API is up and token is valid.")
            //     : HealthCheckResult.Unhealthy("ContentServ API is accessible but there are issues with token management."));
        }
        catch (OperationCanceledException e)
        {
            // If the operation was cancelled, propagate the cancellation
            _logger.LogWarning(e, $"Health check operation was cancelled");
            throw;
        }
        catch (Exception ex)
        {
            _isApiHealthy = false;
            return Task.FromResult(HealthCheckResult.Unhealthy("Failed to verify ContentServ API health.", ex));
        }
    }
}