using DataBridge.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IntegrationTests;

public class ConfigurationTests
{
    [Fact]
    public void TestJwtOptionsConfiguration()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory
                .GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .Build();

        var inMemorySettings = new Dictionary<string, string>
        {
            { "JwtOptions:Secret", config.GetValue<string>("JwtOptions:Secret") },
            { "JwtOptions:Issuer", config.GetValue<string>("JwtOptions:Issuer") },
            { "JwtOptions:Audience", config.GetValue<string>("JwtOptions:Audience") },
            { "JwtOptions:ExpirationInDays", config.GetValue<string>("JwtOptions:ExpirationInDays") },
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var services = new ServiceCollection();
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        var serviceProvider = services.BuildServiceProvider();

        var options = serviceProvider.GetService<IOptions<JwtOptions>>();
        Assert.NotNull(options);
        Assert.Equal(config.GetValue<string>("JwtOptions:Secret"), options.Value.Secret);
        Assert.Equal(config.GetValue<string>("JwtOptions:Issuer"), options.Value.Issuer);
        Assert.Equal(config.GetValue<string>("JwtOptions:Audience"), options.Value.Audience);
        Assert.Equal(config.GetValue<int>("JwtOptions:ExpirationInDays"), options.Value.ExpirationInDays);
    }
}