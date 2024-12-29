using System.ComponentModel;
using System.Net.Mime;
using System.Text.Json;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Polly;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DataBridge.Helpers;

/// <summary>
/// Provides extension methods to enhance the application with Swagger and health checks.
/// </summary>
public static class AppExtensions
{
    private static readonly string[] Tags = ["Ready"];


    /// <summary>
    /// Adds Swagger generator and metadata configurations to the services collection.
    /// This method sets up the Swagger UI for the API, including its security requirements for API Key authentication.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configuration">IConfiguration with configurations needed.</param>
    /// <returns>The IServiceCollection for chaining.</returns>
    public static IServiceCollection AddSwaggerAndHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks();
        services.AddEndpointsApiExplorer();
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("DefaultConnection") ?? string.Empty, name: "SQL Server",
                timeout: TimeSpan.FromSeconds(3),
                tags: Tags);
        // .AddNpgSql(configuration?.GetConnectionString("PostgresConnection"), name: "postgres",
        //     timeout: TimeSpan.FromSeconds(3),
        //     tags: Tags);
        // .AddSqlServer(configuration.GetConnectionString("PostgresConnection"), name: "postgres",
        //     timeout: TimeSpan.FromSeconds(3),
        //     tags: Tags);


        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DataBridge API",
                Version = "v1",
                Description =
                    """
                    DataBridge is a .NET-based integration platform designed to connect and synchronize data across various 
                    business systems into one unified place. The primary goal of DataBridge is to automate data extraction from systems 
                    such as LivePerson, Ignite, Dynamics365, Delivra, ContentServ, p21, and others to output reports. All endpoints 
                    The security JWT token issued should be included in the `Bearer` header.
                    """,
                TermsOfService = new Uri("https://ellsworth.com"),
                License = new OpenApiLicense { Name = "UNLICENSED", Url = new Uri("https://ellsworth.com") },
                Contact = new OpenApiContact { Name = "Andrew", Email = "agunn@ellsworth.com" }
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer mytoken\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            options.SchemaFilter<DescriptionSchemaFilter>();
        });
        return services;
    }

    /// <summary>
    /// Adds default OpenAPI metadata to health check endpoints.
    /// </summary>
    /// <param name="builder">The IEndpointConventionBuilder to configure.</param>
    /// <param name="description">The description of the health check endpoint.</param>
    /// <returns>The configured IEndpointConventionBuilder.</returns>
    private static void AddOpenApiHealthCheckDefaults(this IEndpointConventionBuilder builder,
        string? description)
    {
        builder.WithMetadata(new OpenApiOperation
        {
            Responses = new OpenApiResponses
            {
                { "200", new OpenApiResponse { Description = "Healthy" } },
                { "503", new OpenApiResponse { Description = "Unhealthy" } }
            },
            Description = description
        });
    }

    /// <summary>
    /// Maps health check endpoints and configures them with OpenAPI metadata and responses.
    /// </summary>
    /// <param name="endpoints">The IEndpointRouteBuilder to add endpoints to.</param>
    /// <returns>The configured IEndpointRouteBuilder.</returns>
    public static IEndpointRouteBuilder MapHealthCheckEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/api/health/ready", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("ready"),
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(
                        new
                        {
                            status = report.Status.ToString(),
                            checks = report.Entries.Select(entry => new
                            {
                                name = entry.Key,
                                status = entry.Value.Status.ToString(),
                                exception = entry.Value.Exception != null ? entry.Value.Exception.Message : "none",
                                duration = entry.Value.Duration.ToString()
                            })
                        }
                    );

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            }).WithName("HealthReady")
            .WithTags("Health Checks")
            .AddOpenApiHealthCheckDefaults("Health check to indicate if the service is ready and accepting requests.");

        endpoints.MapHealthChecks("/api/health/live", new HealthCheckOptions
            {
                Predicate = _ => false
            }).WithName("HealthLive")
            .WithTags("Health Checks")
            .AddOpenApiHealthCheckDefaults("Health check to indicate if the service is live and accepting requests.");

        return endpoints;
    }
}

/// <summary>
/// A schema filter for Swashbuckle to add descriptions to OpenAPI schema elements based on
/// <see cref="DescriptionAttribute"/> annotations.
/// </summary>
internal class DescriptionSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Applies the schema filter to add descriptions to the schema elements.
    /// </summary>
    /// <param name="schema">The OpenAPI schema being modified.</param>
    /// <param name="context">The context for the schema filter, containing information about the parameter, member, and type being processed.</param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Check for DescriptionAttribute on the parameter and set the schema description if found
        if (context.ParameterInfo != null)
        {
            var descriptionAttributes = context.ParameterInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
                schema.Description = descriptionAttribute.Description;
            }
        }

        // Check for DescriptionAttribute on the member and set the schema description if found
        if (context.MemberInfo != null)
        {
            var descriptionAttributes = context.MemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
                schema.Description = descriptionAttribute.Description;
            }
        }

        // Check for DescriptionAttribute on the type and set the schema description if found
        if (context.Type == null) return;
        {
            var descriptionAttributes = context.Type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length <= 0) return;
            var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
            schema.Description = descriptionAttribute.Description;
        }
    }
}