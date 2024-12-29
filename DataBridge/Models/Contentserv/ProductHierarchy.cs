using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Contentserv;

/// <summary>
/// Represents the response object for the product hierarchy.
/// </summary>
public class ProductHierarchyResponse
{
    /// <summary>
    /// Gets or sets the root productResponseObject of the response.
    /// </summary>
    [JsonPropertyName("Product")]
    public ProductHierarchy? RootProduct { get; set; }
}

/// <summary>
/// Represents a product in the catalog with all its attributes.
/// </summary>
[Table("PIM_Hierarchy")]
public class ProductHierarchy
{
    /// <summary>
    /// Gets or sets the unique identifier for this product article.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("ID")]
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the label of the product.
    /// </summary>
    [JsonPropertyName("Label")]
    public string? Label { get; set; }

    /// <summary>
    /// Sets the list of products associated with this productResponseObject.
    /// </summary>
    [JsonPropertyName("Products")]
    [NotMapped]
    public List<ProductHierarchy>? Products { get; set; }
}