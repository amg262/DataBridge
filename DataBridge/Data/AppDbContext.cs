using DataBridge.Models;
using DataBridge.Models.Contentserv;
using DataBridge.Models.Delivra;
using DataBridge.Models.Liveperson;
using Microsoft.EntityFrameworkCore;

namespace DataBridge.Data;

/// <summary>
/// Represents the application's database context, providing access to the Delivra-related entities.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or initializes the DbSet of Delivra reports.
    /// </summary>
    public DbSet<Report> DelivraReports { get; init; }

    /// <summary>
    /// Gets or initializes the DbSet of Delivra segments.
    /// </summary>
    public DbSet<Segment> DelivraSegments { get; init; }

    /// <summary>
    /// Gets or initializes the DbSet of Delivra clickthroughs.
    /// </summary>
    public DbSet<Clickthrough> DelivraClickthroughs { get; init; }

    /// <summary>
    /// Gets or initializes the DbSet of Delivra mailing approvals.
    /// </summary>
    public DbSet<MailingApproval> DelivraMailingApprovals { get; init; }

    /// <summary>
    /// Gets or initializes the DbSet of Delivra opens.
    /// </summary>
    public DbSet<Open> DelivraOpens { get; init; }

    /// <summary>
    /// Gets or initializes the DbSet of Delivra sends.
    /// </summary>
    public DbSet<Send> DelivraSends { get; init; }


    public DbSet<ProductHierarchy> ProductHierachy { get; set; }
    //
    // public DbSet<PimProduct> PimProducts { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ConversationInfo> ConversationInfo { get; set; }

    public DbSet<Interaction> Interactions { get; set; }

    public DbSet<ConsumerParticipant> ConsumerParticipants { get; set; }

    public DbSet<MessageRecord> MessageRecords { get; set; }

    public DbSet<ConversationSurveyData> ConversationSurveyData { get; set; }

    public DbSet<Transfer> Transfers { get; set; }

    public DbSet<Campaign> Campaigns { get; set; }

    public DbSet<SummaryData> SummaryData { get; set; }
    // public DbSet<ProductResponseObject> Products { get; set; }
    // public DbSet<Path> ProductPaths { get; set; }
    // public DbSet<Class> ProductClasses { get; set; }
    // public DbSet<State> ProductStates { get; set; }
    // public DbSet<Attribute> ProductAttributes { get; set; }

    /// <summary>
    /// Configures the entity properties and relationships when the model is being created.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configures the decimal properties for the Report entity
        modelBuilder.Entity<Report>()
            .Property(r => r.Engagement)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Report>()
            .Property(r => r.TransAmt)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.BrokenCaseStandardCost).HasPrecision(18, 6);
            entity.Property(e => e.ColumnPrice1).HasPrecision(18, 6);
            entity.Property(e => e.ColumnPrice2).HasPrecision(18, 6);
            entity.Property(e => e.ColumnPrice3).HasPrecision(18, 6);
            entity.Property(e => e.GrossWeight).HasPrecision(18, 6);
            entity.Property(e => e.MSRP).HasPrecision(18, 6);
            entity.Property(e => e.ResellerPrice).HasPrecision(18, 6);
            entity.Property(e => e.StandardCost).HasPrecision(18, 6);
            entity.Property(e => e.SupplierCost).HasPrecision(18, 6);
            entity.Property(e => e.Weight).HasPrecision(18, 6);
        });

        modelBuilder.Entity<Interaction>()
            .HasKey(i => new { i.DialogId, i.InteractiveSequence });

        modelBuilder.Entity<Transfer>(entity =>
        {
            // entity.ToTable("LP_Transfers");
            entity.HasKey(t => t.Id);
        });
        // modelBuilder.Entity<Transfer>()
        //     .HasKey(i => new { i.DialogId, i.ConversationId });
    }
}