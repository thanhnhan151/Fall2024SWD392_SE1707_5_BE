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
    public DbSet<Role> Roles { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Taste> Tastes { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }
    public DbSet<Cork> Corks { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<AlcoholByVolume> AlcoholByVolumes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DeployConnection"), sqlOptions =>
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null));       
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

            entity.Property(u => u.ProfileImageUrl)
                .HasMaxLength(256); // Adjust length as necessary

            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


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
                .HasMaxLength(25); // Adjust length as necessary

            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
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

            entity.Property(w => w.ImportPrice)
                .HasColumnType("decimal(8, 2)");

            entity.Property(w => w.ExportPrice)
                .HasColumnType("decimal(8, 2)");

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
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
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

            entity.HasOne(w => w.Country)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.CountryId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.Taste)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.TasteId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.Class)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.ClassId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.Qualification)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.QualificationId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.Cork)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.CorkId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.Brand)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.BrandId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.BottleSize)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.BottleSizeId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(w => w.AlcoholByVolume)
                  .WithMany(c => c.Wines)
                  .HasForeignKey(w => w.AlcoholByVolumeId)
                  .OnDelete(DeleteBehavior.Restrict);
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
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
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
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
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

            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

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

            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

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

            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

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
            // Common fields from CommonEntity
            entity.Property(u => u.CreatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.UpdatedTime)
                .IsRequired(false); // Optional: set as required if needed

            entity.Property(u => u.DeletedTime)
                .IsRequired(false); // Optional: make nullable if it's not always set

            entity.Property(u => u.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50); // Adjust length as necessary

            entity.Property(u => u.DeletedBy)
                .HasMaxLength(50); // Adjust length as necessary

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

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(r => r.RoleName)
                  .HasMaxLength(7)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(r => r.CountryName)
                  .HasMaxLength(12)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<Taste>(entity =>
        {
            entity.Property(r => r.TasteType)
                  .HasMaxLength(11)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(r => r.ClassType)
                  .HasMaxLength(10)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.Property(r => r.QualificationType)
                  .HasMaxLength(10)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<Cork>(entity =>
        {
            entity.Property(r => r.CorkType)
                  .HasMaxLength(8)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(r => r.BrandName)
                  .HasMaxLength(50)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<BottleSize>(entity =>
        {
            entity.Property(r => r.BottleSizeType)
                  .HasMaxLength(8)
                  .IsRequired(); // Optional: set as required if needed
        });

        modelBuilder.Entity<AlcoholByVolume>(entity =>
        {
            entity.Property(r => r.AlcoholByVolumeType)
                  .HasMaxLength(3)
                  .IsRequired(); // Optional: set as required if needed
        });
    }
}
