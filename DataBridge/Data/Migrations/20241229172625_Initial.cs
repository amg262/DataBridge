using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBridge.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DelivraClickthroughs",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    MailingID = table.Column<int>(type: "int", nullable: true),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    URI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivraClickthroughs", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "DelivraMailingApprovals",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageID = table.Column<int>(type: "int", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderAll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderFromSpc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    List = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxRecips = table.Column<int>(type: "int", nullable: true),
                    ReSubmit = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsetID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishOnSend = table.Column<bool>(type: "bit", nullable: true),
                    FacebookPost = table.Column<bool>(type: "bit", nullable: true),
                    TwitterTweet = table.Column<bool>(type: "bit", nullable: true),
                    LinkedInPost = table.Column<bool>(type: "bit", nullable: true),
                    TimeZoneSend = table.Column<bool>(type: "bit", nullable: true),
                    SendTimeOptimize = table.Column<bool>(type: "bit", nullable: true),
                    SendFrequencyOverride = table.Column<bool>(type: "bit", nullable: true),
                    Footer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivraMailingApprovals", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "DelivraOpens",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MailingID = table.Column<int>(type: "int", nullable: true),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEngagement = table.Column<double>(type: "float", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingEnvironment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivraOpens", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "DelivraReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: true),
                    Paused = table.Column<int>(type: "int", nullable: true),
                    Mailed = table.Column<int>(type: "int", nullable: true),
                    Received = table.Column<int>(type: "int", nullable: true),
                    Opens = table.Column<int>(type: "int", nullable: true),
                    TotalClicks = table.Column<int>(type: "int", nullable: true),
                    UniqueClicks = table.Column<int>(type: "int", nullable: true),
                    Trans = table.Column<int>(type: "int", nullable: true),
                    TransAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoftFails = table.Column<int>(type: "int", nullable: true),
                    HardFails = table.Column<int>(type: "int", nullable: true),
                    PermFails = table.Column<int>(type: "int", nullable: true),
                    DnsTemps = table.Column<int>(type: "int", nullable: true),
                    BadDoms = table.Column<int>(type: "int", nullable: true),
                    Bounces = table.Column<int>(type: "int", nullable: true),
                    Invalids = table.Column<int>(type: "int", nullable: true),
                    MesMissings = table.Column<int>(type: "int", nullable: true),
                    Expirations = table.Column<int>(type: "int", nullable: true),
                    Skips = table.Column<int>(type: "int", nullable: true),
                    Aborts = table.Column<int>(type: "int", nullable: true),
                    Unsubs = table.Column<int>(type: "int", nullable: true),
                    Forwards = table.Column<int>(type: "int", nullable: true),
                    Referrals = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InmailBodySize = table.Column<int>(type: "int", nullable: true),
                    SubsetID = table.Column<int>(type: "int", nullable: true),
                    InmailHdrFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutmailFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    List = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutmailTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueOpens = table.Column<int>(type: "int", nullable: true),
                    UniqueTrans = table.Column<int>(type: "int", nullable: true),
                    Units = table.Column<int>(type: "int", nullable: true),
                    Streams = table.Column<int>(type: "int", nullable: true),
                    UniqueStreams = table.Column<int>(type: "int", nullable: true),
                    Engagement = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Complaints = table.Column<int>(type: "int", nullable: true),
                    Attempted = table.Column<int>(type: "int", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SocialShares = table.Column<int>(type: "int", nullable: true),
                    SocialImpressions = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileOpens = table.Column<int>(type: "int", nullable: true),
                    WebOpens = table.Column<int>(type: "int", nullable: true),
                    DesktopOpens = table.Column<int>(type: "int", nullable: true),
                    UnknownOpens = table.Column<int>(type: "int", nullable: true),
                    UniqueMobileOpens = table.Column<int>(type: "int", nullable: true),
                    UniqueWebOpens = table.Column<int>(type: "int", nullable: true),
                    UniqueDesktopOpens = table.Column<int>(type: "int", nullable: true),
                    UniqueUnknownOpens = table.Column<int>(type: "int", nullable: true),
                    IsTriggered = table.Column<bool>(type: "bit", nullable: true),
                    ModerateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivraReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DelivraSegments",
                columns: table => new
                {
                    SegmentID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    List = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectoryID = table.Column<int>(type: "int", nullable: true),
                    LastUsedRecipientCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivraSegments", x => x.SegmentID);
                });

            migrationBuilder.CreateTable(
                name: "DelivraSends",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    MailingID = table.Column<int>(type: "int", nullable: true),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivraSends", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "LP_Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CampaignEngagementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignEngagementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngagementSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorBehaviorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorBehaviorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorProfileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorProfileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LobId = table.Column<long>(type: "bigint", nullable: true),
                    LobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileSystemDefault = table.Column<bool>(type: "bit", nullable: true),
                    BehaviorSystemDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "PIM_Hierarchy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIM_Hierarchy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PIM_Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TreeSort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyOf = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    TreePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimension1 = table.Column<int>(type: "int", nullable: true),
                    Dimension2 = table.Column<int>(type: "int", nullable: true),
                    Dimension3 = table.Column<int>(type: "int", nullable: true),
                    Dimension4 = table.Column<int>(type: "int", nullable: true),
                    Dimension5 = table.Column<int>(type: "int", nullable: true),
                    Dimension6 = table.Column<int>(type: "int", nullable: true),
                    IsFolder = table.Column<int>(type: "int", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    ObjecttypetemplateID = table.Column<int>(type: "int", nullable: true),
                    ExternalKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<int>(type: "int", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjecttypeID = table.Column<int>(type: "int", nullable: true),
                    CloudStreamID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: true),
                    RuleStatus = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true),
                    PdmarticleconfigurationID = table.Column<int>(type: "int", nullable: true),
                    ClassMapping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId1 = table.Column<int>(type: "int", nullable: true),
                    ClassId2 = table.Column<int>(type: "int", nullable: true),
                    ClassId3 = table.Column<int>(type: "int", nullable: true),
                    ClassId4 = table.Column<int>(type: "int", nullable: true),
                    ClassId5 = table.Column<int>(type: "int", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalCategories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EllsworthMarkets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<int>(type: "int", nullable: true),
                    MarketingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameInURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductsPackagesAndBundles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEOURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebDiscontinued = table.Column<int>(type: "int", nullable: true),
                    Class4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConflictMinerals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HazardousItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitedQtyItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDSDocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipsAmbient = table.Column<int>(type: "int", nullable: true),
                    TDSDocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exclusivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerPN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UID_Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebManufacturerPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    SupplierCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ColumnPrice1 = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ColumnPrice2 = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ColumnPrice3 = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    BrokenCaseStandardCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ResellerPrice = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ConfirmCostCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayPricing = table.Column<int>(type: "int", nullable: true),
                    DisplayPricingContentArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayPricingMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStocked = table.Column<int>(type: "int", nullable: true),
                    MinQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P21SalesUnitPerPackage = table.Column<int>(type: "int", nullable: true),
                    QuoteExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicatorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartridgeCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChemicalComposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Multiple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasingUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Components = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptiveSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispensingValveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsideDiameterFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeySpecifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeUnit1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeUnit2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeUnit3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaperedFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypicalUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedEntries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonReturnableCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingRestrictions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ZoroBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoroCountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoroUnknownCountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoroCaliforniaProp65WarningIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoroOrderLeadTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class5Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerPackageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HTSClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscontinuedCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCriterion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropShipRestriction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPlusCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForceMajeure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    SupplierIDPrimary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMPCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationMOQ = table.Column<int>(type: "int", nullable: true),
                    LocationStockingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockPerCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierNonStockCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USSupplierInformationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USSupplierInformationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariableSizeItemCheckbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YieldItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemLiterature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GHSHazardIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MustShipAirIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeAndTempSensitiveIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateSalesRestrictionIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaliforniaSalesRestrictionIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowVOCIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MadeInUSAIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaliforniaProp65WarningIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesRestrictionIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMultipack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleBundle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleShopping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleExcludedDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleExcludedCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleShipping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartPreset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoNotFreeze = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DryIceItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrozenItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IceBrixItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minus20FItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minus40FItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefrigeratedItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackingTypeFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureSystem2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureSystem3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DielectricStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elongation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlashPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GapFilling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hardness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpactResistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MixRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeelStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseAgentTypeFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShearStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificGravity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaticBagWidthFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TackFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TackFreeTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TapeWidthFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TensileStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThermalConductivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viscosity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeResistivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShelfLifeData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DryIceIceBrixIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotMeltStickWidthFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotMeltType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDSDocumentNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TDSDocumentNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureSystem1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolesorTipsFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SprayFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipAngleFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipGaugeFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipMaterialFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipOrCartridgeTypeFilter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIM_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LP_ConversationInfo",
                columns: table => new
                {
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTimeL = table.Column<long>(type: "bigint", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTimeL = table.Column<long>(type: "bigint", nullable: true),
                    ConversationEndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationEndTimeL = table.Column<long>(type: "bigint", nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: true),
                    BrandId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAgentNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAgentFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAgentLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LatestSkillId = table.Column<long>(type: "bigint", nullable: true),
                    LatestSkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mcs = table.Column<int>(type: "int", nullable: true),
                    AlertedMCS = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDialogStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstConversation = table.Column<bool>(type: "bit", nullable: true),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAgentGroupId = table.Column<long>(type: "bigint", nullable: true),
                    LatestAgentGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestQueueState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPartial = table.Column<bool>(type: "bit", nullable: true),
                    VisitorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionContextId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Integration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntegrationVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestHandlerAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestHandlerSkillId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_ConversationInfo", x => x.ConversationId);
                    table.ForeignKey(
                        name: "FK_LP_ConversationInfo_LP_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "LP_Campaigns",
                        principalColumn: "CampaignId");
                });

            migrationBuilder.CreateTable(
                name: "LP_ConsumerParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParticipantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeL = table.Column<long>(type: "bigint", nullable: true),
                    JoinTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinTimeL = table.Column<long>(type: "bigint", nullable: true),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialogId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_ConsumerParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LP_ConsumerParticipants_LP_ConversationInfo_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "LP_ConversationInfo",
                        principalColumn: "ConversationId");
                });

            migrationBuilder.CreateTable(
                name: "LP_ConversationSurveyData",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerScore = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValidAnswer = table.Column<bool>(type: "bit", nullable: false),
                    AnswerSeq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_ConversationSurveyData", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_LP_ConversationSurveyData_LP_ConversationInfo_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "LP_ConversationInfo",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LP_Interaction",
                columns: table => new
                {
                    DialogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteractiveSequence = table.Column<int>(type: "int", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedAgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedAgentFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedAgentLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedAgentNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionTimeL = table.Column<long>(type: "bigint", nullable: true),
                    InteractionTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_Interaction", x => new { x.DialogId, x.InteractiveSequence });
                    table.ForeignKey(
                        name: "FK_LP_Interaction_LP_ConversationInfo_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "LP_ConversationInfo",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LP_MessageRecords",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialogId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParticipantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageRawScore = table.Column<int>(type: "int", nullable: true),
                    Mcs = table.Column<int>(type: "int", nullable: true),
                    Audience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeL = table.Column<long>(type: "bigint", nullable: true),
                    IntegrationSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredefinedContent = table.Column<bool>(type: "bit", nullable: true),
                    PredefinedContentLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredefinedContentCategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredefinedContentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredefinedContentEdited = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_MessageRecords", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_LP_MessageRecords_LP_ConversationInfo_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "LP_ConversationInfo",
                        principalColumn: "ConversationId");
                });

            migrationBuilder.CreateTable(
                name: "LP_SummaryData",
                columns: table => new
                {
                    PkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<long>(type: "bigint", nullable: true),
                    NoteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAutoSummary = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_SummaryData", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_LP_SummaryData_LP_ConversationInfo_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "LP_ConversationInfo",
                        principalColumn: "ConversationId");
                });

            migrationBuilder.CreateTable(
                name: "LP_Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DialogId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeL = table.Column<long>(type: "bigint", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedAgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetSkillId = table.Column<long>(type: "bigint", nullable: true),
                    TargetSkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceSkillId = table.Column<long>(type: "bigint", nullable: true),
                    SourceSkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceAgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceAgentFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceAgentLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceAgentNickname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LP_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LP_Transfers_LP_ConversationInfo_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "LP_ConversationInfo",
                        principalColumn: "ConversationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LP_ConsumerParticipants_ConversationId",
                table: "LP_ConsumerParticipants",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_LP_ConversationInfo_CampaignId",
                table: "LP_ConversationInfo",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_LP_ConversationSurveyData_ConversationId",
                table: "LP_ConversationSurveyData",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_LP_Interaction_ConversationId",
                table: "LP_Interaction",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_LP_MessageRecords_ConversationId",
                table: "LP_MessageRecords",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_LP_SummaryData_ConversationId",
                table: "LP_SummaryData",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_LP_Transfers_ConversationId",
                table: "LP_Transfers",
                column: "ConversationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelivraClickthroughs");

            migrationBuilder.DropTable(
                name: "DelivraMailingApprovals");

            migrationBuilder.DropTable(
                name: "DelivraOpens");

            migrationBuilder.DropTable(
                name: "DelivraReports");

            migrationBuilder.DropTable(
                name: "DelivraSegments");

            migrationBuilder.DropTable(
                name: "DelivraSends");

            migrationBuilder.DropTable(
                name: "LP_ConsumerParticipants");

            migrationBuilder.DropTable(
                name: "LP_ConversationSurveyData");

            migrationBuilder.DropTable(
                name: "LP_Interaction");

            migrationBuilder.DropTable(
                name: "LP_MessageRecords");

            migrationBuilder.DropTable(
                name: "LP_SummaryData");

            migrationBuilder.DropTable(
                name: "LP_Transfers");

            migrationBuilder.DropTable(
                name: "PIM_Hierarchy");

            migrationBuilder.DropTable(
                name: "PIM_Products");

            migrationBuilder.DropTable(
                name: "LP_ConversationInfo");

            migrationBuilder.DropTable(
                name: "LP_Campaigns");
        }
    }
}
