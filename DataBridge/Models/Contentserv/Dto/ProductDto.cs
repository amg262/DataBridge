using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataBridge.Models.Contentserv.Dto;

/// <summary>
/// Represents the response object for the product hierarchy.
/// </summary>
public class ProductRootDto
{
    /// <summary>
    /// Gets or sets the root productResponseObject of the response.
    /// </summary>
    [JsonPropertyName("Product")]
    public ProductDto? RootProduct { get; set; }
}

/// <summary>
/// Represents a product in the catalog with all its attributes.
/// </summary>
/// <remarks>
/// The Product class uses both JsonPropertyName and Column attributes for several reasons:
/// 
/// 1. JSON Deserialization: The JsonPropertyName attributes are used to map incoming JSON data 
///    to the corresponding properties in this class. This allows for flexibility in the naming 
///    of JSON fields without changing the C# property names.
/// 
/// 2. Database Mapping: The Column attributes are used to map properties to database columns. 
///    In some cases, the column names in the database differ from both the JSON property names 
///    and the C# property names.
/// 
/// 3. Normalization Process: The NormalizeHeader method is used to process incoming header names. 
///    It removes "(filter)" suffixes, splits on '#' and removes spaces. This normalization 
///    allows for more flexible matching between incoming data and the properties in this class.
/// 
/// 4. Mismatch Handling: In cases where the normalized header name doesn't match the C# property name, 
///    the Column attribute is used to ensure correct mapping to the database. For example:
///    - JSON: "ColorFilter" -> Normalized: "Color" -> C# Property: "ColorFilter" -> DB Column: "ColorFilter"
///    - JSON: "InsideDiameter" -> Normalized: "InsideDiameter" -> C# Property: "InsideDiameter" -> DB Column: "InsideDiameterFilter"
/// 
/// 5. Consistency: The Column attributes ensure that even if the normalization process or JSON property names 
///    change, the mapping to the database remains consistent.
/// 
/// This approach allows for flexibility in handling various data sources (JSON, CSV headers, etc.) 
/// while maintaining a consistent mapping to the database schema. It's important to note that any changes 
/// to the normalization process or attribute names should be carefully considered to avoid breaking 
/// existing data mappings.
/// </remarks>
public record ProductDto
{
    /// <summary>
    /// Gets or sets the unique identifier for this product article.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("PdmarticleID")]
    [Column("ID")]
    [Display(Name = "ID")]
    public int PdmarticleID { get; set; }

    // /// <summary>
    // /// Gets or sets the import action for this product.
    // /// </summary>
    // [JsonPropertyName("_ImportAction")]
    // public string? ImportAction { get; set; }

