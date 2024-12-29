using DataBridge.Helpers;
using DataBridge.Options;
using DataBridge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace UnitTests;

/// <summary>
/// Unit tests for <see cref="JwtTokenProvider"/>.
/// </summary>
public class JwtTokenProviderTests
{
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
    private readonly Mock<IOptions<JwtOptions>> _jwtOptionsMock;
    private readonly JwtTokenProvider _jwtTokenProvider;
    private readonly Mock<HttpContext> _httpContextMock;
    private readonly Mock<IRequestCookieCollection> _requestCookiesMock;
    private readonly Mock<IResponseCookies> _responseCookiesMock;
    private readonly Mock<ILogger<JwtTokenProvider>> _loggerMock;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtTokenProviderTests"/> class.
    /// </summary>
    public JwtTokenProviderTests(Mock<ILogger<JwtTokenProvider>> loggerMock)
    {
        _loggerMock = loggerMock;
        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        _jwtOptionsMock = new Mock<IOptions<JwtOptions>>();
        _httpContextMock = new Mock<HttpContext>();
        _requestCookiesMock = new Mock<IRequestCookieCollection>();
        _responseCookiesMock = new Mock<IResponseCookies>();

        _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(_httpContextMock.Object);
        _httpContextMock.Setup(x => x.Request.Cookies).Returns(_requestCookiesMock.Object);
        _httpContextMock.Setup(x => x.Response.Cookies).Returns(_responseCookiesMock.Object);

        _jwtTokenProvider = new JwtTokenProvider(_httpContextAccessorMock.Object, _jwtOptionsMock.Object, _loggerMock.Object);
    }

    /// <summary>
    /// Tests the IssueToken method to ensure it sets the token correctly.
    /// </summary>
    [Fact]
    public void SetToken_SetsToken_ReturnsToken()
    {
        // Arrange
        var token = "test-token";

        // Act
        var result = _jwtTokenProvider.IssueToken(token);

        // Assert
        _responseCookiesMock.Verify(x => x.Append(ProjectHelper.TokenCookie, token), Times.Once);
        Assert.Equal(token, result);
    }

    /// <summary>
    /// Tests the RetrieveToken method to ensure it retrieves the token correctly.
    /// </summary>
    [Fact]
    public void GetToken_TokenExists_ReturnsToken()
    {
        // Arrange
        var token = "test-token";
        _requestCookiesMock.Setup(x => x.TryGetValue(ProjectHelper.TokenCookie, out token)).Returns(true);

        // Act
        var result = _jwtTokenProvider.RetrieveToken();

        // Assert
        Assert.Equal(token, result);
    }

    /// <summary>
    /// Tests the RetrieveToken method to ensure it returns null when token does not exist.
    /// </summary>
    [Fact]
    public void GetToken_TokenDoesNotExist_ReturnsNull()
    {
        // Arrange
        string? token = null;
        _requestCookiesMock.Setup(x => x.TryGetValue(ProjectHelper.TokenCookie, out token)).Returns(false);

        // Act
        var result = _jwtTokenProvider.RetrieveToken();

        // Assert
        Assert.Null(result);
    }

    /// <summary>
    /// Tests the ClearToken method to ensure it clears the token correctly.
    /// </summary>
    [Fact]
    public void ClearToken_ClearsToken()
    {
        // Act
        _jwtTokenProvider.ClearToken();

        // Assert
        _responseCookiesMock.Verify(x => x.Delete(ProjectHelper.TokenCookie), Times.Once);
    }

    /// <summary>
    /// Tests the ValidateToken method to ensure it validates a valid token.
    /// </summary>
    [Fact]
    public void ValidateToken_WithInvalidToken_ReturnsFalse()
    {
        // Arrange
        const string token = "invalid-token";

        // Act
        var result = _jwtTokenProvider.ValidateToken(token);

        // Assert
        Assert.False(result);
    }
}