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

    public virtual DbSet<AdditionalImportRequest> AdditionalImportRequests { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<CheckRequestWarehouse> CheckRequestWarehouses { get; set; }

    public virtual DbSet<ExportRequest> ExportRequests { get; set; }

    public virtual DbSet<ExportWineWarehouse> ExportWineWarehouses { get; set; }

    public virtual DbSet<ImportRequest> ImportRequests { get; set; }

    public virtual DbSet<InventoryCheckRequest> InventoryCheckRequests { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Wine> Wines { get; set; }

    public virtual DbSet<WineCategory> WineCategories { get; set; }

    public virtual DbSet<WineWarehouse> WineWarehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalImportRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("additional_import_request_id_primary");

            entity.ToTable("Additional_Import_Request");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdditionalQuantity).HasColumnName("additional_quantity");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.ExportRequestId).HasColumnName("export_request_id");
            entity.Property(e => e.ImportDate).HasColumnName("import_date");
            entity.Property(e => e.ImportRequestId).HasColumnName("import_request_id");
            entity.Property(e => e.InventoryCheckRequestId).HasColumnName("inventory_check_request_id");
            entity.Property(e => e.RequestCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_code");
            entity.Property(e => e.RequesterName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requester_name");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Supplier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("supplier");
            entity.Property(e => e.TotalValue)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_value");
            entity.Property(e => e.TransportDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("transport_details");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WarehouseLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warehouse_location");

            entity.HasOne(d => d.ExportRequest).WithMany(p => p.AdditionalImportRequests)
                .HasForeignKey(d => d.ExportRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("export_request_foreign_3");

            entity.HasOne(d => d.ImportRequest).WithMany(p => p.AdditionalImportRequests)
                .HasForeignKey(d => d.ImportRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("import_request_foreign_3");

            entity.HasOne(d => d.InventoryCheckRequest).WithMany(p => p.AdditionalImportRequests)
                .HasForeignKey(d => d.InventoryCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_check_request_foreign_3");

            entity.HasOne(d => d.User).WithMany(p => p.AdditionalImportRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_foreign_5");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audit_log_id_primary");

            entity.ToTable("Audit_Log");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActionDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action_description");
            entity.Property(e => e.ActionType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("action_type");
            entity.Property(e => e.DeviceDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("device_details");
            entity.Property(e => e.DurationMs).HasColumnName("duration_ms");
            entity.Property(e => e.ErrorDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("error_details");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.PerformedAt).HasColumnName("performed_at");
            entity.Property(e => e.RequestMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("request_method");
            entity.Property(e => e.RequestUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_url");
            entity.Property(e => e.ResponseSize).HasColumnName("response_size");
            entity.Property(e => e.ResponseStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("response_status");
            entity.Property(e => e.ResponseTime)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("response_time");
            entity.Property(e => e.SessionId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_foreign");
        });

        modelBuilder.Entity<CheckRequestWarehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("check_request_warehouse_id_primary");

            entity.ToTable("Check_Request_Warehouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CheckerAssigned)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("checker_assigned");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.Discrepancies).HasColumnName("discrepancies");
            entity.Property(e => e.ExpectedCompletionDate).HasColumnName("expected_completion_date");
            entity.Property(e => e.InventoryCheckRequestId).HasColumnName("inventory_check_request_id");
            entity.Property(e => e.ItemsChecked).HasColumnName("items_checked");
            entity.Property(e => e.RequestCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_code");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("request_status");
            entity.Property(e => e.RequestedAt).HasColumnName("requested_at");
            entity.Property(e => e.TotalItems).HasColumnName("total_items");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warehouse_name");

            entity.HasOne(d => d.InventoryCheckRequest).WithMany(p => p.CheckRequestWarehouses)
                .HasForeignKey(d => d.InventoryCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_check_request_foreign_2");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.CheckRequestWarehouses)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("warehouse_foreign");
        });

        modelBuilder.Entity<ExportRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("export_request_id_primary");

            entity.ToTable("Export_Request");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.CustomsStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customs_status");
            entity.Property(e => e.DeliveryTerms)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("delivery_terms");
            entity.Property(e => e.DestinationAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("destination_address");
            entity.Property(e => e.ExpectedDelivery).HasColumnName("expected_delivery");
            entity.Property(e => e.ExportDate).HasColumnName("export_date");
            entity.Property(e => e.FragileItems).HasColumnName("fragile_items");
            entity.Property(e => e.InsuranceCoverage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("insurance_coverage");
            entity.Property(e => e.PackagingInstructions)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("packaging_instructions");
            entity.Property(e => e.RequestCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_code");
            entity.Property(e => e.RequesterName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requester_name");
            entity.Property(e => e.ShippingCompany)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("shipping_company");
            entity.Property(e => e.ShippingTrackingNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("shipping_tracking_number");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalQuantity).HasColumnName("total_quantity");
            entity.Property(e => e.TotalValue)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_value");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WineId).HasColumnName("wine_id");

            entity.HasOne(d => d.User).WithMany(p => p.ExportRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_foreign_2");

            entity.HasOne(d => d.Wine).WithMany(p => p.ExportRequests)
                .HasForeignKey(d => d.WineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wine_foreign_2");
        });

        modelBuilder.Entity<ExportWineWarehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Export_W__3213E83FDCC5E67C");

            entity.ToTable("Export_Wine_Warehouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ExportRequestId).HasColumnName("export_request_id");
            entity.Property(e => e.WineWarehouseId).HasColumnName("wine_warehouse_id");

            entity.HasOne(d => d.ExportRequest).WithMany(p => p.ExportWineWarehouses)
                .HasForeignKey(d => d.ExportRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("export_request_foreign_2");

            entity.HasOne(d => d.WineWarehouse).WithMany(p => p.ExportWineWarehouses)
                .HasForeignKey(d => d.WineWarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wine_warehouse_foreign");
        });

        modelBuilder.Entity<ImportRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("import_request_id_primary");

            entity.ToTable("Import_Request");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.CustomsClearance)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customs_clearance");
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("delivery_status");
            entity.Property(e => e.ExpectedArrival).HasColumnName("expected_arrival");
            entity.Property(e => e.ImportDate).HasColumnName("import_date");
            entity.Property(e => e.InsuranceProvider)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("insurance_provider");
            entity.Property(e => e.RequestCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_code");
            entity.Property(e => e.RequesterName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requester_name");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("shipping_method");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Supplier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("supplier");
            entity.Property(e => e.TaxDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tax_details");
            entity.Property(e => e.TotalQuantity).HasColumnName("total_quantity");
            entity.Property(e => e.TotalValue)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_value");
            entity.Property(e => e.TransportDetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("transport_details");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WarehouseLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warehouse_location");
            entity.Property(e => e.WineId).HasColumnName("wine_id");

            entity.HasOne(d => d.User).WithMany(p => p.ImportRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_foreign_4");

            entity.HasOne(d => d.Wine).WithMany(p => p.ImportRequests)
                .HasForeignKey(d => d.WineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wine_foreign");
        });

        modelBuilder.Entity<InventoryCheckRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_check_request_id_primary");

            entity.ToTable("Inventory_Check_Request");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AssignedTeam)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assigned_team");
            entity.Property(e => e.Attachments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("attachments");
            entity.Property(e => e.AuditReference)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("audit_reference");
            entity.Property(e => e.CheckPurpose)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("check_purpose");
            entity.Property(e => e.CheckerAssigned)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("checker_assigned");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.Discrepancies).HasColumnName("discrepancies");
            entity.Property(e => e.ExpectedCompletionDate).HasColumnName("expected_completion_date");
            entity.Property(e => e.ItemsChecked).HasColumnName("items_checked");
            entity.Property(e => e.RequestCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_code");
            entity.Property(e => e.RequestPriority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("request_priority");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("request_status");
            entity.Property(e => e.RequestedAt).HasColumnName("requested_at");
            entity.Property(e => e.RequesterName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requester_name");
            entity.Property(e => e.TotalItems).HasColumnName("total_items");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.InventoryCheckRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_foreign_8");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_id_primary");

            entity.ToTable("Report");

            entity.HasIndex(e => e.ExportRequestId, "UQ__Report__42A76907FBF5270C").IsUnique();

            entity.HasIndex(e => e.AdditionalImportRequestId, "UQ__Report__554DA09A96662158").IsUnique();

            entity.HasIndex(e => e.InventoryCheckRequestId, "UQ__Report__8099F7E53B1391DC").IsUnique();

            entity.HasIndex(e => e.ImportRequestId, "UQ__Report__C75CF497B655D9AD").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdditionalImportRequestId).HasColumnName("additional_import_request_id");
            entity.Property(e => e.DamageReport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("damage_report");
            entity.Property(e => e.DiscrepanciesFound).HasColumnName("discrepancies_found");
            entity.Property(e => e.ExportRequestId).HasColumnName("export_request_id");
            entity.Property(e => e.FileAttachment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_attachment");
            entity.Property(e => e.FinalApprovalDate).HasColumnName("final_approval_date");
            entity.Property(e => e.ImportDate).HasColumnName("import_date");
            entity.Property(e => e.ImportRequestId).HasColumnName("import_request_id");
            entity.Property(e => e.InventoryCheckRequestId).HasColumnName("inventory_check_request_id");
            entity.Property(e => e.ItemsImported).HasColumnName("items_imported");
            entity.Property(e => e.PreparedAt).HasColumnName("prepared_at");
            entity.Property(e => e.ReportDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("report_description");
            entity.Property(e => e.ReportPreparedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("report_prepared_by");
            entity.Property(e => e.ReportStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("report_status");
            entity.Property(e => e.ReviewComments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("review_comments");
            entity.Property(e => e.SignOffBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sign_off_by");
            entity.Property(e => e.SupplierFeedback)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("supplier_feedback");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.AdditionalImportRequest).WithOne(p => p.Report)
                .HasForeignKey<Report>(d => d.AdditionalImportRequestId)
                .HasConstraintName("additional_import_request_foreign");

            entity.HasOne(d => d.ExportRequest).WithOne(p => p.Report)
                .HasForeignKey<Report>(d => d.ExportRequestId)
                .HasConstraintName("export_request_foreign");

            entity.HasOne(d => d.ImportRequest).WithOne(p => p.Report)
                .HasForeignKey<Report>(d => d.ImportRequestId)
                .HasConstraintName("import_request_foreign");

            entity.HasOne(d => d.InventoryCheckRequest).WithOne(p => p.Report)
                .HasForeignKey<Report>(d => d.InventoryCheckRequestId)
                .HasConstraintName("inventory_check_request_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_foreign_6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_id_primary");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("account_status");
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bio");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LastPasswordChange).HasColumnName("last_password_change");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.PreferredLanguage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("preferred_language");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TimeZone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("time_zone");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("warehouse_id_primary");

            entity.ToTable("Warehouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.ClimateControl).HasColumnName("climate_control");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CurrentOccupancy).HasColumnName("current_occupancy");
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emergency_contact");
            entity.Property(e => e.FireSafetyStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fire_safety_status");
            entity.Property(e => e.InspectionFrequency)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("inspection_frequency");
            entity.Property(e => e.InsuranceCoverage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("insurance_coverage");
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location_address");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("manager_name");
            entity.Property(e => e.NumberOfEmployees).HasColumnName("number_of_employees");
            entity.Property(e => e.OperationalHours)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("operational_hours");
            entity.Property(e => e.SecurityLevel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("security_level");
            entity.Property(e => e.WarehouseArea)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("warehouse_area");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warehouse_name");
            entity.Property(e => e.YearBuilt).HasColumnName("year_built");
        });

        modelBuilder.Entity<Wine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wine_id_primary");

            entity.ToTable("Wine");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AcidityLevel)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("acidity_level");
            entity.Property(e => e.AlcoholContent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("alcohol_content");
            entity.Property(e => e.AvailableStock).HasColumnName("available_stock");
            entity.Property(e => e.BottleSize)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bottle_size");
            entity.Property(e => e.BottleWeight)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("bottle_weight");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FermentationProcess)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fermentation_process");
            entity.Property(e => e.HarvestDate).HasColumnName("harvest_date");
            entity.Property(e => e.LabelImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("label_image_url");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SweetnessLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sweetness_level");
            entity.Property(e => e.TanninContent)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tannin_content");
            entity.Property(e => e.Vintage).HasColumnName("vintage");
            entity.Property(e => e.WineAgeingTime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("wine_ageing_time");
            entity.Property(e => e.WineCategoryId).HasColumnName("wine_category_id");
            entity.Property(e => e.WineName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wine_name");
            entity.Property(e => e.WineStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("wine_status");

            entity.HasOne(d => d.WineCategory).WithMany(p => p.Wines)
                .HasForeignKey(d => d.WineCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wine_category_foreign");
        });

        modelBuilder.Entity<WineCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wine_category_id_primary");

            entity.ToTable("Wine_Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AcidityLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("acidity_level");
            entity.Property(e => e.AgeingPotential)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ageing_potential");
            entity.Property(e => e.AromaProfile)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("aroma_profile");
            entity.Property(e => e.BottleShape)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bottle_shape");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FlavorProfile)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("flavor_profile");
            entity.Property(e => e.FoodPairing)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("food_pairing");
            entity.Property(e => e.GrapeVariety)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("grape_variety");
            entity.Property(e => e.IdealServingTemp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ideal_serving_temp");
            entity.Property(e => e.ProductionMethod)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("production_method");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("region");
            entity.Property(e => e.SugarContent)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sugar_content");
            entity.Property(e => e.TanninLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tannin_level");
            entity.Property(e => e.Vineyard)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vineyard");
        });

        modelBuilder.Entity<WineWarehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wine_warehouse_id_primary");

            entity.ToTable("Wine_Warehouse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.HandlingInstructions)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("handling_instructions");
            entity.Property(e => e.HumidityLevel)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("humidity_level");
            entity.Property(e => e.ImportRequestId).HasColumnName("import_request_id");
            entity.Property(e => e.InspectionStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("inspection_status");
            entity.Property(e => e.LastInspectionDate).HasColumnName("last_inspection_date");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rack)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rack");
            entity.Property(e => e.Section)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("section");
            entity.Property(e => e.StorageTemperature)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("storage_temperature");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.WarehouseLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warehouse_location");
            entity.Property(e => e.WineCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wine_code");
            entity.Property(e => e.WineCondition)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("wine_condition");
            entity.Property(e => e.WineId).HasColumnName("wine_id");
            entity.Property(e => e.WineName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wine_name");

            entity.HasOne(d => d.ImportRequest).WithMany(p => p.WineWarehouses)
                .HasForeignKey(d => d.ImportRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("import_request_foreign_2");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WineWarehouses)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("warehouse_foreign_2");

            entity.HasOne(d => d.Wine).WithMany(p => p.WineWarehouses)
                .HasForeignKey(d => d.WineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wine_foreign_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