    /// <summary>
    /// Gets or sets the tree sort order for this product.
    /// </summary>
    [JsonPropertyName("TreeSort")]
    public string? TreeSort { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the product this is a copy of, if applicable.
    /// </summary>
    [JsonPropertyName("CopyOf")]
    public int? CopyOf { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the parent product, if any.
    /// </summary>
    [JsonPropertyName("ParentID")]
    public int? ParentID { get; set; }

    /// <summary>
    /// Gets or sets the hierarchical path of the product in the tree structure.
    /// </summary>
    [JsonPropertyName("TreePath")]
    public string? TreePath { get; set; }

    /// <summary>
    /// Represents the first level in the product hierarchy.
    /// </summary>
    [JsonPropertyName("Dimension1")]
    public int? Dimension1 { get; set; }

    /// <summary>
    /// Represents the second level in the product hierarchy.
    /// </summary>
    [JsonPropertyName("Dimension2")]
    public int? Dimension2 { get; set; }

    /// <summary>
    /// Represents the third level in the product hierarchy.
    /// </summary>
    /// <remarks>
    /// This property is populated by parsing the TreePath.
    /// It will be null if the TreePath doesn't contain at least three values.
    /// </remarks>
    [JsonPropertyName("Dimension3")]
    public int? Dimension3 { get; set; }

    /// <summary>
    /// Represents the fourth level in the product hierarchy.
    /// </summary>
    /// <remarks>
    /// This property is populated by parsing the TreePath.
    /// It will be null if the TreePath doesn't contain at least four values.
    /// </remarks>
    [JsonPropertyName("Dimension4")]
    public int? Dimension4 { get; set; }

    /// <summary>
    /// Represents the fifth level in the product hierarchy.
    /// </summary>
    /// <remarks>
    /// This property is populated by parsing the TreePath.
    /// It will be null if the TreePath doesn't contain at least five values.
    /// </remarks>
    [JsonPropertyName("Dimension5")]
    public int? Dimension5 { get; set; }

    /// <summary>
    /// Represents the sixth level in the product hierarchy.
    /// </summary>
    /// <remarks>
    /// This property is populated by parsing the TreePath.
    /// It will be null if the TreePath doesn't contain six values.
    /// </remarks>
    [JsonPropertyName("Dimension6")]
    public int? Dimension6 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is a folder.
    /// </summary>
    [JsonPropertyName("IsFolder")]
    public int? IsFolder { get; set; }

    /// <summary>
    /// Gets or sets the sort order of this product.
    /// </summary>
    [JsonPropertyName("SortOrder")]
    public int? SortOrder { get; set; }

    /// <summary>
    /// Gets or sets the object type template identifier.
    /// </summary>
    [JsonPropertyName("ObjecttypetemplateID")]
    public int? ObjecttypetemplateID { get; set; }

    /// <summary>
    /// Gets or sets the external key for this product.
    /// </summary>
    [JsonPropertyName("ExternalKey")]
    public string? ExternalKey { get; set; }

    /// <summary>
    /// Gets or sets the owner identifier for this product.
    /// </summary>
    [JsonPropertyName("OwnerID")]
    public int? OwnerID { get; set; }

    /// <summary>
    /// Gets or sets the date from which this product is valid.
    /// </summary>
    [JsonPropertyName("ValidFrom")]
    public DateTime? ValidFrom { get; set; }

    /// <summary>
    /// Gets or sets the date until which this product is valid.
    /// </summary>
    [JsonPropertyName("ValidTo")]
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Gets or sets the progress status of this product.
    /// </summary>
    [JsonPropertyName("Progress")]
    public int? Progress { get; set; }

    /// <summary>
    /// Gets or sets the tags associated with this product.
    /// </summary>
    [JsonPropertyName("Tags")]
    public string? Tags { get; set; }

    /// <summary>
    /// Gets or sets the object type identifier.
    /// </summary>
    [JsonPropertyName("ObjecttypeID")]
    public int? ObjecttypeID { get; set; }

    /// <summary>
    /// Gets or sets the cloud stream identifier.
    /// </summary>
    [JsonPropertyName("CloudStreamID")]
    public string? CloudStreamID { get; set; }

    /// <summary>
    /// Gets or sets the language identifier.
    /// </summary>
    [JsonPropertyName("LanguageID")]
    public int? LanguageID { get; set; }

    /// <summary>
    /// Gets or sets the rule status.
    /// </summary>
    [JsonPropertyName("RuleStatus")]
    public int? RuleStatus { get; set; }

    /// <summary>
    /// Gets or sets the label of the product.
    /// </summary>
    [JsonPropertyName("Label")]
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the state identifier.
    /// </summary>
    [JsonPropertyName("StateID")]
    public int? StateID { get; set; }

    /// <summary>
    /// Gets or sets the product article configuration identifier.
    /// </summary>
    [JsonPropertyName("PdmarticleconfigurationID")]
    public int? PdmarticleconfigurationID { get; set; }

    /// <summary>
    /// Gets or sets the class mapping string.
    /// </summary>
    /// <remarks>
    /// This property represents a comma-separated list of class IDs.
    /// The string can contain up to 5 integer values.
    /// Example: "30,28,7056,123,456"
    /// 
    /// This raw string is parsed by the ParseClassMappings method to populate 
    /// the individual ClassId properties.
    /// </remarks>
    [JsonPropertyName("ClassMapping")]
    public string? ClassMapping { get; set; }

    /// <summary>
    /// Gets the first class ID parsed from the ClassMapping string.
    /// </summary>
    /// <remarks>
    /// This property is set by the ParseClassMappings method.
    /// It will be null if the ClassMapping string is empty or doesn't contain any values.
    /// </remarks>
    [JsonPropertyName("ClassId1")]
    public int? ClassId1 { get; private set; }

    /// <summary>
    /// Gets the second class ID parsed from the ClassMapping string.
    /// </summary>
    /// <remarks>
    /// This property is set by the ParseClassMappings method.
    /// It will be null if the ClassMapping string contains fewer than 2 values.
    /// </remarks>
    [JsonPropertyName("ClassId2")]
    public int? ClassId2 { get; private set; }

    /// <summary>
    /// Gets the third class ID parsed from the ClassMapping string.
    /// </summary>
    /// <remarks>
    /// This property is set by the ParseClassMappings method.
    /// It will be null if the ClassMapping string contains fewer than 3 values.
    /// </remarks>
    [JsonPropertyName("ClassId3")]
    public int? ClassId3 { get; private set; }

    /// <summary>
    /// Gets the fourth class ID parsed from the ClassMapping string.
    /// </summary>
    /// <remarks>
    /// This property is set by the ParseClassMappings method.
    /// It will be null if the ClassMapping string contains fewer than 4 values.
    /// </remarks>
    [JsonPropertyName("ClassId4")]
    public int? ClassId4 { get; private set; }

    /// <summary>
    /// Gets the fifth class ID parsed from the ClassMapping string.
    /// </summary>
    /// <remarks>
    /// This property is set by the ParseClassMappings method.
    /// It will be null if the ClassMapping string contains fewer than 5 values.
    /// </remarks>
    [JsonPropertyName("ClassId5")]
    public int? ClassId5 { get; private set; }

    /// <summary>
    /// Gets or sets the overview of the product.
    /// </summary>
    [JsonPropertyName("Overview")]
    public string? Overview { get; set; }

    /// <summary>
    /// Gets or sets the reference item ID.
    /// </summary>
    [JsonPropertyName("RefItemID")]
    public string? RefItemID { get; set; }

    /// <summary>
    /// Gets or sets the additional categories.
    /// </summary>
    [JsonPropertyName("AdditionalCategories")]
    public string? AdditionalCategories { get; set; }

    /// <summary>
    /// Gets or sets the country of origin.
    /// </summary>
    [JsonPropertyName("CountryOfOrigin")]
    public string? CountryOfOrigin { get; set; }

    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    [JsonPropertyName("DisplayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the Ellsworth markets.
    /// </summary>
    [JsonPropertyName("EllsworthMarkets")]
    public string? EllsworthMarkets { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is published.
    /// </summary>
    [JsonPropertyName("IsPublished")]
    public int? IsPublished { get; set; }

    /// <summary>
    /// Gets or sets the marketing description.
    /// </summary>
    [JsonPropertyName("MarketingDescription")]
    public string? MarketingDescription { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the name in URL.
    /// </summary>
    [JsonPropertyName("NameInURL")]
    public string? NameInURL { get; set; }

    /// <summary>
    /// Gets or sets the primary category.
    /// </summary>
    [JsonPropertyName("PrimaryCategory")]
    public string? PrimaryCategory { get; set; }

    /// <summary>
    /// Gets or sets the products, packages and bundles.
    /// </summary>
    [JsonPropertyName("ProductsPackagesAndBundles")]
    public string? ProductsPackagesAndBundles { get; set; }

    /// <summary>
    /// Gets or sets the SEO URL.
    /// </summary>
    [JsonPropertyName("SEOURL")]
    public string? SEOURL { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is web discontinued.
    /// </summary>
    [JsonPropertyName("WebDiscontinued")]
    public int? WebDiscontinued { get; set; }

    /// <summary>
    /// Gets or sets the class 4 description.
    /// </summary>
    [JsonPropertyName("Class4Description")]
    public string? Class4Description { get; set; }

    /// <summary>
    /// Gets or sets the conflict minerals status.
    /// </summary>
    [JsonPropertyName("ConflictMinerals")]
    public string? ConflictMinerals { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a hazardous item.
    /// </summary>
    [JsonPropertyName("HazardousItem")]
    public string? HazardousItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a limited quantity item.
    /// </summary>
    [JsonPropertyName("LimitedQtyItem")]
    public string? LimitedQtyItem { get; set; }

    /// <summary>
    /// Gets or sets the SDS document title.
    /// </summary>
    [JsonPropertyName("SDSDocumentTitle")]
    public string? SDSDocumentTitle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this item ships ambient.
    /// </summary>
    [JsonPropertyName("ShipsAmbient")]
    public int? ShipsAmbient { get; set; }

    /// <summary>
    /// Gets or sets the TDS document title.
    /// </summary>
    [JsonPropertyName("TDSDocumentTitle")]
    public string? TDSDocumentTitle { get; set; }

    /// <summary>
    /// Gets or sets the brand of the product.
    /// </summary>
    [JsonPropertyName("Brand")]
    public string? Brand { get; set; }

    /// <summary>
    /// Gets or sets the exclusivity status.
    /// </summary>
    [JsonPropertyName("Exclusivity")]
    public string? Exclusivity { get; set; }

    /// <summary>
    /// Gets or sets the code of the product.
    /// </summary>
    [JsonPropertyName("Code")]
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the item description.
    /// </summary>
    [JsonPropertyName("ItemDescription")]
    public string? ItemDescription { get; set; }

    /// <summary>
    /// Gets or sets the item ID.
    /// </summary>
    [JsonPropertyName("ItemID")]
    public string? ItemID { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer.
    /// </summary>
    [JsonPropertyName("Manufacturer")]
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer ID.
    /// </summary>
    [JsonPropertyName("ManufacturerId")]
    public string? ManufacturerId { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer part number.
    /// </summary>
    [JsonPropertyName("ManufacturerPN")]
    public string? ManufacturerPN { get; set; }

    /// <summary>
    /// Gets or sets the UID company.
    /// </summary>
    [JsonPropertyName("UID_Company")]
    public string? UID_Company { get; set; }

    /// <summary>
    /// Gets or sets the web manufacturer part number.
    /// </summary>
    [JsonPropertyName("WebManufacturerPartNumber")]
    public string? WebManufacturerPartNumber { get; set; }

    /// <summary>
    /// Gets or sets the standard cost.
    /// </summary>
    [JsonPropertyName("StandardCost")]
    public decimal StandardCost { get; set; }

    /// <summary>
    /// Gets or sets the supplier cost.
    /// </summary>
    [JsonPropertyName("SupplierCost")]
    public decimal SupplierCost { get; set; }

    /// <summary>
    /// Gets or sets the column price 1.
    /// </summary>
    [JsonPropertyName("ColumnPrice1")]
    public decimal ColumnPrice1 { get; set; }

    /// <summary>
    /// Gets or sets the column price 2.
    /// </summary>
    [JsonPropertyName("ColumnPrice2")]
    public decimal ColumnPrice2 { get; set; }

    /// <summary>
    /// Gets or sets the column price 3.
    /// </summary>
    [JsonPropertyName("ColumnPrice3")]
    public decimal ColumnPrice3 { get; set; }

    /// <summary>
    /// Gets or sets the MSRP.
    /// </summary>
    [JsonPropertyName("MSRP")]
    public decimal MSRP { get; set; }

    /// <summary>
    /// Gets or sets the broken case standard cost.
    /// </summary>
    [JsonPropertyName("BrokenCaseStandardCost")]
    public decimal BrokenCaseStandardCost { get; set; }

    /// <summary>
    /// Gets or sets the reseller price.
    /// </summary>
    [JsonPropertyName("ResellerPrice")]
    public decimal ResellerPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to confirm cost.
    /// </summary>
    [JsonPropertyName("ConfirmCostCheckbox")]
    public string? ConfirmCostCheckbox { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display pricing.
    /// </summary>
    [JsonPropertyName("DisplayPricing")]
    public int? DisplayPricing { get; set; }

    /// <summary>
    /// Gets or sets the display pricing content area.
    /// </summary>
    [JsonPropertyName("DisplayPricingContentArea")]
    public string? DisplayPricingContentArea { get; set; }

    /// <summary>
    /// Gets or sets the display pricing message.
    /// </summary>
    [JsonPropertyName("DisplayPricingMessage")]
    public string? DisplayPricingMessage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is stocked.
    /// </summary>
    [JsonPropertyName("IsStocked")]
    public int? IsStocked { get; set; }

    /// <summary>
    /// Gets or sets the minimum quantity.
    /// </summary>
    [JsonPropertyName("MinQuantity")]
    public int? MinQuantity { get; set; }

    /// <summary>
    /// Gets or sets the maximum quantity.
    /// </summary>
    [JsonPropertyName("MaxQuantity")]
    public int? MaxQuantity { get; set; }

    /// <summary>
    /// Gets or sets the P21 sales unit per package.
    /// </summary>
    [JsonPropertyName("P21SalesUnitPerPackage")]
    public int? P21SalesUnitPerPackage { get; set; }

    /// <summary>
    /// Gets or sets the quote expiration date.
    /// </summary>
    [JsonPropertyName("QuoteExpirationDate")]
    public string? QuoteExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets how the product is sold.
    /// </summary>
    [JsonPropertyName("SoldAs")]
    public string? SoldAs { get; set; }

    /// <summary>
    /// Gets or sets the applicator type.
    /// </summary>
    [JsonPropertyName("ApplicatorType")]
    public string? ApplicatorType { get; set; }

    /// <summary>
    /// Gets or sets the cartridge capacity.
    /// </summary>
    [JsonPropertyName("CartridgeCapacity")]
    public string? CartridgeCapacity { get; set; }

    /// <summary>
    /// Gets or sets the chemical composition.
    /// </summary>
    [JsonPropertyName("ChemicalComposition")]
    public string? ChemicalComposition { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    [JsonPropertyName("Color")]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the color filter.
    /// </summary>
    [JsonPropertyName("ColorFilter")]
    [Column("ColorFilter")]
    public string? ColorFilter { get; set; }

    /// <summary>
    /// Gets or sets the sales unit of measure.
    /// </summary>
    [JsonPropertyName("SalesUOM")]
    public string? SalesUOM { get; set; }

    /// <summary>
    /// Gets or sets the multiple value.
    /// </summary>
    [JsonPropertyName("Multiple")]
    public string? Multiple { get; set; }

    /// <summary>
    /// Gets or sets the purchasing unit of measure.
    /// </summary>
    [JsonPropertyName("PurchasingUOM")]
    public string? PurchasingUOM { get; set; }

    /// <summary>
    /// Gets or sets the base unit of measure.
    /// </summary>
    [JsonPropertyName("BaseUOM")]
    public string? BaseUOM { get; set; }

    /// <summary>
    /// Gets or sets the components.
    /// </summary>
    [JsonPropertyName("Components")]
    public string? Components { get; set; }

    /// <summary>
    /// Gets or sets the descriptive size.
    /// </summary>
    [JsonPropertyName("DescriptiveSize")]
    public string? DescriptiveSize { get; set; }

    /// <summary>
    /// Gets or sets the dispensing valve type.
    /// </summary>
    [JsonPropertyName("DispensingValveType")]
    public string? DispensingValveType { get; set; }

    /// <summary>
    /// Gets or sets the elements.
    /// </summary>
    [JsonPropertyName("Elements")]
    public string? Elements { get; set; }

    /// <summary>
    /// Gets or sets the feed power.
    /// </summary>
    [JsonPropertyName("FeedPower")]
    public string? FeedPower { get; set; }

    /// <summary>
    /// Gets or sets the inside diameter (filter).
    /// </summary>
    [JsonPropertyName("InsideDiameter")]
    [Column("InsideDiameterFilter")]
    public string? InsideDiameter { get; set; }

    /// <summary>
    /// Gets or sets the key specifications.
    /// </summary>
    [JsonPropertyName("KeySpecifications")]
    public string? KeySpecifications { get; set; }

    /// <summary>
    /// Gets or sets the length (filter).
    /// </summary>
    [JsonPropertyName("Length")]
    [Column("LengthFilter")]
    public string? Length { get; set; }

    /// <summary>
    /// Gets or sets the size 1.
    /// </summary>
    [JsonPropertyName("Size1")]
    public string? Size1 { get; set; }

    /// <summary>
    /// Gets or sets the size unit 1.
    /// </summary>
    [JsonPropertyName("SizeUnit1")]
    public string? SizeUnit1 { get; set; }

    /// <summary>
    /// Gets or sets the size 2.
    /// </summary>
    [JsonPropertyName("Size2")]
    public string? Size2 { get; set; }

    /// <summary>
    /// Gets or sets the size unit 2.
    /// </summary>
    [JsonPropertyName("SizeUnit2")]
    public string? SizeUnit2 { get; set; }

    /// <summary>
    /// Gets or sets the size 3.
    /// </summary>
    [JsonPropertyName("Size3")]
    public string? Size3 { get; set; }

    /// <summary>
    /// Gets or sets the size unit 3.
    /// </summary>
    [JsonPropertyName("SizeUnit3")]
    public string? SizeUnit3 { get; set; }

    /// <summary>
    /// Gets or sets the special information.
    /// </summary>
    [JsonPropertyName("SpecialInformation")]
    public string? SpecialInformation { get; set; }

    /// <summary>
    /// Gets or sets the tapered (filter) information.
    /// </summary>
    [JsonPropertyName("Tapered")]
    [Column("TaperedFilter")]
    public string? Tapered { get; set; }

    /// <summary>
    /// Gets or sets the typical use.
    /// </summary>
    [JsonPropertyName("TypicalUse")]
    public string? TypicalUse { get; set; }

    /// <summary>
    /// Gets or sets the working time.
    /// </summary>
    [JsonPropertyName("WorkingTime")]
    public string? WorkingTime { get; set; }

    /// <summary>
    /// Gets or sets the related entries.
    /// </summary>
    [JsonPropertyName("RelatedEntries")]
    public string? RelatedEntries { get; set; }

    /// <summary>
    /// Gets or sets the container/package information.
    /// </summary>
    [JsonPropertyName("ContainerPackage")]
    public string? ContainerPackage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is non-returnable.
    /// </summary>
    [JsonPropertyName("NonReturnableCheckbox")]
    public string? NonReturnableCheckbox { get; set; }

    /// <summary>
    /// Gets or sets the shipping note.
    /// </summary>
    [JsonPropertyName("ShippingNote")]
    public string? ShippingNote { get; set; }

    /// <summary>
    /// Gets or sets the shipping restrictions.
    /// </summary>
    [JsonPropertyName("ShippingRestrictions")]
    public string? ShippingRestrictions { get; set; }

    /// <summary>
    /// Gets or sets the weight.
    /// </summary>
    [JsonPropertyName("Weight")]
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the Zoro brand.
    /// </summary>
    [JsonPropertyName("ZoroBrand")]
    public string? ZoroBrand { get; set; }

    /// <summary>
    /// Gets or sets the Zoro country of origin.
    /// </summary>
    [JsonPropertyName("ZoroCountryOfOrigin")]
    public string? ZoroCountryOfOrigin { get; set; }

    /// <summary>
    /// Gets or sets the Zoro unknown country of origin.
    /// </summary>
    [JsonPropertyName("ZoroUnknownCountryOfOrigin")]
    public string? ZoroUnknownCountryOfOrigin { get; set; }

    /// <summary>
    /// Gets or sets the Zoro California Prop 65 warning icon.
    /// </summary>
    [JsonPropertyName("ZoroCaliforniaProp65WarningIcon")]
    public string? ZoroCaliforniaProp65WarningIcon { get; set; }

    /// <summary>
    /// Gets or sets the Zoro order lead time.
    /// </summary>
    [JsonPropertyName("ZoroOrderLeadTime")]
    public string? ZoroOrderLeadTime { get; set; }

    /// <summary>
    /// Gets or sets the class 5 description.
    /// </summary>
    [JsonPropertyName("Class5Description")]
    public string? Class5Description { get; set; }

    /// <summary>
    /// Gets or sets the classification.
    /// </summary>
    [JsonPropertyName("Classification")]
    public string? Classification { get; set; }

    /// <summary>
    /// Gets or sets the company.
    /// </summary>
    [JsonPropertyName("Company")]
    public string? Company { get; set; }

    /// <summary>
    /// Gets or sets the container/package ID.
    /// </summary>
    [JsonPropertyName("ContainerPackageId")]
    public string? ContainerPackageId { get; set; }

    /// <summary>
    /// Gets or sets the date last modified.
    /// </summary>
    [JsonPropertyName("DateLastModified")]
    public DateTime? DateLastModified { get; set; }

    /// <summary>
    /// Gets or sets the HTS classification.
    /// </summary>
    [JsonPropertyName("HTSClassification")]
    public string? HTSClassification { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is discontinued.
    /// </summary>
    [JsonPropertyName("DiscontinuedCheckbox")]
    public string? DiscontinuedCheckbox { get; set; }

    /// <summary>
    /// Gets or sets the origin criterion.
    /// </summary>
    [JsonPropertyName("OriginCriterion")]
    public string? OriginCriterion { get; set; }

    /// <summary>
    /// Gets or sets the drop ship restriction.
    /// </summary>
    [JsonPropertyName("DropShipRestriction")]
    public string? DropShipRestriction { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is an ePlus item.
    /// </summary>
    [JsonPropertyName("EPlusCheckbox")]
    public string? EPlusCheckbox { get; set; }

    /// <summary>
    /// Gets or sets the force majeure status.
    /// </summary>
    [JsonPropertyName("ForceMajeure")]
    public string? ForceMajeure { get; set; }

    /// <summary>
    /// Gets or sets the gross weight.
    /// </summary>
    [JsonPropertyName("GrossWeight")]
    public decimal GrossWeight { get; set; }

    /// <summary>
    /// Gets or sets the supplier ID (primary).
    /// </summary>
    [JsonPropertyName("SupplierIDPrimary")]
    public string? SupplierIDPrimary { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is an IMP item.
    /// </summary>
    [JsonPropertyName("IMPCheckbox")]
    public string? IMPCheckbox { get; set; }

    /// <summary>
    /// Gets or sets the supplier name.
    /// </summary>
    [JsonPropertyName("SupplierName")]
    public string? SupplierName { get; set; }

    /// <summary>
    /// Gets or sets the technical data.
    /// </summary>
    [JsonPropertyName("TechnicalData")]
    public string? TechnicalData { get; set; }

    /// <summary>
    /// Gets or sets the lead time in days.
    /// </summary>
    [JsonPropertyName("LeadTimeDays")]
    public int? LeadTimeDays { get; set; }

    /// <summary>
    /// Gets or sets the location ID.
    /// </summary>
    [JsonPropertyName("LocationId")]
    public string? LocationId { get; set; }

    /// <summary>
    /// Gets or sets the location MOQ.
    /// </summary>
    [JsonPropertyName("LocationMOQ")]
    public int? LocationMOQ { get; set; }

    /// <summary>
    /// Gets or sets the location stocking status.
    /// </summary>
    [JsonPropertyName("LocationStockingStatus")]
    public string? LocationStockingStatus { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a stock per item.
    /// </summary>
    [JsonPropertyName("StockPerCheckbox")]
    public string? StockPerCheckbox { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a supplier non-stock item.
    /// </summary>
    [JsonPropertyName("SupplierNonStockCheckbox")]
    public string? SupplierNonStockCheckbox { get; set; }

    /// <summary>
    /// Gets or sets the supplier part number.
    /// </summary>
    [JsonPropertyName("SupplierPartNumber")]
    public string? SupplierPartNumber { get; set; }

    /// <summary>
    /// Gets or sets the UID.
    /// </summary>
    [JsonPropertyName("UID")]
    public string? UID { get; set; }

    /// <summary>
    /// Gets or sets the US supplier information ID.
    /// </summary>
    [JsonPropertyName("USSupplierInformationID")]
    public string? USSupplierInformationID { get; set; }

    /// <summary>
    /// Gets or sets the US supplier information name.
    /// </summary>
    [JsonPropertyName("USSupplierInformationName")]
    public string? USSupplierInformationName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a variable size item.
    /// </summary>
    [JsonPropertyName("VariableSizeItemCheckbox")]
    public string? VariableSizeItemCheckbox { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a yield item.
    /// </summary>
    [JsonPropertyName("YieldItem")]
    public string? YieldItem { get; set; }

    /// <summary>
    /// Gets or sets the item image.
    /// </summary>
    [JsonPropertyName("ItemImage")]
    public string? ItemImage { get; set; }

    /// <summary>
    /// Gets or sets the SDS.
    /// </summary>
    [JsonPropertyName("SDS")]
    public string? SDS { get; set; }

    /// <summary>
    /// Gets or sets the item literature.
    /// </summary>
    [JsonPropertyName("ItemLiterature")]
    public string? ItemLiterature { get; set; }

    /// <summary>
    /// Gets or sets the item video.
    /// </summary>
    [JsonPropertyName("ItemVideo")]
    public string? ItemVideo { get; set; }

    /// <summary>
    /// Gets or sets the GHS hazard icon.
    /// </summary>
    [JsonPropertyName("GHSHazardIcon")]
    public string? GHSHazardIcon { get; set; }

    /// <summary>
    /// Gets or sets the must ship air icon.
    /// </summary>
    [JsonPropertyName("MustShipAirIcon")]
    public string? MustShipAirIcon { get; set; }

    /// <summary>
    /// Gets or sets the time and temp sensitive icon.
    /// </summary>
    [JsonPropertyName("TimeAndTempSensitiveIcon")]
    public string? TimeAndTempSensitiveIcon { get; set; }

    /// <summary>
    /// Gets or sets the state sales restriction icon.
    /// </summary>
    [JsonPropertyName("StateSalesRestrictionIcon")]
    public string? StateSalesRestrictionIcon { get; set; }

    /// <summary>
    /// Gets or sets the California sales restriction icon.
    /// </summary>
    [JsonPropertyName("CaliforniaSalesRestrictionIcon")]
    public string? CaliforniaSalesRestrictionIcon { get; set; }

    /// <summary>
    /// Gets or sets the low VOC icon.
    /// </summary>
    [JsonPropertyName("LowVOCIcon")]
    public string? LowVOCIcon { get; set; }

    /// <summary>
    /// Gets or sets the Made In USA icon.
    /// </summary>
    [JsonPropertyName("MadeInUSAIcon")]
    public string? MadeInUSAIcon { get; set; }

    /// <summary>
    /// Gets or sets the California Prop 65 Warning icon.
    /// </summary>
    [JsonPropertyName("CaliforniaProp65WarningIcon")]
    public string? CaliforniaProp65WarningIcon { get; set; }

    /// <summary>
    /// Gets or sets the Sales Restriction icon.
    /// </summary>
    [JsonPropertyName("SalesRestrictionIcon")]
    public string? SalesRestrictionIcon { get; set; }

    /// <summary>
    /// Gets or sets the Google ProductResponseObject Category.
    /// </summary>
    [JsonPropertyName("GoogleProductCategory")]
    public string? GoogleProductCategory { get; set; }

    /// <summary>
    /// Gets or sets the Google Pause status.
    /// </summary>
    [JsonPropertyName("GooglePause")]
    public string? GooglePause { get; set; }

    /// <summary>
    /// Gets or sets the Google Multipack information.
    /// </summary>
    [JsonPropertyName("GoogleMultipack")]
    public string? GoogleMultipack { get; set; }

    /// <summary>
    /// Gets or sets the Google Bundle information.
    /// </summary>
    [JsonPropertyName("GoogleBundle")]
    public string? GoogleBundle { get; set; }

    /// <summary>
    /// Gets or sets the Google Shopping information.
    /// </summary>
    [JsonPropertyName("GoogleShopping")]
    public string? GoogleShopping { get; set; }

    /// <summary>
    /// Gets or sets the Google Excluded Destination.
    /// </summary>
    [JsonPropertyName("GoogleExcludedDestination")]
    public string? GoogleExcludedDestination { get; set; }

    /// <summary>
    /// Gets or sets the Google Excluded Country.
    /// </summary>
    [JsonPropertyName("GoogleExcludedCountry")]
    public string? GoogleExcludedCountry { get; set; }

    /// <summary>
    /// Gets or sets the Google Shipping information.
    /// </summary>
    [JsonPropertyName("GoogleShipping")]
    public string? GoogleShipping { get; set; }

    /// <summary>
    /// Gets or sets the Smart Preset.
    /// </summary>
    [JsonPropertyName("SmartPreset")]
    public string? SmartPreset { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item should not freeze.
    /// </summary>
    [JsonPropertyName("DoNotFreeze")]
    public string? DoNotFreeze { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a dry ice item.
    /// </summary>
    [JsonPropertyName("DryIceItem")]
    public string? DryIceItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a frozen item.
    /// </summary>
    [JsonPropertyName("FrozenItem")]
    public string? FrozenItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is an ice brix item.
    /// </summary>
    [JsonPropertyName("IceBrixItem")]
    public string? IceBrixItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a minus 20F item.
    /// </summary>
    [JsonPropertyName("Minus20FItem")]
    public string? Minus20FItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a minus 40F item.
    /// </summary>
    [JsonPropertyName("Minus40FItem")]
    public string? Minus40FItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a refrigerated item.
    /// </summary>
    [JsonPropertyName("RefrigeratedItem")]
    public string? RefrigeratedItem { get; set; }

    /// <summary>
    /// Gets or sets the backing type (filter).
    /// </summary>
    [JsonPropertyName("BackingType")]
    [Column("BackingTypeFilter")]
    public string? BackingType { get; set; }

    /// <summary>
    /// Gets or sets the cure system.
    /// </summary>
    [JsonPropertyName("CureSystem")]
    public string? CureSystem { get; set; }

    /// <summary>
    /// Gets or sets the cure system 2.
    /// </summary>
    [JsonPropertyName("CureSystem2")]
    public string? CureSystem2 { get; set; }

    /// <summary>
    /// Gets or sets the cure system 3.
    /// </summary>
    [JsonPropertyName("CureSystem3")]
    public string? CureSystem3 { get; set; }

    /// <summary>
    /// Gets or sets the cure time.
    /// </summary>
    [JsonPropertyName("CureTime")]
    public string? CureTime { get; set; }

    /// <summary>
    /// Gets or sets the dielectric strength.
    /// </summary>
    [JsonPropertyName("DielectricStrength")]
    public string? DielectricStrength { get; set; }

    /// <summary>
    /// Gets or sets the elongation.
    /// </summary>
    [JsonPropertyName("Elongation")]
    public string? Elongation { get; set; }

    /// <summary>
    /// Gets or sets the flash postring.
    /// </summary>
    [JsonPropertyName("FlashPoint")]
    public string? FlashPoint { get; set; }

    /// <summary>
    /// Gets or sets the gap filling.
    /// </summary>
    [JsonPropertyName("GapFilling")]
    public string? GapFilling { get; set; }

    /// <summary>
    /// Gets or sets the hardness.
    /// </summary>
    [JsonPropertyName("Hardness")]
    public string? Hardness { get; set; }

    /// <summary>
    /// Gets or sets the impact resistance.
    /// </summary>
    [JsonPropertyName("ImpactResistance")]
    public string? ImpactResistance { get; set; }

    /// <summary>
    /// Gets or sets the mix ratio.
    /// </summary>
    [JsonPropertyName("MixRatio")]
    public string? MixRatio { get; set; }

    /// <summary>
    /// Gets or sets the peel strength.
    /// </summary>
    [JsonPropertyName("PeelStrength")]
    public string? PeelStrength { get; set; }

    /// <summary>
    /// Gets or sets the release agent type (filter).
    /// </summary>
    [JsonPropertyName("ReleaseAgentType")]
    [Column("ReleaseAgentTypeFilter")]
    public string? ReleaseAgentType { get; set; }

    /// <summary>
    /// Gets or sets the service temperature.
    /// </summary>
    [JsonPropertyName("ServiceTemperature")]
    public string? ServiceTemperature { get; set; }

    /// <summary>
    /// Gets or sets the shear strength.
    /// </summary>
    [JsonPropertyName("ShearStrength")]
    public string? ShearStrength { get; set; }

    /// <summary>
    /// Gets or sets the specific gravity.
    /// </summary>
    [JsonPropertyName("SpecificGravity")]
    public string? SpecificGravity { get; set; }

    /// <summary>
    /// Gets or sets the static bag width (filter).
    /// </summary>
    [JsonPropertyName("StaticBagWidth")]
    [Column("StaticBagWidthFilter")]

    public string? StaticBagWidth { get; set; }

    /// <summary>
    /// Gets or sets the tack (filter).
    /// </summary>
    [JsonPropertyName("Tack")]
    [Column("TackFilter")]
    public string? Tack { get; set; }

    /// <summary>
    /// Gets or sets the tack free time.
    /// </summary>
    [JsonPropertyName("TackFreeTime")]
    public string? TackFreeTime { get; set; }

    /// <summary>
    /// Gets or sets the tape width (filter).
    /// </summary>
    [JsonPropertyName("TapeWidth")]
    [Column("TapeWidthFilter")]
    public string? TapeWidth { get; set; }

    /// <summary>
    /// Gets or sets the tensile strength.
    /// </summary>
    [JsonPropertyName("TensileStrength")]
    public string? TensileStrength { get; set; }

    /// <summary>
    /// Gets or sets the thermal conductivity.
    /// </summary>
    [JsonPropertyName("ThermalConductivity")]
    public string? ThermalConductivity { get; set; }

    /// <summary>
    /// Gets or sets the viscosity.
    /// </summary>
    [JsonPropertyName("Viscosity")]
    public string? Viscosity { get; set; }

    /// <summary>
    /// Gets or sets the volume resistivity.
    /// </summary>
    [JsonPropertyName("VolumeResistivity")]
    public string? VolumeResistivity { get; set; }

    /// <summary>
    /// Gets or sets the shelf life data.
    /// </summary>
    [JsonPropertyName("ShelfLifeData")]
    public string? ShelfLifeData { get; set; }

    /// <summary>
    /// Gets or sets the dry ice / ice brix icon.
    /// </summary>
    [JsonPropertyName("DryIceIceBrixIcon")]
    public string? DryIceIceBrixIcon { get; set; }

    /// <summary>
    /// Gets or sets the hot melt stick width (filter).
    /// </summary>
    [JsonPropertyName("HotMeltStickWidth")]
    [Column("HotMeltStickWidthFilter")]
    public string? HotMeltStickWidth { get; set; }

    /// <summary>
    /// Gets or sets the hot melt type.
    /// </summary>
    [JsonPropertyName("HotMeltType")]
    public string? HotMeltType { get; set; }

    /// <summary>
    /// Gets or sets the tip angle (filter).
    /// </summary>
    [JsonPropertyName("Profile")]
    [Column("ProfileFilter")]
    public string? Profile { get; set; }

    /// <summary>
    /// Gets or sets the tip gauge (filter).
    /// </summary>
    [JsonPropertyName("SDSDocumentNumbers")]
    public string? SDSDocumentNumbers { get; set; }

    /// <summary>
    /// Gets or sets the tip material (filter).
    /// </summary>
    [JsonPropertyName("TDSDocumentNumbers")]
    public string? TDSDocumentNumbers { get; set; }

    /// <summary>
    /// Gets or sets the profile (filter).
    /// </summary>
    [JsonPropertyName("CureSystem1")]
    public string? CureSystem1 { get; set; }

    /// <summary>
    /// Gets or sets the poles or tips (filter).
    /// </summary>
    [JsonPropertyName("PolesorTips")]
    [Column("PolesorTipsFilter")]
    public string? PolesorTips { get; set; }

    /// <summary>
    /// Gets or sets the SDS document numbers.
    /// </summary>
    [JsonPropertyName("Spray")]
    [Column("SprayFilter")]
    public string? Spray { get; set; }

    /// <summary>
    /// Gets or sets the TDS document numbers.
    /// </summary>
    [JsonPropertyName("TipAngle")]
    [Column("TipAngleFilter")]
    public string? TipAngle { get; set; }

    /// <summary>
    /// Gets or sets the cure system 1.
    /// </summary>
    [JsonPropertyName("TipGauge")]
    [Column("TipGaugeFilter")]
    public string? TipGauge { get; set; }

    /// <summary>
    /// Gets or sets the spray (filter).
    /// </summary>
    [JsonPropertyName("TipMaterial")]
    [Column("TipMaterialFilter")]
    public string? TipMaterial { get; set; }

    /// <summary>
    /// Gets or sets the tip or cartridge type (filter).
    /// </summary>
    [JsonPropertyName("TiporCartridgeType")]
    [Column("TipOrCartridgeTypeFilter")]
    public string? TiporCartridgeType { get; set; }

    /// <summary>
    /// Parses the TreePath property and populates the Dimension properties.
    /// </summary>
    /// <remarks>
    /// This method extracts integer values from the TreePath string and assigns them to the corresponding Dimension properties.
    /// The TreePath is expected to be a string of integers separated by '/' characters.
    /// 
    /// Behavior:
    /// - If TreePath is null or empty, the method returns without modifying the Dimension properties.
    /// - Splits the TreePath by '/' and removes any empty entries.
    /// - Attempts to parse each segment as an integer.
    /// - Assigns up to 6 parsed integers to the corresponding Dimension properties.
    /// - If fewer than 6 dimensions are present in the TreePath, the remaining Dimension properties are set to null.
    /// 
    /// Note: This method may throw a FormatException if any segment of the TreePath cannot be parsed as an integer.
    /// 
    /// Example TreePath: "/1000/15500/15501/15502/15673/15652"
    /// </remarks>
    public void ParseTreePath()
    {
        if (string.IsNullOrEmpty(TreePath)) return;

        var dimensions = TreePath.Split("/", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Dimension1 = dimensions.Length > 0 ? dimensions[0] : null;
        Dimension2 = dimensions.Length > 1 ? dimensions[1] : null;
        Dimension3 = dimensions.Length > 2 ? dimensions[2] : null;
        Dimension4 = dimensions.Length > 3 ? dimensions[3] : null;
        Dimension5 = dimensions.Length > 4 ? dimensions[4] : null;
        Dimension6 = dimensions.Length > 5 ? dimensions[5] : null;
    }

    /// <summary>
    /// Parses the ClassMapping property and populates the ClassId properties.
    /// </summary>
    /// <remarks>
    /// This method extracts integer values from the ClassMapping string and assigns them to the corresponding ClassId properties.
    /// The ClassMapping is expected to be a string of integers separated by ',' characters.
    /// 
    /// Behavior:
    /// - If ClassMapping is null or empty, the method returns without modifying the ClassId properties.
    /// - Splits the ClassMapping by ',' and removes any empty entries.
    /// - Attempts to parse each segment as an integer.
    /// - Assigns up to 5 parsed integers to the corresponding ClassId properties.
    /// - If fewer than 5 class IDs are present in the ClassMapping, the remaining ClassId properties are set to null.
    /// 
    /// Note: This method may throw a FormatException if any segment of the ClassMapping cannot be parsed as an integer.
    /// 
    /// Example ClassMapping: "30,28,7056,29"
    /// </remarks>
    /// <exception cref="FormatException">Thrown when a segment in the ClassMapping cannot be parsed as an integer.</exception>
    public void ParseClassMappings()
    {
        if (string.IsNullOrEmpty(ClassMapping)) return;

        var mappings = ClassMapping.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        ClassId1 = mappings.Length > 0 ? mappings[0] : null;
        ClassId2 = mappings.Length > 1 ? mappings[1] : null;
        ClassId3 = mappings.Length > 2 ? mappings[2] : null;
        ClassId4 = mappings.Length > 3 ? mappings[3] : null;
        ClassId5 = mappings.Length > 4 ? mappings[4] : null;
    }
}