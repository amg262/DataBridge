using DataBridge.Models.Delivra;
using Microsoft.EntityFrameworkCore;

namespace DataBridge.Data;

/// <summary>
/// Provides methods for initializing and seeding the database with initial data.
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Initializes and seeds the auction database. This method is called during the application startup.
    /// It ensures that the database is created, applies any pending migrations, and seeds the database with initial data if necessary.
    /// </summary>
    /// <param name="app">The instance of <see cref="WebApplication"/> to access application services.</param>
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        SeedData(scope.ServiceProvider.GetService<AppDbContext>());
    }

    /// <summary>
    /// Seeds the database with initial data if it has not been seeded already.
    /// This includes creating predefined auction items with associated details.
    /// </summary>
    /// <param name="context">The database context instance for accessing the auctions database.</param>
    private static void SeedData(AppDbContext? context)
    {
        context?.Database.Migrate();
    }
}