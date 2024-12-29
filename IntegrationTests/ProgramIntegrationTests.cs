using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

public class ProgramIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProgramIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/healthz");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json", response.Content.Headers.ContentType.ToString());
    }

    [Fact]
    public async Task SwaggerEndpoint_ReturnsSwaggerUI()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/swagger");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Swagger UI", content);
    }
}