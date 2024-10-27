﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WWMS.DAL.Persistences;

#nullable disable

namespace WWMS.DAL.Migrations
{
    [DbContext(typeof(WineWarehouseDbContext))]
    partial class WineWarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WWMS.DAL.Entities.AlcoholByVolume", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AlcoholByVolumeType")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("AlcoholByVolume");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.BottleSize", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BottleSizeType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("BottleSize");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.CheckRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("PriorityLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RequesterId")
                        .HasColumnType("bigint");

                    b.Property<string>("RequesterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.ToTable("CheckRequest");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.CheckRequestDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ActualQuantity")
                        .HasColumnType("int");

                    b.Property<string>("CheckRequestCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CheckRequestId")
                        .HasColumnType("bigint");

                    b.Property<long>("CheckerId")
                        .HasColumnType("bigint");

                    b.Property<string>("CheckerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscrepanciesFound")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpectedCurrQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MFD")
                        .HasColumnType("datetime2");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReporterAssigned")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("WineId")
                        .HasColumnType("bigint");

                    b.Property<string>("WineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WineRoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CheckRequestId");

                    b.HasIndex("WineRoomId");

                    b.ToTable("CheckRequestDetail");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Class", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ClassType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.CodeResetPass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CodeVerified")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUsable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("CodeResetPass");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Cork", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CorkType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Cork");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.IORequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CheckerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IOType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SuplierId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CheckerId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SuplierId");

                    b.ToTable("IORequest");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.IORequestDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IORequestId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("WineId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IORequestId");

                    b.HasIndex("WineId");

                    b.ToTable("IORequestDetail");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Qualification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("QualificationType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentOccupancy")
                        .HasColumnType("int");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ManagerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Suplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("SuplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Suplier");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Taste", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("TasteType")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Taste");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ProfileImageUrl")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Wine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AlcoholByVolumeId")
                        .HasColumnType("bigint");

                    b.Property<long>("BottleSizeId")
                        .HasColumnType("bigint");

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<long>("CorkId")
                        .HasColumnType("bigint");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("ExportPrice")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ImportPrice")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<DateTime?>("MFD")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<long>("QualificationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TasteId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("WineCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("WineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AlcoholByVolumeId");

                    b.HasIndex("BottleSizeId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CorkId");

                    b.HasIndex("CountryId");

                    b.HasIndex("QualificationId");

                    b.HasIndex("TasteId");

                    b.HasIndex("WineCategoryId");

                    b.ToTable("Wine");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.WineCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("WineCategory");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.WineRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CurrentQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Export")
                        .HasColumnType("int");

                    b.Property<int>("Import")
                        .HasColumnType("int");

                    b.Property<int>("InitialQuantity")
                        .HasColumnType("int");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<long>("WineId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("WineId");

                    b.ToTable("WineRoom");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.CheckRequest", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.User", null)
                        .WithMany("CheckRequests")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WWMS.DAL.Entities.CheckRequestDetail", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.CheckRequest", "CheckRequest")
                        .WithMany("CheckRequestDetails")
                        .HasForeignKey("CheckRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.WineRoom", null)
                        .WithMany("CheckRequestDetails")
                        .HasForeignKey("WineRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckRequest");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.IORequest", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.User", "Checker")
                        .WithMany("IORequests")
                        .HasForeignKey("CheckerId");

                    b.HasOne("WWMS.DAL.Entities.Customer", "Customer")
                        .WithMany("IORequests")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WWMS.DAL.Entities.Room", "Room")
                        .WithMany("IORequests")
                        .HasForeignKey("RoomId");

                    b.HasOne("WWMS.DAL.Entities.Suplier", "Suplier")
                        .WithMany("IORequests")
                        .HasForeignKey("SuplierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Checker");

                    b.Navigation("Customer");

                    b.Navigation("Room");

                    b.Navigation("Suplier");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.IORequestDetail", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.IORequest", "IORequest")
                        .WithMany("IORequestDetails")
                        .HasForeignKey("IORequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Wine", "Wine")
                        .WithMany("IORequestDetails")
                        .HasForeignKey("WineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("IORequest");

                    b.Navigation("Wine");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.User", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Wine", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.AlcoholByVolume", "AlcoholByVolume")
                        .WithMany("Wines")
                        .HasForeignKey("AlcoholByVolumeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.BottleSize", "BottleSize")
                        .WithMany("Wines")
                        .HasForeignKey("BottleSizeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Brand", "Brand")
                        .WithMany("Wines")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Class", "Class")
                        .WithMany("Wines")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Cork", "Cork")
                        .WithMany("Wines")
                        .HasForeignKey("CorkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Country", "Country")
                        .WithMany("Wines")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Qualification", "Qualification")
                        .WithMany("Wines")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Taste", "Taste")
                        .WithMany("Wines")
                        .HasForeignKey("TasteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.WineCategory", "WineCategory")
                        .WithMany("Wines")
                        .HasForeignKey("WineCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AlcoholByVolume");

                    b.Navigation("BottleSize");

                    b.Navigation("Brand");

                    b.Navigation("Class");

                    b.Navigation("Cork");

                    b.Navigation("Country");

                    b.Navigation("Qualification");

                    b.Navigation("Taste");

                    b.Navigation("WineCategory");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.WineRoom", b =>
                {
                    b.HasOne("WWMS.DAL.Entities.Room", "Room")
                        .WithMany("WineRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WWMS.DAL.Entities.Wine", "Wine")
                        .WithMany("WineRooms")
                        .HasForeignKey("WineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Wine");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.AlcoholByVolume", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.BottleSize", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.CheckRequest", b =>
                {
                    b.Navigation("CheckRequestDetails");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Class", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Cork", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Country", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Customer", b =>
                {
                    b.Navigation("IORequests");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.IORequest", b =>
                {
                    b.Navigation("IORequestDetails");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Qualification", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Room", b =>
                {
                    b.Navigation("IORequests");

                    b.Navigation("WineRooms");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Suplier", b =>
                {
                    b.Navigation("IORequests");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Taste", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.User", b =>
                {
                    b.Navigation("CheckRequests");

                    b.Navigation("IORequests");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.Wine", b =>
                {
                    b.Navigation("IORequestDetails");

                    b.Navigation("WineRooms");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.WineCategory", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WWMS.DAL.Entities.WineRoom", b =>
                {
                    b.Navigation("CheckRequestDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
