using System.Collections.Concurrent;
using System.Drawing;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using AutoMapper;
using CsvHelper;
using DataBridge.Data;
using DataBridge.Helpers;
using DataBridge.Models.Contentserv;
using DataBridge.Options;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace DataBridge.Services;

/// <summary>
/// Provides services for interacting with Contentserv data, including importing, exporting, and managing product information.
/// </summary>
public class ContentservService : IHealthCheck
{
    private readonly AppDbContext _db;
    private readonly HttpClient _httpClient;
    private readonly ILogger<ContentservService> _logger;
    private readonly IMapper _mapper;
    private readonly ContentservOptions _contentservOptions;
    private readonly ContentservTokenService _tokenService;
    private readonly IServiceProvider? _serviceProvider;

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentservService"/> class.
    /// </summary>
    /// <param name="db">The database context for interacting with the database.</param>
    /// <param name="logger">The logger for logging service operations.</param>
    /// <param name="mapper">The AutoMapper instance for object mapping.</param>
    /// <param name="httpClientFactory">The HttpClientFactory instance for creating HttpClient.</param>
    /// <param name="contentservOptions">The options instance containing Contentserv configuration.</param>
    /// <param name="tokenService">The service for managing Contentserv tokens.</param>
    /// <param name="serviceProvider">The service provider for dependency injection.</param>
    public ContentservService(AppDbContext db, ILogger<ContentservService> logger, IMapper mapper,
        IHttpClientFactory httpClientFactory, IOptions<ContentservOptions> contentservOptions,
        ContentservTokenService tokenService, IServiceProvider serviceProvider)
    {
        _db = db;
        _logger = logger;
        _mapper = mapper;
        _tokenService = tokenService; // _serviceProvider.GetRequiredService<ContentservTokenService>();
        _serviceProvider = serviceProvider;
        _httpClient = httpClientFactory.CreateClient(ProjectHelper.ContentservClient);
        _contentservOptions = contentservOptions.Value;
    }

