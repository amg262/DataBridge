using Asp.Versioning;
using AutoMapper;
using DataBridge.Data;
using DataBridge.Models.Delivra;
using DataBridge.Models.Delivra.Dto;
using DataBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataBridge.Controllers;

/// <summary>
/// Controller for handling Delivra-related operations.
/// </summary>
[Authorize]
[ApiController]
[SwaggerTag]
[Produces("application/json")]
[Consumes("application/json")]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class DelivraController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly DelivraService _delivraService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelivraController"/> class.
    /// </summary>
    /// <param name="mapper">The AutoMapper instance for object mapping.</param>
    /// <param name="db">The database context.</param>
    /// <param name="delivraService">The Delivra service for interacting with the Delivra API.</param>
    public DelivraController(IMapper mapper, AppDbContext db, DelivraService delivraService)
    {
        _mapper = mapper;
        _db = db;
        _delivraService = delivraService;
    }

    #region Reports

    /// <summary>
    /// Retrieves all reports from the database.
    /// </summary>
    /// <returns>A list of all reports.</returns>
    [HttpGet("Reports")]
    [SwaggerResponse(200, "Reports retrieved successfully", typeof(List<ReportDto>))]
    public async Task<ActionResult<List<ReportDto>>> GetReportsAsync()
    {
        var reports = await _delivraService.GetAsync<Report, ReportDto>();
        return Ok(reports);
    }

    /// <summary>
    /// Updates the reports in the database with new data from the Delivra API.
    /// </summary>
    /// <param name="dateRange">The date range for which to retrieve reports.</param>
    /// <returns>A list of new reports, or a message if no new reports were found.</returns>
    [HttpPut("Reports")]
    [SwaggerResponse(200, "Reports updated successfully", typeof(List<ReportDto>))]
    public async Task<ActionResult<List<ReportDto>>> PutReportsAsync([FromQuery] DateRangeDto? dateRange)
    {
        var newReports = await _delivraService.PutAsync<Report, ReportDto>(
            $"Reports?startDate={dateRange?.StartDate:yyyy-MM-dd}&endDate={dateRange?.EndDate:yyyy-MM-dd}");

        return newReports == null ? Ok("No new reports found.") : Ok(newReports);
    }

    /// <summary>
    /// Deletes all reports from the database.
    /// </summary>
    /// <returns>A message indicating whether reports were deleted or if there were no reports to delete.</returns>
    [HttpDelete("Reports")]
    public async Task<ActionResult> DeleteReportsAsync()
    {
        var deleted = await _delivraService.DeleteAsync<Report>();
        return deleted ? Ok("All records deleted successfully.") : Ok("No records to delete.");
    }

    #endregion

    #region Segments

    /// <summary>
    /// Retrieves all segments from the database.
    /// </summary>
    /// <returns>A list of all segments.</returns>
    [HttpGet("Segments")]
    [SwaggerResponse(200, "Segments retrieved successfully", typeof(List<SegmentDto>))]
    public async Task<ActionResult<List<SegmentDto>>> GetSegmentsAsync()
    {
        var segments = await _delivraService.GetAsync<Segment, SegmentDto>();
        return Ok(segments);
    }

    /// <summary>
    /// Updates the segments in the database with new data from the Delivra API.
    /// </summary>
    /// <returns>A list of new segments, or a message if no new segments were found.</returns>
    [HttpPut("Segments")]
    [SwaggerResponse(200, "Segments updated successfully", typeof(List<SegmentDto>))]
    public async Task<ActionResult<List<SegmentDto>>> PutSegmentsAsync()
    {
        var newSegments =
            await _delivraService.PutAsync<Segment, SegmentDto>("Segments");

        return newSegments == null ? Ok("No new segments found.") : Ok(newSegments);
    }

    /// <summary>
    /// Deletes all segments from the database.
    /// </summary>
    /// <returns>A message indicating whether segments were deleted or if there were no segments to delete.</returns>
    [HttpDelete("Segments")]
    public async Task<ActionResult> DeleteSegmentsAsync()
    {
        var deleted = await _delivraService.DeleteAsync<Segment>();
        return deleted ? Ok("All segments deleted successfully.") : Ok("No segments to delete.");
    }

    #endregion

    #region Clickthroughs

    /// <summary>
    /// Retrieves all clickthroughs from the database.
    /// </summary>
    /// <returns>A list of all clickthroughs.</returns>
    [HttpGet("Clickthroughs")]
    [SwaggerResponse(200, "Clickthroughs retrieved successfully", typeof(List<ClickthroughDto>))]
    public async Task<ActionResult<List<ClickthroughDto>>> GetClickthroughsAsync()
    {
        var clickthroughs = await _delivraService.GetAsync<Clickthrough, ClickthroughDto>();
        return Ok(clickthroughs);
    }

    /// <summary>
    /// Updates the clickthroughs in the database with new data from the Delivra API.
    /// </summary>
    /// <param name="dateRange">The date range for which to retrieve clickthroughs.</param>
    /// <returns>A list of new clickthroughs, or a message if no new clickthroughs were found.</returns>
    [HttpPut("Clickthroughs")]
    [SwaggerResponse(200, "Clickthroughs updated successfully", typeof(List<ClickthroughDto>))]
    public async Task<ActionResult<List<ClickthroughDto>>> PutClickthroughsAsync([FromQuery] DateRangeDto dateRange)
    {
        var newClickthroughs = await _delivraService.PutAsync<Clickthrough, ClickthroughDto>(
            $"Reports/Clickthroughs?startDate={dateRange.StartDate:yyyy-MM-dd}&endDate={dateRange.EndDate:yyyy-MM-dd}");

        return newClickthroughs == null ? Ok("No new clickthroughs found.") : Ok(newClickthroughs);
    }

    /// <summary>
    /// Deletes all clickthroughs from the database.
    /// </summary>
    /// <returns>A message indicating whether clickthroughs were deleted or if there were no clickthroughs to delete.</returns>
    [HttpDelete("Clickthroughs")]
    public async Task<ActionResult> DeleteClickthroughsAsync()
    {
        var deleted = await _delivraService.DeleteAsync<Clickthrough>();
        return deleted ? Ok("All clickthroughs deleted successfully.") : Ok("No clickthroughs to delete.");
    }

    #endregion

    #region Opens

    /// <summary>
    /// Retrieves all report opens from the database.
    /// </summary>
    /// <returns>A list of all report opens.</returns>
    [HttpGet("Opens")]
    [SwaggerResponse(200, "Report Opens retrieved successfully", typeof(List<OpenDto>))]
    public async Task<ActionResult<List<OpenDto>>> GetReportOpensAsync()
    {
        var opens = await _delivraService.GetAsync<Open, OpenDto>();
        return Ok(opens);
    }

    /// <summary>
    /// Updates the report opens in the database with new data from the Delivra API.
    /// </summary>
    /// <param name="dateRange">The date range for which to retrieve report opens.</param>
    /// <returns>A list of new report opens, or a message if no new report opens were found.</returns>
    [HttpPut("Opens")]
    [SwaggerResponse(200, "Report Opens updated successfully", typeof(List<OpenDto>))]
    public async Task<ActionResult<List<OpenDto>>> PutReportOpensAsync([FromQuery] DateRangeDto dateRange)
    {
        var newOpens = await _delivraService.PutAsync<Open, OpenDto>(
            $"Reports/Fullopens?startDate={dateRange.StartDate:yyyy-MM-dd}&endDate={dateRange.EndDate:yyyy-MM-dd}");

        return newOpens == null ? Ok("No new opens found.") : Ok(newOpens);
    }

    // /// <summary>
    // /// Deletes all report opens from the database.
    // /// </summary>
    // /// <returns>A message indicating whether report opens were deleted or if there were no report opens to delete.</returns>
    // [HttpDelete("Opens")]
    // public async Task<ActionResult> DeleteReportOpensAsync()
    // {
    //     var deleted = await _delivraService.DeleteAsync(_db.DelivraOpens, _db);
    //     return deleted ? Ok("All opens deleted successfully.") : Ok("No opens to delete.");
    // }

    #endregion

    #region Sends

    /// <summary>
    /// Retrieves all report sends from the database.
    /// </summary>
    /// <returns>A list of all report sends.</returns>
    [HttpGet("Sends")]
    [SwaggerResponse(200, "Report Sends retrieved successfully", typeof(List<SendDto>))]
    public async Task<ActionResult<List<SendDto>>> GetReportSendsAsync()
    {
        var sends = await _delivraService.GetAsync<Send, SendDto>();
        return Ok(sends);
    }

    /// <summary>
    /// Retrieves new report sends from the Delivra API and adds them to the database.
    /// </summary>
    /// <param name="dateRange">The date range for which to retrieve report sends.</param>
    /// <returns>A list of new report sends, or a message if no new report sends were found.</returns>
    [HttpPost("Sends")]
    [SwaggerResponse(200, "Report Sends retrieved successfully", typeof(List<SendDto>))]
    public async Task<ActionResult<List<SendDto>>> PostReportSendsAsync([FromQuery] DateRangeDto dateRange)
    {
        var sends = await _delivraService.PostAsync<Send, SendDto>(
            $"Reports/Sends?startDate={dateRange.StartDate:yyyy-MM-dd}&endDate={dateRange.EndDate:yyyy-MM-dd}");

        return sends == null ? NotFound("No sends found.") : Ok(sends);
    }

    /// <summary>
    /// Updates the report sends in the database with new data from the Delivra API.
    /// </summary>
    /// <param name="dateRange">The date range for which to retrieve report sends.</param>
    /// <returns>A list of new report sends, or a message if no new report sends were found.</returns>
    [HttpPut("Sends")]
    [SwaggerResponse(200, "Report Sends updated successfully", typeof(List<SendDto>))]
    public async Task<ActionResult<List<SendDto>>> PutReportSendsAsync([FromQuery] DateRangeDto dateRange)
    {
        var newSends = await _delivraService.PutAsync<Send, SendDto>(
            $"Reports/Sends?startDate={dateRange.StartDate:yyyy-MM-dd}&endDate={dateRange.EndDate:yyyy-MM-dd}");

        return newSends == null ? Ok("No new sends found.") : Ok(newSends);
    }

    /// <summary>
    /// Deletes all report sends from the database.
    /// </summary>
    /// <returns>A message indicating whether report sends were deleted or if there were no report sends to delete.</returns>
    [HttpDelete("Sends")]
    public async Task<ActionResult> DeleteReportSendsAsync()
    {
        var deleted = await _delivraService.DeleteAsync<Send>();
        return deleted ? Ok("All sends deleted successfully.") : Ok("No sends to delete.");
    }

    #endregion
}