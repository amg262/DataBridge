using Asp.Versioning;
using DataBridge.Models.Contentserv;
using DataBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataBridge.Controllers;

/// <summary>
/// Controller for handling Contentserv-related operations.
/// </summary>
[Authorize]
[ApiController]
[SwaggerTag]
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class ContentservController : ControllerBase
{
    private readonly ContentservService _contentservService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentservController"/> class.
    /// </summary>
    /// <param name="contentservService">Service used to interact with Contentserv APIs</param>
    public ContentservController(ContentservService contentservService)
    {
        _contentservService = contentservService;
    }

    /// <summary>
    /// Retrieves data from the Contentserv API.
    /// </summary>
    /// <returns>An ActionResult containing the retrieved data.</returns>
    [HttpGet("data")]
    public async Task<ActionResult> GetData()
    {
        var content = await _contentservService.GetDataAsync();
        return Ok(content);
    }

    /// <summary>
    /// Retrieves a product by its ID from the Contentserv API.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>An IActionResult containing the product data.</returns>
    [HttpGet("product/{id:int}")]
    [SwaggerResponse(200, "Data retrieved successfully", typeof(List<ProductHierarchyResponse>))]
    public async Task<IActionResult> GetProductById(int id)
    {
        var content = await _contentservService.GetProductByIdAsync(id);
        return Ok(content);
    }

    /// <summary>
    /// Builds and retrieves the product hierarchy from the Contentserv API.
    /// </summary>
    /// <returns>An IActionResult containing the product hierarchy data.</returns>
    [HttpPost("hierarchy")]
    [SwaggerResponse(200, "Data retrieved successfully", typeof(List<ProductHierarchyResponse>))]
    public async Task<IActionResult> BuildProductHierarchy()
    {
        var result = await _contentservService.BuildProductHierarchyAsync();
        return Ok(new { allProducts = result });
    }

    /// <summary>
    /// Imports a file into the Contentserv system.
    /// </summary>
    /// <param name="file">The file to import.</param>
    /// <param name="changesOnly">Flag to determine if only changes should be imported.</param>
    /// <returns>An IActionResult containing the import result.</returns>
    [HttpPost("import")]
    [SwaggerResponse(200, "File imported successfully", typeof(ImportResult))]
    public async Task<IActionResult> ImportFile(IFormFile? file, bool changesOnly = false)
    {
        if (file == null || file.Length == 0) return BadRequest("File is empty");
        var importResult = await _contentservService.ImportFileAsync(file, changesOnly);
        return Ok(importResult);
    }

    /// <summary>
    /// Retrieves all products from the Contentserv API.
    /// </summary>
    /// <returns>An IActionResult containing the list of products.</returns>
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _contentservService.GetProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// Exports products in the specified format (json, csv, or xlsx).
    /// </summary>
    /// <param name="format">The format to export the products in (json, csv, or xlsx).</param>
    /// <returns>A file containing the exported products in the specified format.</returns>
    [HttpGet("export")]
    public async Task<IActionResult> Export(string format = "json")
    {
        byte[] fileContents;
        string contentType;
        string fileName;

        switch (format.ToLower())
        {
            case "json":
                fileContents = await _contentservService.ExportProductsAsJsonAsync();
                contentType = "application/json";
                fileName = "products_export.json";
                break;
            case "csv":
                fileContents = await _contentservService.ExportProductsAsCsvAsync();
                contentType = "text/csv";
                fileName = "products_export.csv";
                break;
            case "xlsx":
                fileContents = await _contentservService.ExportProductsAsXlsxAsync();
                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                fileName = "products_export.xlsx";
                break;
            default:
                return BadRequest("Invalid export format. Supported formats: json, csv, xlsx");
        }

        return File(fileContents, contentType, fileName);
    }

    /// <summary>
    /// Exports products as a JSON file.
    /// </summary>
    /// <returns>A JSON file containing the exported products.</returns>
    [HttpGet("export-json")]
    [SwaggerResponse(200, "Products exported successfully as JSON")]
    public async Task<IActionResult> ExportProductsAsJson()
    {
        var fileContents = await _contentservService.ExportProductsAsJsonAsync();
        return File(fileContents, "application/json", "products_export.json");
    }

    /// <summary>
    /// Exports products as a CSV file.
    /// </summary>
    /// <returns>A CSV file containing the exported products.</returns>
    [HttpGet("export-csv")]
    [SwaggerResponse(200, "Products exported successfully as CSV")]
    public async Task<IActionResult> ExportProductsAsCsv()
    {
        var fileContents = await _contentservService.ExportProductsAsCsvAsync();
        return File(fileContents, "text/csv", "products_export.csv");
    }

    /// <summary>
    /// Exports products as an XLSX file.
    /// </summary>
    /// <returns>An XLSX file containing the exported products.</returns>
    [HttpGet("export-xlsx")]
    [SwaggerResponse(200, "Products exported successfully as XLSX")]
    public async Task<IActionResult> ExportProductsAsXlsx()
    {
        var fileContents = await _contentservService.ExportProductsAsXlsxAsync();
        return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "products_export.xlsx");
    }

    /// <summary>
    /// Deletes all products from the Contentserv system.
    /// </summary>
    /// <returns>An IActionResult containing the number of deleted records.</returns>
    [HttpDelete("delete-products")]
    [SwaggerResponse(200, "Products deleted successfully")]
    public async Task<IActionResult> DeleteProducts()
    {
        var count = await _contentservService.DeleteProductsAsync();
        return Ok($"{count} records deleted successfully.");
    }
}