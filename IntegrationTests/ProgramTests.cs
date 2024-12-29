using DataBridge.Options;
using DataBridge.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IntegrationTests;

public class ProgramTests
{
    [Fact]
    public void TestServiceRegistrations()
    {
        var services = new ServiceCollection();

        // Mimic the service registrations in Program.cs
        services.Configure<DelivraOptions>(options =>
        {
            /* configure as needed */
        
        });
        services.Configure<JwtOptions>(options =>
        {
            /* configure as needed */
        });

        services.AddScoped<JwtTokenGenerator>();
        services.AddScoped<JwtTokenProvider>();

        var serviceProvider = services.BuildServiceProvider();

        // Assert services are registered
        Assert.NotNull(serviceProvider.GetService<JwtTokenGenerator>());
        Assert.NotNull(serviceProvider.GetService<JwtTokenProvider>());

        // Assert options are configured
        var delivraOptions = serviceProvider.GetService<IOptions<DelivraOptions>>();
        Assert.NotNull(delivraOptions);

        var jwtOptions = serviceProvider.GetService<IOptions<JwtOptions>>();
        Assert.NotNull(jwtOptions);
    }
}