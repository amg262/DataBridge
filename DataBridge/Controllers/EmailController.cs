using Asp.Versioning;
using DataBridge.Helpers;
using DataBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataBridge.Controllers;

/// <summary>
/// Controller for handling email-related operations.
/// This controller provides endpoints for sending emails with and without attachments.
/// </summary>
[Authorize]
[ApiController]
[SwaggerTag]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    /// <summary>
    /// Initializes a new instance of the EmailController.
    /// </summary>
    /// <param name="emailService">The email sender service to be used for sending emails.</param>
    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// Sends an email without attachments.
    /// </summary>
    /// <param name="email">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="htmlMessage">The HTML content of the email body.</param>
    /// <returns>An IActionResult indicating the success of the operation.</returns>
    [HttpPost("send")]
    public async Task<IActionResult> SendEmailAsync(string email, string subject, string htmlMessage)
    {
        await _emailService.SendEmail(email, subject, htmlMessage);
        return Ok();
    }

    /// <summary>
    /// Sends an email with attachments.
    /// </summary>
    /// <param name="email">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="htmlMessage">The HTML content of the email body.</param>
    /// <param name="attachments">A list of files to be attached to the email.</param>
    /// <returns>An IActionResult indicating the success of the operation.</returns>
    [HttpPost("send-with-attachments")]
    public async Task<IActionResult> SendEmailWithAttachmentsAsync(string email, string subject, string htmlMessage,
        List<IFormFile> attachments)
    {
        var attachmentInfos = new List<AttachmentInfo>();

        foreach (var file in attachments)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            attachmentInfos.Add(new AttachmentInfo
            {
                Filename = file.FileName,
                Content = memoryStream.ToArray(),
                MimeType = file.ContentType
            });
        }

        await _emailService.SendEmailAttachment(email, subject, htmlMessage, attachmentInfos);
        return Ok();
    }
}