using DataBridge.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DataBridge.Services;

/// <summary>
/// Implements the IEmailSender interface, using SendGrid to send emails.
/// </summary>
/// <param name="emailOptions">Instance of EmailOptions containing the SendGrid API key</param>
public class EmailService(IOptions<EmailOptions> emailOptions)
{
    /// <summary>
    /// The SendGrid API key used to send emails.
    /// </summary>
    // private string? SendGridSecret { get; } = config.GetValue<string>("SendGrid:SecretKey");
    private readonly EmailOptions _emailOptions = emailOptions.Value;

    /// <summary>
    /// Send an email using SendGrid
    /// </summary>
    /// <param name="email"></param>
    /// <param name="subject"></param>
    /// <param name="htmlMessage"></param>
    /// <returns>A task</returns>
    public async Task<Response> SendEmail(string email, string subject, string htmlMessage)
    {
        var client = new SendGridClient(_emailOptions.SecretKey);
        var from = new EmailAddress(_emailOptions.FromEmail, _emailOptions.FromName);
        var to = new EmailAddress(email);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
        return await client.SendEmailAsync(msg);
    }

    /// <summary>
    /// Send an email with attachments using SendGrid
    /// </summary>
    /// <param name="email">Recipient's email address</param>
    /// <param name="subject">Email subject</param>
    /// <param name="htmlMessage">Email content in HTML format</param>
    /// <param name="attachments">List of file attachments</param>
    /// <returns>A task representing the asynchronous operation</returns>
    public Task SendEmailAttachment(string email, string subject, string htmlMessage,
        List<AttachmentInfo>? attachments)
    {
        var client = new SendGridClient(_emailOptions.SecretKey);
        var from = new EmailAddress(_emailOptions.FromEmail, _emailOptions.FromName);
        var to = new EmailAddress(email);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

        if (attachments == null || attachments.Count == 0) return client.SendEmailAsync(msg);

        foreach (var attachment in attachments)
        {
            using var stream = new MemoryStream(attachment.Content);
            msg.AddAttachmentAsync(attachment.Filename, stream);
        }

        return client.SendEmailAsync(msg);
    }
}

/// <summary>
/// Represents information about an email attachment.
/// </summary>
public class AttachmentInfo
{
    /// <summary>
    /// Gets or sets the filename of the attachment.
    /// </summary>
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the content of the attachment as a byte array.
    /// </summary>
    public byte[] Content { get; set; } = [];

    /// <summary>
    /// Gets or sets the MIME type of the attachment.
    /// </summary>
    public string MimeType { get; set; } = "application/octet-stream";
}