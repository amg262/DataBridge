using System.Net.Http.Headers;
using System.Text;
using Asp.Versioning;
using DataBridge.Data;
using DataBridge.Helpers;
using DataBridge.Options;
using DataBridge.Services;
using ElevenLabs;
using Hangfire;
using Hangfire.SqlServer;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OpenAI.Chat;
using Polly;
using RestSharp;
using RestSharp.Authenticators;

var builder = WebApplication.CreateBuilder(args);
string[] tags = ["Ready"];

builder.Services.AddDbContext<AppDbContext>(options =>
    // options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            o => o.EnableRetryOnFailure())
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging());
// Unlimited request body size
builder.WebHost.ConfigureKestrel(serverOptions => { serverOptions.Limits.MaxRequestBodySize = null; });

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue; // formdata-multipart
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

// Configure IIS Server Limits
builder.Services.Configure<IISServerOptions>(options => { options.MaxRequestBodySize = int.MaxValue; });

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAndHealthChecks(builder.Configuration); // Extension
builder.Services.AddHealthChecksUI(setupSettings: setup =>
{
    setup.SetEvaluationTimeInSeconds(3600); // 1 hour
    setup.MaximumHistoryEntriesPerEndpoint(60);
    setup.SetNotifyUnHealthyOneTimeUntilChange();
    setup.SetApiMaxActiveRequests(1);
    setup.MaximumHistoryEntriesPerEndpoint(60);
    setup.AddHealthCheckEndpoint("Health Checks", "/healthz");
    // setup.AddHealthCheckEndpoint("Hangfire Dashboard", "/hangfire");
    // setup.AddHealthCheckEndpoint("API Health Check", $"{builder.Configuration["BackendOptions:ApiUrl"]}Delivra/Reports");
// }).AddPostgreSqlStorage(builder.Configuration.GetConnectionString("PostgresConnection"))9;
// }).AddSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
}).AddInMemoryStorage();

builder.Services.Configure<DelivraOptions>(builder.Configuration.GetSection("DelivraOptions"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.Configure<BackendOptions>(builder.Configuration.GetSection("BackendOptions"));
builder.Services.Configure<ContentservOptions>(builder.Configuration.GetSection("ContentservOptions"));
builder.Services.Configure<LivePersonOptions>(builder.Configuration.GetSection("LivePersonOptions"));
builder.Services.Configure<ElevenLabsOptions>(builder.Configuration.GetSection("ElevenLabsOptions"));
builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("EmailOptions"));
builder.Services.Configure<OpenAiOptions>(builder.Configuration.GetSection("OpenAiOptions"));

builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddScoped<JwtTokenProvider>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ContentservService>();
builder.Services.AddScoped<LivePersonService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DelivraService>();
builder.Services.AddScoped<ElevenLabsService>();

builder.Services.AddScoped<ElevenLabsClient>(sp =>
{
    var opts = sp.GetRequiredService<IOptions<ElevenLabsOptions>>().Value;
    return new ElevenLabsClient(opts.ApiKey);
});

builder.Services.AddSingleton<ChatClient>(sp =>
{
    var options = sp.GetRequiredService<IOptions<OpenAiOptions>>().Value;
    return new ChatClient(model: options.Model, apiKey: options.ApiKey);
});

builder.Services.AddScoped<OpenAiService>();


// register it as a hosted service, using the singleton instance:
// builder.Services.AddSingleton<IHostedService, JobService>();
// builder.Services.AddHostedService(sp => sp.GetRequiredService<JobService>());
builder.Services.AddSingleton<JobService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<JobService>());
// Have to register as a singelton otherwise it will only be available for IHostedService

// When ContentservTokenService was registered both as a singleton and as an IHostedService, it created a circular dependency.
// The IHostedService interface requires the service to be resolved during application startup, but the service itself was trying
// to resolve other dependencies (like IHttpClientFactory) that might not have been fully initialized yet.
// ContentservService is scoped, but it was trying to directly inject a singleton ContentservTokenService. This isn't inherently
// problematic, but combined with the IHostedService registration, it created a complex dependency graph that the DI container
// couldn't resolve.
// The HostedService uses the singleton we register so its available to ContentservService
builder.Services.AddSingleton<ContentservTokenService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<ContentservTokenService>());


