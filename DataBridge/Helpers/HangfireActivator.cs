using Hangfire;
using Hangfire.Dashboard;

namespace DataBridge.Helpers;

/// <summary>
/// Custom JobActivator for Hangfire to resolve dependencies using the application's service provider.
/// </summary>
public class HangfireActivator : JobActivator
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the HangfireActivator class.
    /// </summary>
    /// <param name="serviceProvider">The IServiceProvider to use for resolving dependencies.</param>
    public HangfireActivator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Activates a job of the specified type.
    /// </summary>
    /// <param name="jobType">The type of the job to activate.</param>
    /// <returns>An instance of the specified job type.</returns>
    public override object ActivateJob(Type jobType)
    {
        return _serviceProvider.GetRequiredService(jobType);
    }

    /// <summary>
    /// Begins a new scope for job activation.
    /// </summary>
    /// <param name="context">The JobActivatorContext for the current activation.</param>
    /// <returns>A new HangfireJobScope instance.</returns>
    public override JobActivatorScope BeginScope(JobActivatorContext context)
    {
        return new HangfireJobScope(_serviceProvider.CreateScope());
    }
}

/// <summary>
/// Custom JobActivatorScope for Hangfire to manage the lifetime of services within a job's execution scope.
/// </summary>
public class HangfireJobScope : JobActivatorScope
{
    private readonly IServiceScope _serviceScope;

    /// <summary>
    /// Initializes a new instance of the HangfireJobScope class.
    /// </summary>
    /// <param name="serviceScope">The IServiceScope to use for this job's execution.</param>
    public HangfireJobScope(IServiceScope serviceScope)
    {
        _serviceScope = serviceScope;
    }

    /// <summary>
    /// Resolves a service of the specified type within this scope.
    /// </summary>
    /// <param name="type">The type of service to resolve.</param>
    /// <returns>An instance of the specified service type.</returns>
    public override object Resolve(Type type)
    {
        return _serviceScope.ServiceProvider.GetRequiredService(type);
    }

    /// <summary>
    /// Disposes of the current scope and releases all associated resources.
    /// </summary>
    public override void DisposeScope()
    {
        _serviceScope.Dispose();
    }
}

/// <summary>
/// Provides custom authorization for the Hangfire Dashboard.
/// </summary>
public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    /// <summary>
    /// Authorizes the Hangfire Dashboard access based on user authentication.
    /// </summary>
    /// <param name="context">The Hangfire Dashboard context.</param>
    /// <returns>true if the user is authenticated; otherwise, false.</returns>
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        // The pattern matching checks for null by default so its safer
        return httpContext.User.Identity is { IsAuthenticated: true };
    }
}

/// <summary>
/// Provides custom async authorization for the Hangfire Dashboard.
/// </summary>
public class HangfireAsyncAuthorizationFilter : IDashboardAsyncAuthorizationFilter
{
    /// <summary>
    /// Authorizes the Hangfire Dashboard access based on user authentication and role.
    /// </summary>
    /// <param name="context">The Hangfire Dashboard context.</param>
    /// <returns>A Task that represents the asynchronous operation, containing a boolean indicating whether access is authorized.</returns>
    public Task<bool> AuthorizeAsync(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        return Task.FromResult(httpContext.User.Identity is { IsAuthenticated: true });
    }
}