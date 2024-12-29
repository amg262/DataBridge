using Asp.Versioning;
using DataBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataBridge.Controllers;

[Authorize]
[ApiController]
[SwaggerTag]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class OpenAiController : ControllerBase
{
    private readonly OpenAiService _openAiService;

    public OpenAiController(OpenAiService openAiService)
    {
        _openAiService = openAiService;
    }

    [HttpGet("messageScore")]
    public async Task<ActionResult<string>> GetMessageScore(string message)
    {
        var score = await _openAiService.GetMessageScoreAsync(message);
        return Ok(score);
    }
}