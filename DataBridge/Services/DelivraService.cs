using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataBridge.Data;
using DataBridge.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace DataBridge.Services;

/// <summary>
/// Provides services for interacting with Delivra data, including CRUD operations and API interactions.
/// </summary>
public class DelivraService : IHealthCheck
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;
    private readonly ILogger<DelivraService> _logger;
    private readonly IConfigurationProvider _configurationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelivraService"/> class.
    /// </summary>
    /// <param name="logger">The logger for logging service operations.</param>
    /// <param name="configurationProvider">The AutoMapper configuration provider.</param>
    /// <param name="httpClient">The HTTP client for making API requests.</param>
    /// <param name="db">AppDbContext instance for Delivra</param>
    /// <param name="mapper">The AutoMapper instances for Delivra</param>
    public DelivraService(ILogger<DelivraService> logger, IConfigurationProvider configurationProvider, HttpClient httpClient,
        AppDbContext db, IMapper mapper)
    {
        _logger = logger;
        _configurationProvider = configurationProvider;
        _httpClient = httpClient;
        _db = db;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all entities of a specified type from the database and maps them to DTOs.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to retrieve.</typeparam>
    /// <typeparam name="TDto">The type of the DTO to map to.</typeparam>
    /// <returns>A list of DTOs representing the entities.</returns>
    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class where TDto : class
    {
        return await _db.Set<TEntity>().AsNoTracking().ProjectTo<TDto>(_configurationProvider).ToListAsync();
    }

    /// <summary>
    /// Retrieves entities from the Delivra API, saves them to the database, and returns them as DTOs.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to save.</typeparam>
    /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
    /// <param name="requestUri">The URI for the API request.</param>
    /// <returns>A list of DTOs representing the new entities, or null if no entities were retrieved or saved.</returns>
    public async Task<List<TDto>?> PostAsync<TEntity, TDto>(string? requestUri) where TEntity : class
    {
        var response = await _httpClient.GetAsync(requestUri);
        var result = await response.Content.ReadAsStringAsync();
        var dtos = JsonSerializer.Deserialize<List<TDto>>(result);

        if (dtos == null || dtos.Count == 0) return null;

        _db.Set<TEntity>().AddRange(_mapper.Map<List<TEntity>>(dtos));
        await _db.SaveChangesAsync();

        return dtos;
    }

    /// <summary>
    /// Retrieves new entities from the Delivra API, saves them to the database if they don't already exist, and returns them as DTOs.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to save.</typeparam>
    /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
    /// <param name="requestUri">The URI for the API request.</param>
    /// <returns>A list of DTOs representing the new entities, or null if no new entities were retrieved or saved.</returns>
    public async Task<List<TDto>?> PutAsync<TEntity, TDto>(string? requestUri) where TEntity : class
    {
        var existingEntities = await _db.Set<TEntity>().AsNoTracking().ToListAsync();
        var existingEntitiesHashSet = new HashSet<TEntity>(existingEntities);

        var response = await _httpClient.GetAsync(requestUri);
        var result = await response.Content.ReadAsStringAsync();
        var reportEntities = JsonSerializer.Deserialize<List<TEntity>>(result);

        if (reportEntities == null || reportEntities.Count == 0) return null;

        var newEntities = reportEntities.Where(r => !existingEntitiesHashSet.Contains(r)).ToList();

        if (newEntities.Count == 0) return null;

        _db.Set<TEntity>().AddRange(newEntities);
        await _db.SaveChangesAsync();

        return _mapper.Map<List<TDto>>(newEntities);
    }

    /// <summary>
    /// Deletes all entities of a specified type from the database.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to delete.</typeparam>
    /// <returns>True if entities were deleted, false if no entities were found to delete.</returns>
    public async Task<bool> DeleteAsync<TEntity>() where TEntity : class
    {
        var count = await _db.Set<TEntity>().CountAsync();

        if (count == 0) return false;

        _db.Set<TEntity>().RemoveRange(_db.Set<TEntity>());
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            const string email = "andrewgunn31@gmail.com";
            var request = await _httpClient.GetAsync($"Contacts/{email}", cancellationToken);
            var contactResult = await request.Content.ReadAsStringAsync(cancellationToken);

            return request.IsSuccessStatusCode
                ? HealthCheckResult.Healthy("Delivra API is available")
                : HealthCheckResult.Unhealthy("Delivra API is unavailable");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}