builder.Services.AddHttpClient<DelivraService>(client =>
{
    client.DefaultRequestHeaders.Clear();
    client.BaseAddress = new Uri(builder.Configuration["DelivraOptions:BaseUrl"] ?? string.Empty);
    client.DefaultRequestHeaders.Add("username", builder.Configuration["DelivraOptions:Username"]);
    client.DefaultRequestHeaders.Add("password", builder.Configuration["DelivraOptions:Password"]);
    client.DefaultRequestHeaders.Add("listname", builder.Configuration["DelivraOptions:Listname"]);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).AddStandardResilienceHandler();

builder.Services.AddHttpClient(ProjectHelper.ContentservClient, client =>
{
    client.DefaultRequestHeaders.Clear();
    client.Timeout = TimeSpan.FromSeconds(60);
    client.BaseAddress = new Uri(builder.Configuration["ContentservOptions:BaseUrl"] ?? string.Empty);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).AddStandardResilienceHandler();

builder.Services.AddHttpClient(ProjectHelper.LivepersonClient, client =>
{
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).AddStandardResilienceHandler();

// Create a singleton instance of the RestClient and register it with the DI container using the Options pattern
// so there is only one authenticated instance of the RestClient for the entire application
builder.Services.AddSingleton(sp =>
{
    var opts = sp.GetRequiredService<IOptions<LivePersonOptions>>().Value;
    return new RestClient(new RestClientOptions
    {
        Authenticator = OAuth1Authenticator.ForProtectedResource(
            opts.AppKey,
            opts.AppSecret,
            opts.AccessToken,
            opts.AccessTokenSecret)
    });
});

// builder.Services.AddHttpClient<JobService>(client =>
// {
//     client.DefaultRequestHeaders.Clear();
//     client.BaseAddress = new Uri(builder.Configuration["BackendOptions:ApiUrl"] ?? string.Empty);
//     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
// }).AddStandardResilienceHandler();


builder.Services.AddHangfireServer();
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings());

builder.Services.AddHealthChecks()
    .AddCheck<LivePersonService>("Liveperson API", tags: tags)
    .AddCheck<ContentservService>("Contentserv API", tags: tags)
    .AddCheck<DelivraService>("Delivra API", tags: tags)
    .AddCheck<ElevenLabsService>("ElevenLabs API", tags: tags)
    .AddCheck<OpenAiService>("OpenAI API", tags: tags);

builder.Services.AddProblemDetails(); // ProblemDetails for error handling to go with GlobalExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); // Global exception handling for all controllers and logging

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
    logging.AddEventSourceLogger();
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(ProjectHelper.CorsPolicy, policyBuilder =>
    {
        policyBuilder
            .WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [])
            .WithMethods(builder.Configuration.GetSection("Cors:AllowedMethods").Get<string[]>() ?? [])
            .WithHeaders(builder.Configuration.GetSection("Cors:AllowedHeaders").Get<string[]>() ?? [])
            .AllowCredentials();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
            ValidAudience = builder.Configuration["JwtOptions:Audience"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Secret"] ?? string.Empty))
        };
        // This fires before the request is processed to add the Authorization header to the request
        // or to get the token from the request and add it to the Authorization header if it's set by Swagger UI
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var tokenProvider = context.HttpContext.RequestServices.GetRequiredService<JwtTokenProvider>();
                var token = tokenProvider.RetrieveToken();

                if (string.IsNullOrEmpty(token)) return Task.CompletedTask;

                context.Token = token;
                StringValues auth = string.Empty;

                // This will try to get the Authorization header from the request to see if it already exists i.e from Swagger
                // If it does, it will not add the Authorization header to the request because token is already present
                context?.Request?.Headers?.TryGetValue("Authorization", out auth);

                if (auth.Count > 0) return Task.CompletedTask;
                // changed to Append to fix exception warning
                context?.Request?.Headers?.Append("Authorization", $"Bearer {token}");

                return Task.CompletedTask;
            }
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DataBridge API v1");
        options.DocumentTitle = "DataBridge - API Documentation";
        options.DisplayRequestDuration();
        options.EnableFilter();
        options.ShowExtensions();
        options.EnableDeepLinking();
        options.EnableValidator();
        options.EnableTryItOutByDefault();
    });
}

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(options =>
{
    options.UIPath = "/hc-ui";
    options.ApiPath = "/hc-json";
    options.PageTitle = "DataBridge - Health";
    options.AddCustomStylesheet("wwwroot/css/healthchecks.css");
});

// app.UseCors(ProjectHelper.CorsPolicy);

app.UseRouting();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Use this to retry if container is not ready
var retryPolicy = Policy
    .Handle<Exception>()
    .WaitAndRetry(50, retryAttempt =>
            TimeSpan.FromSeconds(Math.Min(30, Math.Pow(2, retryAttempt))), // Exponential backoff with max 30 seconds
        (exception, timeSpan, retryCount, context) =>
        {
            retryCount++;
            Console.WriteLine($"Retry due to: {exception.Message}");
            Console.WriteLine($"Retry context: {context}");
            Console.WriteLine($"Retry in: {timeSpan.TotalSeconds} seconds");
            Console.WriteLine($"Retry count: {retryCount}");
        });

retryPolicy.ExecuteAndCapture(() =>
{
    // Init the DB before running any jobs because it needs the DB for hangfire and other services
    DbInitializer.InitDb(app);

    // Handle HangFire with policy retry if database isn't ready it'll keep trying
    GlobalConfiguration.Configuration
        .UseActivator(new HangfireActivator(app.Services))
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true,
            PrepareSchemaIfNecessary = true
        });
    // .UsePostgreSqlStorage(o => o.UseNpgsqlConn   ection(builder.Configuration.GetConnectionString("PostgresConnection")));
    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        // Authorization = [new HangfireAuthorizationFilter()],
        DashboardTitle = "Job Scheduler",
        DarkModeEnabled = true,
        FaviconPath = "/favicon.ico",
        AppPath = "/",
        DisplayStorageConnectionString = true,
        AsyncAuthorization = [new HangfireAsyncAuthorizationFilter()]
    });
});

app.Run();

public partial class Program
{
}