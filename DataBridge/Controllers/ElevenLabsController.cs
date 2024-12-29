using Asp.Versioning;
using DataBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataBridge.Controllers;

/// <summary>
/// Controller for handling ElevenLabs-related operations.
/// This controller provides endpoints for text-to-speech conversion and streaming.
/// </summary>
[Authorize]
[ApiController]
[SwaggerTag]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class ElevenLabsController : ControllerBase
{
    private readonly ElevenLabsService _elevenLabsService;

    /// <summary>
    /// Initializes a new instance of the ElevenLabsController.
    /// </summary>
    /// <param name="elevenLabsService">The ElevenLabs service to be used for text-to-speech operations.</param>
    public ElevenLabsController(ElevenLabsService elevenLabsService)
    {
        _elevenLabsService = elevenLabsService;
    }

    /// <summary>
    /// Streams text-to-speech conversion.
    /// </summary>
    /// <returns>A list of available voices or stream of converted speech.</returns>
    [HttpGet("StreamTextToSpeech")]
    public async Task<IActionResult> StreamTextToSpeech()
    {
        var voices = await _elevenLabsService.StreamTextToSpeech();
        return Ok(voices);
    }

    /// <summary>
    /// Converts given text to speech and returns the audio data.
    /// </summary>
    /// <param name="text">The text to be converted to speech.</param>
    /// <returns>An audio file containing the converted speech.</returns>
    [HttpGet("text-to-speech")]
    public async Task<IActionResult> GetTextToSpeech(string? text)
    {
        var audioData = await _elevenLabsService.MemoryStreamTextToSpeech(text);
        return File(audioData, "audio/mpeg");
    }

    /// <summary>
    /// Converts text to speech.
    /// This method doesn't return any data and its purpose is not clear from the implementation.
    /// </summary>
    [HttpGet("ConvertTextToSpeech")]
    public void ConvertTextToSpeech()
    {
        _elevenLabsService.ConvertTextToSpeech();
    }
}