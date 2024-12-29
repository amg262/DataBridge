using Asp.Versioning;
using DataBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DataBridge.Models.Liveperson;

namespace DataBridge.Controllers;

[Authorize]
[ApiController]
[SwaggerTag]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class LivePersonController : ControllerBase
{
    private readonly LivePersonService _livePersonService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LivePersonController"/> class.
    /// </summary>
    /// <param name="livePersonService">The service used to interact with the LivePerson API</param>
    public LivePersonController(LivePersonService livePersonService)
    {
        _livePersonService = livePersonService;
    }

    /// <summary>
    /// Retrieves the base URI for a specified Liveperson service.
    /// </summary>
    /// <param name="service">The name of the service (default is "leDataReporting").</param>
    /// <returns>The base URI for the specified service.</returns>
    [HttpGet("BaseUri")]
    public async Task<ActionResult<string>> GetBaseUriAsync(string? service = "leDataReporting")
    {
        var baseUri = await _livePersonService.GetBaseUriAsync(service);
        return Ok(baseUri);
    }

    /// <summary>
    /// Retrieves a list of all users from the Liveperson API.
    /// </summary>
    /// <returns>An ActionResult containing the list of users if successful, or an error status code if not.</returns>
    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _livePersonService.GetUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// Retrieves details for a specific user from the Liveperson API.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <returns>An ActionResult containing the user details if successful, or an error status code if not.</returns>
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<UserDetails>> GetUserById(string userId)
    {
        var userDetails = await _livePersonService.GetUserByIdAsync(userId);
        return Ok(userDetails);
    }

    /// <summary>
    /// Retrieves conversations from the Liveperson API for the last 24 hours.
    /// </summary>
    /// <returns>An ActionResult indicating success or failure.</returns>
    [HttpPost("conversations")]
    public async Task<ActionResult> GetConversations(int? batchSize = 500)
    {
        await _livePersonService.PostConversationsAsync(batchSize);
        return Ok("Conversations retrieved and processed successfully");
    }

    [HttpGet("conversations")]
    public async Task<IActionResult> GetConversations([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        var conversations = await _livePersonService.GetConversationsAsync(skip, take);
        return Ok(conversations);
    }

    [HttpGet("conversations/{conversationId}")]
    public async Task<IActionResult> GetConversationDetails(string conversationId)
    {
        var details = await _livePersonService.GetConversationDetailsAsync(conversationId);

        return Ok(details);
    }

    /// <summary>
    /// Retrieves reporting data from the Liveperson API.
    /// </summary>
    /// <returns>An ActionResult containing the reporting data if successful, or an error status code if not.</returns>
    [HttpGet("reporting")]
    public async Task<ActionResult<string>> GetReporting()
    {
        var reportingData = await _livePersonService.GetReportingAsync();
        return Ok(reportingData);
    }

    /// <summary>
    /// Retrieves agent segments from the Liveperson API.
    /// </summary>
    /// <returns>An ActionResult containing the agent segments if successful, or an error status code if not.</returns>
    [HttpGet("agent-segments")]
    public async Task<ActionResult<string>> GetAgentSegments()
    {
        var agentSegments = await _livePersonService.GetAgentSegmentsAsync();
        return Ok(agentSegments);
    }
}