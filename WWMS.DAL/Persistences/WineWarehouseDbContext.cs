using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WWMS.DAL.Entities;

namespace WWMS.DAL.Persistences;

public partial class WineWarehouseDbContext : DbContext
{
    public WineWarehouseDbContext()
    {
    }

    public WineWarehouseDbContext(DbContextOptions<WineWarehouseDbContext> options)
        : base(options)
    {
    }

    // DbSets for entities
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Wine> Wines { get; set; }
    public DbSet<WineCategory> WineCategories { get; set; }
    public DbSet<CheckRequest> CheckRequests { get; set; }
    public DbSet<CheckRequestDetail> CheckRequestDetails { get; set; }
    public DbSet<IORequest> IORequests { get; set; }
    public DbSet<IORequestDetail> IORequestDetails { get; set; }
    public DbSet<WineRoom> WineRooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var builder = new ConfigurationBuilder()
        //                           .SetBasePath(Directory.GetCurrentDirectory())
        //                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        // IConfigurationRoot configuration = builder.Build();
        // optionsBuilder.UseSqlServer(configuration.GetConnectionString("DeployConnection"));
        string temp = "Server=tcp:db-fu.database.windows.net,1433;Initial Catalog=FU-SWD-FA24;Persist Security Info=False;User ID=sa123;Password=FUdb123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        optionsBuilder.UseSqlServer(
           temp,
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, // Maximum number of retries
                    maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                    errorNumbersToAdd: null // Add specific error numbers if needed
                );
            });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // USER
        modelBuilder.Entity<User>(entity =>
        {
            // Primary key configuration
            entity.HasKey(u => u.Id);

            // Properties configuration
            entity.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(256); // Adjust length as necessary

            entity.Property(u => u.FirstName)
                .HasMaxLength(100); // Adjust length as necessary

            entity.Property(u => u.LastName)
                .HasMaxLength(100); // Adjust length as necessary

            entity.Property(u => u.Email)
                .HasMaxLength(256); // Adjust length as necessary

            entity.Property(u => u.PhoneNumber)
                .HasMaxLength(15); // Adjust length as necessary

            entity.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(20) // Adjust length as necessary
                .HasConversion<string>(); // Ensure the role is stored as a string

            entity.Property(u => u.ProfileImageUrl)
                .HasMaxLength(256); // Adjust length as necessary

            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary



            entity.HasMany(u => u.IORequests)
                .WithOne() // Assuming IORequest does not have a navigation property back to User
                .HasForeignKey(ir => ir.RequesterId) // Ensure the RequesterId exists in the IORequest entity
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior as necessary

            entity.HasMany(u => u.CheckRequests)
                .WithOne() // Assuming CheckRequest does not have a navigation property back to User
                .HasForeignKey(cr => cr.RequesterId) // Ensure the RequesterId exists in the CheckRequest entity
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior as necessary
        });

        // WINE CATEGORY
        modelBuilder.Entity<WineCategory>(entity =>
        {
            // Primary key configuration
            entity.HasKey(wc => wc.Id);

            // Properties configuration
            entity.Property(wc => wc.CategoryName)
                .IsRequired()
                .HasMaxLength(100); // Adjust length as necessary

            entity.Property(wc => wc.Description)
                .HasMaxLength(500); // Adjust length as necessary

            entity.Property(wc => wc.WineType)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            // Common fields from CommonEntity
            entity.Property(wc => wc.CreatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(wc => wc.UpdatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(wc => wc.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(wc => wc.CreatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(wc => wc.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(wc => wc.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

            // Relationships
            entity.HasMany(wc => wc.Wines)
                .WithOne(w => w.WineCategory) // Assuming Wine has a navigation property for WineCategory
                .HasForeignKey(w => w.WineCategoryId) // Ensure the WineCategoryId exists in the Wine entity
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior as necessary
        });



        // WINE
        modelBuilder.Entity<Wine>(entity =>
        {
            // Primary key configuration
            entity.HasKey(w => w.Id);

            // Properties configuration
            entity.Property(w => w.WineName)
                .IsRequired()
                .HasMaxLength(100); // Adjust length as necessary

            entity.Property(w => w.AlcoholContent)
                .HasColumnType("decimal(5, 2)"); // Example precision, adjust as necessary

            entity.Property(w => w.BottleSize)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(w => w.AvailableStock)
                .IsRequired()
                .HasDefaultValue(0); // Default value if needed

            entity.Property(w => w.Description)
                .HasMaxLength(500); // Adjust length as necessary

            entity.Property(w => w.ImageUrl)
                .HasMaxLength(200); // Adjust length as necessary

            entity.Property(w => w.Supplier)
                .IsRequired()
                .HasMaxLength(100); // Adjust length as necessary

            entity.Property(w => w.MFD)
                .IsRequired(); // Ensure this property is required

            // Common fields from CommonEntity
            entity.Property(w => w.CreatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(w => w.UpdatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(w => w.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(w => w.CreatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(w => w.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(w => w.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

            // Foreign key configuration
            entity.HasOne(w => w.WineCategory)
                .WithMany(wc => wc.Wines)
                .HasForeignKey(w => w.WineCategoryId)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior as necessary

            // Relationships
            entity.HasMany(w => w.WineRooms)
                .WithOne(wr => wr.Wine) // Assuming WineRoom has a navigation property for Wine
                .HasForeignKey(wr => wr.WineId) // Ensure the WineId exists in the WineRoom entity
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior as necessary
        });
        // ROOM
        modelBuilder.Entity<Room>(entity =>
        {
            // Primary key configuration
            entity.HasKey(r => r.Id);

            // Properties configuration
            entity.Property(r => r.RoomName)
                .IsRequired()
                .HasMaxLength(100); // Adjust length as necessary

            entity.Property(r => r.LocationAddress)
                .HasMaxLength(200); // Adjust length as necessary

            entity.Property(r => r.ManagerName)
                .HasMaxLength(100); // Adjust length as necessary

            // Common fields from CommonEntity
            entity.Property(r => r.CreatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(r => r.UpdatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(r => r.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(r => r.CreatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(r => r.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(r => r.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

            // Relationships configuration
            entity.HasMany(r => r.WineRooms)
                .WithOne(wr => wr.Room)
                .HasForeignKey(wr => wr.RoomId) // Ensure this matches the foreign key in WineRoom
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior as necessary
        });


        // WINE_ROOM
        modelBuilder.Entity<WineRoom>(entity =>
        {
            // Primary key configuration
            entity.HasKey(wr => wr.Id);

            // Properties configuration
            entity.Property(wr => wr.CurrQuantity)
                .IsRequired();

            entity.Property(wr => wr.TotalQuantity)
                .IsRequired();

            // Common fields from CommonEntity
            entity.Property(wr => wr.CreatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(wr => wr.UpdatedTime)
                .IsRequired(); // Optional: set as required if needed

            entity.Property(wr => wr.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(wr => wr.CreatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(wr => wr.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(wr => wr.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

            // Foreign key configuration for Room
            entity.HasOne(wr => wr.Room)
                .WithMany(r => r.WineRooms) // Ensure the Room entity has a collection for WineRooms
                .HasForeignKey(wr => wr.RoomId)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ; // Adjust delete behavior if needed

            // Foreign key configuration for Wine
            entity.HasOne(wr => wr.Wine)
                .WithMany(w => w.WineRooms) // Ensure the Wine entity has a collection for WineRooms
                .HasForeignKey(wr => wr.WineId)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ;
        });



        // Configuring CheckRequest entity
        modelBuilder.Entity<CheckRequest>(entity =>
        {
            entity.HasKey(cr => cr.Id);

            // CommonEntity properties
            entity.Property(cr => cr.CreatedTime)
                .IsRequired();

            entity.Property(cr => cr.UpdatedTime)
                .IsRequired();

            entity.Property(cr => cr.DeletedTime)
                .IsRequired(false); // Nullable if soft delete is not implemented

            entity.Property(cr => cr.CreatedBy)
                .IsRequired();

            entity.Property(cr => cr.UpdatedBy)
                .IsRequired(false); // Nullable if not updated yet

            entity.Property(cr => cr.DeletedBy)
                .IsRequired(false); // Nullable if not deleted yet

            entity.Property(cr => cr.Status)
                .IsRequired();

            // Specific properties
            entity.Property(cr => cr.Purpose)
                .IsRequired();

            entity.Property(cr => cr.RequestCode)
                .IsRequired();

            entity.Property(cr => cr.StartDate)
                .IsRequired();

            entity.Property(cr => cr.DueDate)
                .IsRequired();

            entity.Property(cr => cr.Comments)
                .IsRequired(false); // Nullable property

            entity.Property(cr => cr.PriorityLevel)
                .IsRequired();

            // Foreign key configuration for Requester
            entity.Property(cr => cr.RequesterId)
                .IsRequired();

            entity.Property(cr => cr.RequesterName)
                .IsRequired(false); // Nullable property

            // Configure one-to-many relationship with CheckRequestDetail
            entity.HasMany(cr => cr.CheckRequestDetails)
                .WithOne(crd => crd.CheckRequest)
                .HasForeignKey(crd => crd.CheckRequestId)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ;
        });

        // Configuring CheckRequestDetail entity
        modelBuilder.Entity<CheckRequestDetail>(entity =>
        {
            entity.HasKey(crd => crd.Id);

            // CommonEntity properties
            entity.Property(crd => crd.CreatedTime)
                .IsRequired();

            entity.Property(crd => crd.UpdatedTime)
                .IsRequired();

            entity.Property(crd => crd.DeletedTime)
                .IsRequired(false); // Nullable if soft delete is not implemented

            entity.Property(crd => crd.CreatedBy)
                .IsRequired();

            entity.Property(crd => crd.UpdatedBy)
                .IsRequired(false); // Nullable if not updated yet

            entity.Property(crd => crd.DeletedBy)
                .IsRequired(false); // Nullable if not deleted yet

            entity.Property(crd => crd.Status)
                .IsRequired();

            // Specific properties
            entity.Property(crd => crd.Purpose)
                .IsRequired();

            entity.Property(crd => crd.StartDate)
                .IsRequired();

            entity.Property(crd => crd.DueDate)
                .IsRequired();

            entity.Property(crd => crd.Comments)
                .IsRequired();

            entity.Property(crd => crd.CheckRequestCode)
                .IsRequired();
            // Report fields
            entity.Property(crd => crd.ReportCode)
                .IsRequired();

            entity.Property(crd => crd.ReportDescription)
                .IsRequired(false); // Optional

            entity.Property(crd => crd.ReporterAssigned)
                .IsRequired();

            entity.Property(crd => crd.DiscrepanciesFound)
                .IsRequired(false); // Optional

            entity.Property(crd => crd.ActualQuantity)
                .IsRequired();

            entity.Property(crd => crd.ReportFile)
                .IsRequired(false); // Optional

            // Foreign keys
            entity.Property(crd => crd.CheckRequestId)
                .IsRequired();

        });

        // Configuring IORequest entity
        modelBuilder.Entity<IORequest>(entity =>
        {
            entity.HasKey(ir => ir.Id);

            // CommonEntity properties
            entity.Property(ir => ir.CreatedTime)
                .IsRequired();

            entity.Property(ir => ir.UpdatedTime)
                .IsRequired();

            entity.Property(ir => ir.DeletedTime)
                .IsRequired(false); // Nullable if soft delete is not implemented

            entity.Property(ir => ir.CreatedBy)
                .IsRequired();

            entity.Property(ir => ir.UpdatedBy)
                .IsRequired(false); // Nullable if not updated yet

            entity.Property(ir => ir.DeletedBy)
                .IsRequired(false); // Nullable if not deleted yet

            entity.Property(ir => ir.Status)
                .IsRequired();

            // Specific properties
            entity.Property(ir => ir.RequestCode)
                .IsRequired();

            entity.Property(ir => ir.StartDate)
                .IsRequired(false); // Nullable property

            entity.Property(ir => ir.DueDate)
                .IsRequired(false); // Nullable property

            entity.Property(ir => ir.TotalQuantity)
                .IsRequired(false); // Nullable property

            entity.Property(ir => ir.Comments)
                .IsRequired(false); // Nullable property

            entity.Property(ir => ir.IOType)
                .IsRequired();

            entity.Property(ir => ir.PriorityLevel)
                .IsRequired();

            // Foreign key configuration for Requester
            entity.Property(ir => ir.RequesterId)
                .IsRequired();

            entity.Property(ir => ir.RequesterName)
                .IsRequired(false); // Nullable property

            // Configure one-to-many relationship with IORequestDetail
            entity.HasMany(ir => ir.IORequestDetails)
                .WithOne(ird => ird.IORequest)
                .HasForeignKey(ird => ird.IORequestId)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            ;
        });

        // Configuring IORequestDetail entity
        modelBuilder.Entity<IORequestDetail>(entity =>
        {
            entity.HasKey(ird => ird.Id);

            // CommonEntity properties
            entity.Property(ird => ird.CreatedTime)
                .IsRequired();

            entity.Property(ird => ird.UpdatedTime)
                .IsRequired();

            entity.Property(ird => ird.DeletedTime)
                .IsRequired(false); // Nullable if soft delete is not implemented

            entity.Property(ird => ird.CreatedBy)
                .IsRequired();

            entity.Property(ird => ird.UpdatedBy)
                .IsRequired(false); // Nullable if not updated yet

            entity.Property(ird => ird.DeletedBy)
                .IsRequired(false); // Nullable if not deleted yet

            entity.Property(ird => ird.Status)
                .IsRequired();

            // Specific properties
            entity.Property(ird => ird.Quantity)
                .IsRequired();

            entity.Property(ird => ird.StartDate)
                .IsRequired();

            entity.Property(ird => ird.EndDate)
                .IsRequired();

            entity.Property(ird => ird.Comments)
                .IsRequired();
            // Report fields
            entity.Property(crd => crd.ReportCode)
                .IsRequired();

            entity.Property(crd => crd.ReportDescription)
                .IsRequired(false); // Optional

            entity.Property(crd => crd.ReporterAssigned)
                .IsRequired();

            entity.Property(crd => crd.DiscrepanciesFound)
                .IsRequired(false); // Optional

            entity.Property(crd => crd.ActualQuantity)
                .IsRequired();

            entity.Property(crd => crd.ReportFile)
                .IsRequired(false); // Optional

            // Foreign keys
            entity.Property(ird => ird.WineId)
                .IsRequired();

            entity.Property(ird => ird.RoomId)
                .IsRequired();

            entity.Property(ird => ird.IORequestId)
                .IsRequired();

            entity.Property(ird => ird.IORequestCode)
                .IsRequired();
        });

    }
}
