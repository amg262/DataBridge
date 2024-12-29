using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace DataBridge.Helpers;

/// <summary>
/// Provides helper methods for working with API data and JSON values.
/// </summary>
public static class ProjectHelper
{
    public const string DelivraClient = "DelivraClient";
    public const string AbstractClient = "AbstractClient";
    public const string BackgroundJobClient = "BackgroundJobClient";
    public const string ContentservClient = "ContentservClient";
    public const string LivepersonClient = "LivepersonClient";

    public const string TokenCookie = "DataBridgeToken";
    public const string CorsPolicy = "CorsPolicy";


    // This token will next expire
    public const string Token =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIzMGQ2ZmJiNi04ZWQ1LTRlMGItOGNjNS1mYTNkZDZmZmRiOTUiLCJpYXQiOjE3MjEyNjIyMjgsImlwIjoiMTI3LjAuMC4xIiwibmJmIjoxNzIxMjYyMjI4LCJleHAiOjI1MzQwMjMwMDgwMCwiaXNzIjoiZWxsc3dvcnRoIiwiYXVkIjoibWFya2V0aW5nd2VidGVhbSJ9.rhhreyb8RebO6VHhz1PS9NtKEyojvR7QYTlDUQT_548";

    public static readonly string[] Tags = ["Ready"];


    public static string GenerateAuthorizationHeaderValue2(IConfiguration configuration, string requestUri, string httpMethod)
    {
        var appKey = configuration["LivePersonOptions:AppKey"];
        var secret = configuration["LivePersonOptions:Secret"];
        var accessToken = configuration["LivePersonOptions:AccessToken"];
        var accessTokenSecret = configuration["LivePersonOptions:AccessTokenSecret"];

        var nonce = Guid.NewGuid().ToString("N");
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        var signatureBaseString = $"{httpMethod.ToUpper()}&{Uri.EscapeDataString(requestUri)}&" +
                                  Uri.EscapeDataString(
                                      $"oauth_consumer_key={appKey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_token={accessToken}&oauth_version=1.0");

        var signingKey = $"{Uri.EscapeDataString(secret)}&{Uri.EscapeDataString(accessTokenSecret)}";
        var signature =
            Convert.ToBase64String(
                new HMACSHA1(Encoding.ASCII.GetBytes(signingKey)).ComputeHash(Encoding.ASCII.GetBytes(signatureBaseString)));

        return
            $"OAuth oauth_consumer_key=\"{Uri.EscapeDataString(appKey)}\", oauth_nonce=\"{Uri.EscapeDataString(nonce)}\", oauth_signature=\"{Uri.EscapeDataString(signature)}\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"{timestamp}\", oauth_token=\"{Uri.EscapeDataString(accessToken)}\", oauth_version=\"1.0\"";
    }


    /// <summary>
    /// Converts a JsonElement object to an appropriate .NET object type.
    /// </summary>
    /// <param name="obj">The object to convert, typically a JsonElement.</param>
    /// <returns>
    /// The converted object as a .NET type. If the conversion fails, returns the exception message.
    /// Possible return types are string, float, bool, or null.
    /// </returns>
    /// <remarks>
    /// This method attempts to determine the type of the JSON element and convert it to a corresponding .NET type.
    /// It handles various JSON value kinds such as Number, String, True, False, Null, Undefined, Object, and Array.
    /// If the conversion fails, it catches the exception and returns the exception message.
    /// </remarks>
    public static object? GetObjectValue(object? obj)
    {
        try
        {
            switch (obj)
            {
                case null:
                    return "NULL";
                case JsonElement jsonElement:
                {
                    var typeOfObject = jsonElement.ValueKind;
                    var rawText = jsonElement.GetRawText(); // Retrieves the raw JSON text for the element.

                    return typeOfObject switch
                    {
                        JsonValueKind.Number => float.Parse(rawText, CultureInfo.InvariantCulture),
                        JsonValueKind.String => obj.ToString(),
                        JsonValueKind.True => true,
                        JsonValueKind.False => false,
                        JsonValueKind.Null => null,
                        JsonValueKind.Undefined => null,
                        JsonValueKind.Object => rawText,
                        JsonValueKind.Array => rawText, 
                        _ => rawText 
                    };
                }
                default:
                    throw new ArgumentException("Expected a JsonElement object", nameof(obj));
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    /// <summary>
    /// Generates a secure API key as a base64 encoded string.
    /// </summary>
    /// <param name="keySize">Size of the API key in bytes. A size of 64 bytes (512 bits) is used by default.
    /// It is recommended to use a size of at least 32 bytes (256 bits) for adequate security.</param>
    /// <returns>A base64 encoded string that represents the generated secure API key.</returns>
    /// <remarks>
    /// This method uses the <see cref="RandomNumberGenerator"/> class to fill an array of bytes
    /// with a cryptographically strong random sequence of values, which is then encoded to a base64 string.
    /// This method is static and thread-safe under all platforms.
    /// </remarks>
    public static string GenerateSecureApiKey(int keySize = 64)
    {
        // using var rng = new RNGCryptoServiceProvider();
        var keyBytes = new byte[keySize];
        RandomNumberGenerator.Fill(keyBytes);
        // rng.GetBytes(keyBytes);
        return Convert.ToBase64String(keyBytes);
    }
}