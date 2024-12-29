// using System.Globalization;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using DataBridge.Options;
// using DataBridge.Services;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;
// using Moq;
// using Xunit;
//
// namespace UnitTests
// {
//     /// <summary>
//     /// Unit tests for <see cref="JwtTokenGenerator"/>.
//     /// </summary>
//     public class JwtTokenGeneratorTests
//     {
//         private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
//         private readonly Mock<IOptions<JwtOptions>> _optionsMock;
//         private readonly JwtTokenGenerator _jwtTokenGenerator;
//         private readonly Mock<HttpContext> _httpContextMock;
//         private readonly Mock<ConnectionInfo> _connectionInfoMock;
//         private readonly Mock<IConfiguration> _configurationMock;
//         private readonly IConfigurationRoot _configuration;
//
//         /// <summary>
//         /// Initializes a new instance of the <see cref="JwtTokenGeneratorTests"/> class.
//         /// </summary>
//         public JwtTokenGeneratorTests()
//         {
//             _configurationMock = new Mock<IConfiguration>();
//             _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
//             _optionsMock = new Mock<IOptions<JwtOptions>>();
//             _httpContextMock = new Mock<HttpContext>();
//             _connectionInfoMock = new Mock<ConnectionInfo>();
//
//             _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(_httpContextMock.Object);
//             _httpContextMock.Setup(x => x.Connection).Returns(_connectionInfoMock.Object);
//
//             // Setup IConfiguration mock to return test values for JwtOptions
//             // _configurationMock.Setup(c => c["JwtOptions:Secret"]).Returns("YourTestSecret");
//             // _configurationMock.Setup(c => c["JwtOptions:Issuer"]).Returns("TestIssuer");
//             // _configurationMock.Setup(c => c["JwtOptions:Audience"]).Returns("TestAudience");
//             // _configurationMock.Setup(c => c["JwtOptions:ExpirationInDays"]).Returns("1"); // Example value as string
//
//             _configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory
//                     .GetCurrentDirectory()) // Ensure this points to the correct path where appSettings.json is located
//                 .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
//                 .Build();
//             // Initialize JwtTokenGenerator with the mocked IConfiguration
//             var jwtOptions = new JwtOptions
//             {
//                 Secret = _configurationMock.Object["JwtOptions:Secret"],
//                 Issuer = _configurationMock.Object["JwtOptions:Issuer"],
//                 Audience = _configurationMock.Object["JwtOptions:Audience"],
//                 ExpirationInDays = int.TryParse(_configurationMock.Object["JwtOptions:ExpirationInDays"],
//                     out var expirationInDays)
//                     ? expirationInDays
//                     : 30
//             };
//
//             // var jwtOptions = new JwtOptions
//             // {
//             //     Secret = _configuration["JwtOptions:Secret"],
//             //     Issuer = _configuration["JwtOptions:Issuer"],
//             //     Audience = _configuration["JwtOptions:Audience"],
//             //     ExpirationInDays = int.TryParse(_configuration["JwtOptions:ExpirationInDays"], out var expirationInDays)
//             //         ? expirationInDays
//             //         : 30
//             // };
//             _optionsMock.Setup(x => x.Value).Returns(jwtOptions);
//
//             _jwtTokenGenerator = new JwtTokenGenerator(_optionsMock.Object, _httpContextAccessorMock.Object);
//         }
//
//         /// <summary>
//         /// Tests the GenerateToken method to ensure it generates a valid JWT token.
//         /// </summary>
//         [Fact]
//         public void GenerateToken_ValidInputs_ReturnsToken()
//         {
//             // Arrange
//             const string ip = "127.0.0.1";
//             _connectionInfoMock.Setup(x => x.RemoteIpAddress).Returns(System.Net.IPAddress.Parse(ip));
//
//             // Act
//             var token = _jwtTokenGenerator.GenerateToken();
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             Assert.True(tokenHandler.CanReadToken(token));
//
//             var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
//             Assert.NotNull(securityToken);
//             Assert.Contains(securityToken.Claims, c => c.Type == "ip" && c.Value == ip);
//         }
//
//         /// <summary>
//         /// Tests the GenerateToken method to ensure it sets the correct issuer, audience, and expiration.
//         /// </summary>
//         [Fact]
//         public void GenerateToken_SetsCorrectIssuerAudienceExpiration()
//         {
//             // Arrange
//             const string ip = "127.0.0.1";
//             _connectionInfoMock.Setup(x => x.RemoteIpAddress).Returns(System.Net.IPAddress.Parse(ip));
//
//             // Act
//             var token = _jwtTokenGenerator.GenerateToken();
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
//             Assert.NotNull(securityToken);
//             Assert.Equal(_optionsMock.Object.Value.Issuer, securityToken.Issuer);
//             Assert.Equal(_optionsMock.Object.Value.Audience, securityToken.Audiences.First());
//             Assert.True(securityToken.ValidTo <= DateTime.UtcNow.AddDays(_optionsMock.Object.Value.ExpirationInDays));
//         }
//
//         /// <summary>
//         /// Tests the GenerateToken method to ensure it includes the IP address claim.
//         /// </summary>
//         [Fact]
//         public void GenerateToken_IncludesIpAddressClaim()
//         {
//             // Arrange
//             const string ip = "127.0.0.1";
//             _connectionInfoMock.Setup(x => x.RemoteIpAddress).Returns(System.Net.IPAddress.Parse(ip));
//
//             // Act
//             var token = _jwtTokenGenerator.GenerateToken();
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
//             Assert.NotNull(securityToken);
//             Assert.Contains(securityToken.Claims, c => c.Type == "ip" && c.Value == ip);
//         }
//
//         /// <summary>
//         /// Tests the GenerateToken method to ensure it uses a default IP address if not available.
//         /// </summary>
//         [Fact]
//         public void GenerateToken_NoIpAddress_UsesDefaultIp()
//         {
//             // Arrange
//             string? ip = null;
//             _connectionInfoMock.Setup(x => x.RemoteIpAddress).Returns((System.Net.IPAddress?)null);
//
//             // Act
//             var token = _jwtTokenGenerator.GenerateToken();
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
//             Assert.NotNull(securityToken);
//             Assert.Contains(securityToken.Claims, c => c.Type == "ip" && c.Value == "Unknown");
//         }
//     }
// }