    /// <summary>
    /// Retrieves data from the Contentserv API.
    /// </summary>
    /// <returns>A string containing the API response.</returns>
    public async Task<string> GetDataAsync()
    {
        var response = await MakeAuthenticatedApiCall("pxc/global/v1/tenant/users");
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Retrieves a product by its ID from the Contentserv API.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>A string containing the product data.</returns>
    public async Task<string> GetProductByIdAsync(int id)
    {
        var response = await MakeAuthenticatedApiCall($"pxc/core/v1/product/{id}");
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Builds the product hierarchy by retrieving data from the Contentserv API and storing it in the database.
    /// </summary>
    /// <returns>A list of ProductHierarchyResponse objects representing the product hierarchy.</returns>
    public async Task<List<ProductHierarchyResponse>> BuildProductHierarchyAsync()
    {
        var allProductIds = new List<int>();
        var allProducts = new List<ProductHierarchy>();

        var response = await MakeAuthenticatedApiCall($"pxc/core/v1/product/tree/1000");
        var content = await response.Content.ReadFromJsonAsync<ProductHierarchyResponse>();

        var existingProductIds = await _db.ProductHierachy.Select(p => p.ID).ToListAsync();
        var existingProductsSet = new HashSet<int>(existingProductIds);

        if (content?.RootProduct != null)
        {
            CollectProductIds(content.RootProduct, allProductIds);
        }

        foreach (var productId in allProductIds.Where(id => !existingProductsSet.Contains(id)))
        {
            var product = await ProcessProductNode(productId);
            if (product == null) continue;

            allProducts.Add(product);
            _db.ProductHierachy.Add(product);
        }

        await _db.SaveChangesAsync();

        return [content ?? new ProductHierarchyResponse { RootProduct = null }];
    }

    /// <summary>
    /// Imports product data from an Excel file.
    /// </summary>
    /// <param name="file">The Excel file containing product data.</param>
    /// <param name="changesOnly">If true, only changed products will be uploaded to the external API.</param>
    /// <returns>An ImportResult object containing information about the import process.</returns>
    public async Task<ImportResult> ImportFileAsync(IFormFile file, bool changesOnly = false)
    {
        if (file.Length == 0) throw new ArgumentException("File is empty", nameof(file));

        var importResult = new ImportResult();
        var products = await ImportExcel(file);

        var importedProducts = products.Select(p => p.PdmarticleID).ToList();
        var existingProductIds = await _db.Products.Select(p => p.PdmarticleID).ToListAsync();
        var existingProductsSet = new HashSet<int>(existingProductIds);

        var newProducts = new List<Product>();
        var existingProducts = new List<Product>();

        foreach (var product in products)
        {
            product.ParseTreePath();
            product.ParseClassMappings();

            if (!existingProductsSet.Contains(product.PdmarticleID))
            {
                newProducts.Add(product);
                importResult.Added++;
            }
            else
            {
                existingProducts.Add(product);
                importResult.Updated++;
            }
        }

        if (importResult.Added > 0) await _db.BulkInsertAsync(newProducts);
        if (importResult.Updated > 0) await _db.BulkUpdateAsync(existingProducts);

        importResult.TotalProcessed = products.Count;

        if (changesOnly)
        {
            importResult.ChangesUploaded = await UploadChangedProductsAsync(importedProducts);
        }

        return importResult;
    }

    /// <summary>
    /// Retrieves all products from the database.
    /// </summary>
    /// <returns>A list of Product objects.</returns>
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _db.Products.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Exports all products from the database as a JSON byte array.
    /// </summary>
    /// <returns>A byte array containing the JSON representation of all products.</returns>
    public async Task<byte[]> ExportProductsAsJsonAsync()
    {
        var products = await _db.Products.AsNoTracking().ToListAsync();
        var json = JsonSerializer.Serialize(products, JsonSerializerOptions);
        return System.Text.Encoding.UTF8.GetBytes(json);
    }

    /// <summary>
    /// Exports all products from the database as a CSV byte array.
    /// </summary>
    /// <returns>A byte array containing the CSV representation of all products.</returns>
    public async Task<byte[]> ExportProductsAsCsvAsync()
    {
        var products = await _db.Products.AsNoTracking().ToListAsync();

        using var memoryStream = new MemoryStream();
        await using var streamWriter = new StreamWriter(memoryStream);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteHeader<Product>();
        await csvWriter.NextRecordAsync();

        foreach (var product in products)
        {
            csvWriter.WriteRecord(product);
            await csvWriter.NextRecordAsync();
        }

        await csvWriter.FlushAsync();
        await streamWriter.FlushAsync();
        return memoryStream.ToArray();
    }

    /// <summary>
    /// Exports all products from the database as an XLSX byte array.
    /// </summary>
    /// <returns>A byte array containing the XLSX representation of all products.</returns>
    public async Task<byte[]> ExportProductsAsXlsxAsync()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        var products = await _db.Products.AsNoTracking().ToListAsync();

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Products");

        var properties = typeof(Product).GetProperties();

        for (var i = 0; i < properties.Length; i++)
        {
            worksheet.Cells[1, i + 1].Value = properties[i].Name;
            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        var results = new ConcurrentDictionary<int, object?[]>();

        Parallel.For(0, products.Count, row =>
        {
            var rowData = new object?[properties.Length];
            for (var col = 0; col < properties.Length; col++)
            {
                rowData[col] = properties[col].GetValue(products[row]);
            }

            results[row] = rowData;
        });

        for (var row = 0; row < products.Count; row++)
        {
            worksheet.Cells[row + 2, 1].LoadFromArrays(new[] { results[row] });
        }

        worksheet.Cells.AutoFitColumns();

        return await package.GetAsByteArrayAsync();
    }

    /// <summary>
    /// Deletes all products from the database.
    /// </summary>
    /// <returns>The number of products deleted.</returns>
    public async Task<int> DeleteProductsAsync()
    {
        return await _db.Products.ExecuteDeleteAsync();
    }

    /// <summary>
    /// Makes an authenticated API call to the Contentserv API.
    /// </summary>
    /// <param name="endpoint">The API endpoint to call.</param>
    /// <returns>The HttpResponseMessage from the API call.</returns>
    private async Task<HttpResponseMessage> MakeAuthenticatedApiCall(string endpoint)
    {
        var token = await _tokenService.GetTokensAsync();
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        return await _httpClient.GetAsync(endpoint);
    }

    /// <summary>
    /// Recursively collects product IDs from a product hierarchy.
    /// </summary>
    /// <param name="productHierarchy">The product hierarchy to process.</param>
    /// <param name="idList">The list to collect product IDs into.</param>
    private static void CollectProductIds(ProductHierarchy productHierarchy, List<int> idList)
    {
        idList.Add(productHierarchy.ID);

        if (productHierarchy.Products == null) return;

        foreach (var childProduct in productHierarchy.Products)
        {
            CollectProductIds(childProduct, idList);
        }
    }

    /// <summary>
    /// Processes a single product node by retrieving its data from the API.
    /// </summary>
    /// <param name="productId">The ID of the product to process.</param>
    /// <returns>A ProductHierarchy object representing the processed product, or null if processing failed.</returns>
    private async Task<ProductHierarchy?> ProcessProductNode(int productId)
    {
        var response = await MakeAuthenticatedApiCall($"pxc/core/v1/product/{productId}");
        var rawContent = await response.Content.ReadAsStringAsync();
        var productContent = JsonSerializer.Deserialize<ProductHierarchyResponse>(rawContent);
        return productContent?.RootProduct;
    }

    /// <summary>
    /// Imports product data from an Excel file.
    /// </summary>
    /// <param name="file">The Excel file to import.</param>
    /// <returns>A list of Product objects parsed from the Excel file.</returns>
    private async Task<List<Product>> ImportExcel(IFormFile file)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);

        using var package = new ExcelPackage(stream);
        var worksheet = package.Workbook.Worksheets[0];
        var rowCount = worksheet.Dimension.Rows;
        var colCount = worksheet.Dimension.Columns;

        var headers = Enumerable.Range(1, colCount)
            .Select(col => NormalizeHeader(worksheet.Cells[1, col].Value?.ToString()))
            .ToList();

        var products = new ConcurrentBag<Product>();

        Parallel.For(2, rowCount + 1, row =>
        {
            var product = new Product();
            for (var col = 1; col <= colCount; col++)
            {
                var value = worksheet.Cells[row, col].Value?.ToString();
                var header = headers[col - 1];
                MapPropertyValue(product, header, value);
            }

            products.Add(product);
        });

        return products.ToList();
    }

