using DataBridge.Data;
using Hangfire;
using DataBridge.Models.Delivra;
using DataBridge.Models.Delivra.Dto;
using DataBridge.Options;
using Microsoft.Extensions.Options;

namespace DataBridge.Services;

/// <summary>
/// Service responsible for scheduling and executing background jobs using Hangfire.
/// </summary>
public class JobService : IHostedService
{
    private readonly ILogger<JobService> _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the JobService class.
    /// </summary>
    /// <param name="logger">The logger for this service.</param>
    /// <param name="hostApplicationLifetime">The host application lifetime.</param>
    /// <param name="serviceProvider">The service provider for dependency injection.</param>
    public JobService(ILogger<JobService> logger, IHostApplicationLifetime hostApplicationLifetime,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Starts the JobService and registers the job scheduler.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the start operation.</param>
    /// <returns>A task that represents the asynchronous start operation.</returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("JobService is starting");
        _hostApplicationLifetime.ApplicationStarted.Register(ScheduleJobs);
        _logger.LogInformation("JobService has started");
        return Task.CompletedTask;
    }

    /// <summary>
    /// Stops the JobService.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the stop operation.</param>
    /// <returns>A task that represents the asynchronous stop operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("JobService is stopping");
        return Task.CompletedTask;
    }

    /// <summary>
    /// Schedules all recurring jobs using Hangfire.
    /// </summary>
    private static void ScheduleJobs()
    {
        var timeZoneOptions = new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.Utc,
            MisfireHandling = MisfireHandlingMode.Relaxed
        };

        RecurringJob.AddOrUpdate<JobService>("Auth-IssueToken",
            service => service.ExecuteAuthIssueToken(),
            Cron.Daily, timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Delivra-Reports",
            service => service.ExecuteDelivraReports(),
            Cron.Hourly, timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Delivra-Segments",
            service => service.ExecuteDelivraSegments(),
            Cron.Hourly, timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Delivra-Clickthroughs",
            service => service.ExecuteDelivraClickthroughs(),
            Cron.Hourly, timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Delivra-Sends",
            service => service.ExecuteDelivraSends(),
            Cron.Hourly, timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Delivra-Opens",
            service => service.ExecuteDelivraOpens(),
            Cron.Hourly, timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Liveperson-Conversations-Offset",
            service => service.ExecuteLivepersonConversationsOffset(),
            Cron.Weekly(DayOfWeek.Sunday, 1, 30), timeZoneOptions);

        RecurringJob.AddOrUpdate<JobService>("Liveperson-Conversations",
            service => service.ExecuteLivepersonConversations(),
            Cron.Hourly, timeZoneOptions);


        // var id = BackgroundJob.Enqueue(() => Console.WriteLine("Hello, "));
        // BackgroundJob.ContinueJobWith(id, () => Console.WriteLine("world!"));
    }

    /// <summary>
    /// Executes the authentication token issuance job.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteAuthIssueToken()
    {
        using var scope = _serviceProvider.CreateScope();
        var authService = scope.ServiceProvider.GetRequiredService<AuthService>();
        authService?.IssueToken();
    }

    /// <summary>
    /// Executes the job to retrieve Liveperson conversations.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteLivepersonConversations()
    {
        using var scope = _serviceProvider.CreateScope();
        var livepersonService = scope.ServiceProvider.GetRequiredService<LivePersonService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await livepersonService.PostConversationsAsync(200);
    }


    /// <summary>
    /// Executes the job to retrieve Liveperson conversations.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>The offset is set to 20000 to retrieve all conversations at once via a loop.</remarks>
    public async Task ExecuteLivepersonConversationsOffset()
    {
        using var scope = _serviceProvider.CreateScope();
        var livepersonService = scope.ServiceProvider.GetRequiredService<LivePersonService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await livepersonService.PostConversationsAsync(20000);
    }

    /// <summary>
    /// Executes the job to update Delivra reports.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteDelivraReports()
    {
        using var scope = _serviceProvider.CreateScope();
        var delivraService = scope.ServiceProvider.GetRequiredService<DelivraService>();
        await delivraService.PutAsync<Report, ReportDto>(
            $"Reports?startDate={DateTime.Now.AddDays(-30):yyyy-MM-dd}&endDate={DateTime.Now:yyyy-MM-dd}");
    }

    /// <summary>
    /// Executes the job to update Delivra segments.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteDelivraSegments()
    {
        using var scope = _serviceProvider.CreateScope();
        var delivraService = scope.ServiceProvider.GetRequiredService<DelivraService>();
        await delivraService.PutAsync<Segment, SegmentDto>("Segments");
    }

    /// <summary>
    /// Executes the job to update Delivra clickthroughs.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteDelivraClickthroughs()
    {
        using var scope = _serviceProvider.CreateScope();
        var delivraService = scope.ServiceProvider.GetRequiredService<DelivraService>();
        await delivraService.PutAsync<Clickthrough, ClickthroughDto>(
            $"Reports/Clickthroughs?startDate={DateTime.Now.AddDays(-30):yyyy-MM-dd}&endDate={DateTime.Now:yyyy-MM-dd}");
    }

    /// <summary>
    /// Executes the job to update Delivra sends.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteDelivraSends()
    {
        using var scope = _serviceProvider.CreateScope();
        var delivraService = scope.ServiceProvider.GetRequiredService<DelivraService>();
        await delivraService.PutAsync<Send, SendDto>(
            $"Reports/Sends?startDate={DateTime.Now.AddDays(-30):yyyy-MM-dd}&endDate={DateTime.Now:yyyy-MM-dd}");
    }

    /// <summary>
    /// Executes the job to update Delivra opens.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ExecuteDelivraOpens()
    {
        using var scope = _serviceProvider.CreateScope();
        var delivraService = scope.ServiceProvider.GetRequiredService<DelivraService>();
        await delivraService.PutAsync<Open, OpenDto>(
            $"Reports/Opens?startDate={DateTime.Now.AddDays(-30):yyyy-MM-dd}&endDate={DateTime.Now:yyyy-MM-dd}");
    }
}