using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataBridge.Helpers;

/// <summary>
/// Global exception handler for handling exceptions across the entire application.
/// Implements <see cref="IExceptionHandler"/> to provide a unified way of handling exceptions.
/// </summary>
internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    /// <summary>
    /// Asynchronously handles exceptions and generates a structured error response.
    /// </summary>
    /// <param name="httpContext">The context of the current HTTP request.</param>
    /// <param name="exception">The exception that occurred.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the exception was handled.</returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        int statusCode;
        string statusDescription;

        switch (exception)
        {
            case HttpRequestException httpRequestException:
                statusCode = (int)(httpRequestException.StatusCode ?? HttpStatusCode.InternalServerError);
                statusDescription = $"HTTP Request Error: {httpRequestException.Message}";
                break;
            case JsonException jsonException:
                statusCode = StatusCodes.Status400BadRequest;
                statusDescription = $"Invalid JSON: {jsonException.Message}";
                break;
            case ArgumentException argumentException:
                statusCode = StatusCodes.Status400BadRequest;
                statusDescription = $"Invalid Argument Param: {argumentException.ParamName} Message: {argumentException.Message}";
                break;
            case InvalidOperationException invalidOpException:
                statusCode = StatusCodes.Status400BadRequest;
                statusDescription = $"Invalid Operation: {invalidOpException.Message}";
                break;
            case UnauthorizedAccessException unauthorizedException:
                statusCode = StatusCodes.Status401Unauthorized;
                statusDescription = $"Unauthorized Access: {unauthorizedException.Message}";
                break;
            case KeyNotFoundException keyNotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                statusDescription = $"Resource Not Found: {keyNotFoundException.Message}";
                break;
            case TimeoutException timeoutException:
                statusCode = StatusCodes.Status408RequestTimeout;
                statusDescription = $"Request Timeout: {timeoutException.Message}";
                break;
            case NotImplementedException notImplementedException:
                statusCode = StatusCodes.Status501NotImplemented;
                statusDescription = $"Not Implemented: {notImplementedException.Message}";
                break;
            case OperationCanceledException operationCanceledException:
                statusCode = StatusCodes.Status499ClientClosedRequest;
                statusDescription = $"Operation Canceled: {operationCanceledException.Message}";
                break;
            case SqlException sqlException:
                statusCode = StatusCodes.Status500InternalServerError;
                statusDescription = $"SQL Error {sqlException.Number}: {sqlException.Message}";
                logger.LogError(sqlException, "SQL Exception: {Message}, Number: {Number}", sqlException.Message,
                    sqlException.Number);
                break;
            case System.Data.Common.DbException dbException:
                statusCode = StatusCodes.Status500InternalServerError;
                statusDescription = $"Database Error: {dbException.Message}";
                logger.LogError(dbException, "Database Exception: {Message}", dbException.Message);
                break;
            case FormatException formatException:
                statusCode = StatusCodes.Status400BadRequest;
                statusDescription = $"Invalid Format: {formatException.Message}";
                break;
            case OverflowException overflowException:
                statusCode = StatusCodes.Status400BadRequest;
                statusDescription = $"Arithmetic Overflow: {overflowException.Message}";
                break;
            case IOException ioException:
                statusCode = StatusCodes.Status500InternalServerError;
                statusDescription = $"I/O Error: {ioException.Message}";
                logger.LogError(ioException, "I/O Exception: {Message}", ioException.Message);
                break;
            case System.Net.Sockets.SocketException socketException:
                statusCode = StatusCodes.Status503ServiceUnavailable;
                statusDescription = $"Network Error {socketException.ErrorCode}: {socketException.Message}";
                logger.LogError(socketException, "Socket Exception: {Message}, ErrorCode: {ErrorCode}", socketException.Message,
                    socketException.ErrorCode);
                break;
            case System.Security.SecurityException securityException:
                statusCode = StatusCodes.Status403Forbidden;
                statusDescription = $"Security Violation: {securityException.Message}";
                break;
            default:
                statusCode = httpContext.Response.StatusCode;
                statusDescription = GetStatusDescription(statusCode);
                break;
        }

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = statusDescription,
            Detail = exception?.InnerException?.Message ?? exception?.Message,
            Instance = httpContext.Request.Path,
            Type = exception?.GetType().Name,
            Extensions = new Dictionary<string, object>
            {
                { "traceId", Activity.Current?.Id ?? httpContext.TraceIdentifier },
                { "stackTrace", exception?.StackTrace }
            }
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static string GetStatusDescription(int statusCode) => statusCode switch
    {
        StatusCodes.Status100Continue => "Continue",
        StatusCodes.Status101SwitchingProtocols => "Switching Protocols",
        StatusCodes.Status102Processing => "Processing",
        StatusCodes.Status200OK => "OK",
        StatusCodes.Status201Created => "Created",
        StatusCodes.Status202Accepted => "Accepted",
        StatusCodes.Status204NoContent => "No Content",
        StatusCodes.Status205ResetContent => "Reset Content",
        StatusCodes.Status206PartialContent => "Partial Content",
        StatusCodes.Status207MultiStatus => "Multi-Status",
        StatusCodes.Status208AlreadyReported => "Already Reported",
        StatusCodes.Status226IMUsed => "IM Used",
        StatusCodes.Status300MultipleChoices => "Multiple Choices",
        StatusCodes.Status301MovedPermanently => "Moved Permanently",
        StatusCodes.Status302Found => "Found",
        StatusCodes.Status303SeeOther => "See Other",
        StatusCodes.Status304NotModified => "Not Modified",
        StatusCodes.Status305UseProxy => "Use Proxy",
        StatusCodes.Status306SwitchProxy => "Switch Proxy",
        StatusCodes.Status307TemporaryRedirect => "Temporary Redirect",
        StatusCodes.Status308PermanentRedirect => "Permanent Redirect",
        StatusCodes.Status400BadRequest => "Bad Request",
        StatusCodes.Status401Unauthorized => "Unauthorized",
        StatusCodes.Status402PaymentRequired => "Payment Required",
        StatusCodes.Status403Forbidden => "Forbidden",
        StatusCodes.Status404NotFound => "Not Found",
        StatusCodes.Status405MethodNotAllowed => "Method Not Allowed",
        StatusCodes.Status406NotAcceptable => "Not Acceptable",
        StatusCodes.Status407ProxyAuthenticationRequired => "Proxy Authentication Required",
        StatusCodes.Status408RequestTimeout => "Request Timeout",
        StatusCodes.Status409Conflict => "Conflict",
        StatusCodes.Status410Gone => "Gone",
        StatusCodes.Status411LengthRequired => "Length Required",
        StatusCodes.Status412PreconditionFailed => "Precondition Failed",
        StatusCodes.Status413PayloadTooLarge => "Payload Too Large",
        StatusCodes.Status415UnsupportedMediaType => "Unsupported Media Type",
        StatusCodes.Status416RangeNotSatisfiable => "Range Not Satisfiable",
        StatusCodes.Status417ExpectationFailed => "Expectation Failed",
        StatusCodes.Status418ImATeapot => "I'm a teapot",
        StatusCodes.Status421MisdirectedRequest => "Misdirected Request",
        StatusCodes.Status422UnprocessableEntity => "Unprocessable Entity",
        StatusCodes.Status423Locked => "Locked",
        StatusCodes.Status424FailedDependency => "Failed Dependency",
        StatusCodes.Status426UpgradeRequired => "Upgrade Required",
        StatusCodes.Status428PreconditionRequired => "Precondition Required",
        StatusCodes.Status429TooManyRequests => "Too Many Requests",
        StatusCodes.Status431RequestHeaderFieldsTooLarge => "Request Header Fields Too Large",
        StatusCodes.Status451UnavailableForLegalReasons => "Unavailable For Legal Reasons",
        StatusCodes.Status499ClientClosedRequest => "Client Closed Request",
        StatusCodes.Status500InternalServerError => "Internal Server Error",
        StatusCodes.Status501NotImplemented => "Not Implemented",
        StatusCodes.Status502BadGateway => "Bad Gateway",
        StatusCodes.Status503ServiceUnavailable => "Service Unavailable",
        StatusCodes.Status504GatewayTimeout => "Gateway Timeout",
        StatusCodes.Status506VariantAlsoNegotiates => "Variant Also Negotiates",
        StatusCodes.Status507InsufficientStorage => "Insufficient Storage",
        StatusCodes.Status508LoopDetected => "Loop Detected",
        StatusCodes.Status510NotExtended => "Not Extended",
        StatusCodes.Status511NetworkAuthenticationRequired => "Network Authentication Required",
        _ => "Unknown Status Code"
    };
}