    /// <summary>
    /// Maps a value to a property of a Product object.
    /// </summary>
    /// <param name="product">The Product object to map the value to.</param>
    /// <param name="header">The name of the property to map to.</param>
    /// <param name="value">The value to map.</param>
    private void MapPropertyValue(Product product, string header, string? value)
    {
        var property = product.GetType().GetProperty(header);
        if (property == null || !property.CanWrite) return;

        try
        {
            if (string.IsNullOrWhiteSpace(value) || value == "---")
            {
                property.SetValue(product, null);
                return;
            }

            if (value.StartsWith("---"))
            {
                value = value[3..].Trim();
                if (string.IsNullOrWhiteSpace(value))
                {
                    property.SetValue(product, null);
                    return;
                }
            }

            var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

            object? convertedValue;
            if (targetType == typeof(int))
            {
                convertedValue = int.TryParse(value, out var intValue) ? intValue : null;
            }
            else if (targetType == typeof(decimal))
            {
                convertedValue = decimal.TryParse(value, out var decimalValue) ? decimalValue : null;
            }
            else if (targetType == typeof(DateTime))
            {
                convertedValue = DateTime.TryParse(value, out var dateTimeValue) ? dateTimeValue : null;
            }
            else if (targetType == typeof(bool))
            {
                convertedValue = bool.TryParse(value, out var boolValue) ? boolValue : null;
            }
            else
            {
                convertedValue = Convert.ChangeType(value, targetType);
            }

            property.SetValue(product, convertedValue);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error mapping property value for {Header} with value {Value}", header, value);
            throw new InvalidOperationException($"Could not map property {header} with value {value}", ex);
        }
    }

    /// <summary>
    /// Normalizes a header string by removing special characters and spaces to the mapping works correctly.
    /// </summary>
    /// <param name="header">The header string to normalize.</param>
    /// <returns>The normalized header string.</returns>
    private static string NormalizeHeader(string? header)
    {
        if (string.IsNullOrEmpty(header)) return string.Empty;

        if (header.Contains("_TreeSort")) header = header.Replace("_", "");

        var formattedHeader = header.Replace("(filter)", "");
        var firstPart = formattedHeader.Split('#')[0];
        return firstPart.Trim().Replace(" ", "").Replace(".", "");
    }

    /// <summary>
    /// Uploads changed products to an external API.
    /// </summary>
    /// <param name="importedProducts">A list of product IDs that were imported.</param>
    /// <returns>True if the upload was successful, false otherwise.</returns>
    private async Task<bool> UploadChangedProductsAsync(List<int> importedProducts)
    {
        var url = new Uri("http://localhost:65238/api/v1/upload/pim");
        var authKey = _contentservOptions.AuthKey;
        var changedProducts = await _db.Products
            .Where(p => importedProducts.Contains(p.PdmarticleID))
            .AsNoTracking()
            .ToListAsync();
        
        var json = JsonSerializer.Serialize(changedProducts, JsonSerializerOptions);
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);
        using var memoryStream = new MemoryStream(bytes);
        
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("x-api-key", authKey);
        
        var response = await httpClient.PostAsync(url, new MultipartFormDataContent
        {
            { new StreamContent(memoryStream), "file", "products_export.json" }
        });
        
        return response.IsSuccessStatusCode;
        return true;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Check if we can connect to the Contentserv API
            var data = await GetDataAsync();
            return string.IsNullOrEmpty(data)
                ? HealthCheckResult.Unhealthy("Unable to retrieve Contentserv base URI.")
                : HealthCheckResult.Healthy("Contentserv API is up.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy($"Error checking Contentserv API health: {ex.Message}");
        }
    }
}