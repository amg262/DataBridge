using ElevenLabs;
using ElevenLabs.Voices;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DataBridge.Services;

/// <summary>
/// Service for interacting with the ElevenLabs API to perform text-to-speech operations.
/// </summary>
public class ElevenLabsService : IHealthCheck
{
    private readonly ElevenLabsClient _client;
    private readonly IWebHostEnvironment _hostingEnvironment;

    /// <summary>
    /// Initializes a new instance of the ElevenLabsService class.
    /// </summary>
    /// <param name="client">The ElevenLabsClient used for API interactions.</param>
    /// <param name="hostingEnvironment">The web hosting environment, used for file operations.</param>
    public ElevenLabsService(ElevenLabsClient client, IWebHostEnvironment hostingEnvironment)
    {
        _client = client;
        _hostingEnvironment = hostingEnvironment;
    }

    /// <summary>
    /// Converts text to speech and streams the result to a file.
    /// </summary>
    /// <returns>A VoiceClip object containing the generated audio.</returns>
    public async Task<VoiceClip> StreamTextToSpeech()
    {
        const string text = "The quick brown fox jumps over the lazy dog.";
        var voice = (await _client.VoicesEndpoint.GetAllVoicesAsync()).FirstOrDefault();

        var basePath = $"{_hostingEnvironment.WebRootPath}/voices/";
        var fileName = Guid.NewGuid() + ".mp3";

        if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

        await using var outputFileStream = File.OpenWrite(basePath + fileName);
        var voiceClip = await _client.TextToSpeechEndpoint.TextToSpeechAsync(text, voice,
            partialClipCallback: async (partialClip) =>
            {
                // Write the incoming data to the output file stream.
                // Alternatively you can play this clip data directly.
                await outputFileStream.WriteAsync(partialClip.ClipData);
            });
        return voiceClip;
    }

    /// <summary>
    /// Converts text to speech and returns the result as a byte array.
    /// </summary>
    /// <param name="text">The text to convert to speech. If null, a default text is used.</param>
    /// <returns>A byte array containing the generated audio data.</returns>
    public async Task<byte[]> MemoryStreamTextToSpeech(string? text)
    {
        text ??= "The quick brown fox jumps over the lazy dog.";
        var voice = (await _client.VoicesEndpoint.GetAllVoicesAsync()).FirstOrDefault();

        using var memoryStream = new MemoryStream();
        await _client.TextToSpeechEndpoint.TextToSpeechAsync(text, voice,
            partialClipCallback: async (partialClip) => { await memoryStream.WriteAsync(partialClip.ClipData); });

        // Returning the byte array to be used as needed
        return memoryStream.ToArray();
    }

    /// <summary>
    /// Converts text to speech and saves the result as an MP3 file.
    /// </summary>
    public async void ConvertTextToSpeech()
    {
        const string text = "The quick brown fox jumps over the lazy dog.";
        var voice = (await _client.VoicesEndpoint.GetAllVoicesAsync()).FirstOrDefault();
        var defaultVoiceSettings = await _client.VoicesEndpoint.GetDefaultVoiceSettingsAsync();
        var voiceClip = await _client.TextToSpeechEndpoint.TextToSpeechAsync(text, voice, defaultVoiceSettings);
        await File.WriteAllBytesAsync($"{voiceClip.Id}.mp3", voiceClip.ClipData.ToArray());
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var user = await _client.UserEndpoint.GetUserInfoAsync(cancellationToken);

        return user != null
            ? HealthCheckResult.Healthy("ElevenLabs API is healthy.")
            : HealthCheckResult.Unhealthy("ElevenLabs API is unhealthy.");
    }
}