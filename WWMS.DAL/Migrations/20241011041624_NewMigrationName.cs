using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "wine_category_foreign",
                table: "Wine");

            migrationBuilder.DropTable(
                name: "Audit_Log");

            migrationBuilder.DropTable(
                name: "Check_Request_Warehouse");

            migrationBuilder.DropTable(
                name: "Export_Wine_Warehouse");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Wine_Warehouse");

            migrationBuilder.DropTable(
                name: "Additional_Import_Request");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Export_Request");

            migrationBuilder.DropTable(
                name: "Import_Request");

            migrationBuilder.DropTable(
                name: "Inventory_Check_Request");

            migrationBuilder.DropPrimaryKey(
                name: "wine_category_id_primary",
                table: "Wine_Category");

            migrationBuilder.DropPrimaryKey(
                name: "wine_id_primary",
                table: "Wine");

            migrationBuilder.DropPrimaryKey(
                name: "user_id_primary",
                table: "User");

            migrationBuilder.DropColumn(
                name: "acidity_level",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "ageing_potential",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "aroma_profile",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "bottle_shape",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "flavor_profile",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "food_pairing",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "grape_variety",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "ideal_serving_temp",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "production_method",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "region",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "sugar_content",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "tannin_level",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "vineyard",
                table: "Wine_Category");

            migrationBuilder.DropColumn(
                name: "acidity_level",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "bottle_weight",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "fermentation_process",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "label_image_url",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "sweetness_level",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "tannin_content",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "vintage",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "wine_ageing_time",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "wine_status",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "account_status",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Wine_Category",
                newName: "WineCategories");

            migrationBuilder.RenameTable(
                name: "Wine",
                newName: "Wines");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "WineCategories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WineCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "WineCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Wines",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Wines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wine_name",
                table: "Wines",
                newName: "WineName");

            migrationBuilder.RenameColumn(
                name: "wine_category_id",
                table: "Wines",
                newName: "WineCategoryId");

            migrationBuilder.RenameColumn(
                name: "bottle_size",
                table: "Wines",
                newName: "BottleSize");

            migrationBuilder.RenameColumn(
                name: "available_stock",
                table: "Wines",
                newName: "AvailableStock");

            migrationBuilder.RenameColumn(
                name: "alcohol_content",
                table: "Wines",
                newName: "AlcoholContent");

            migrationBuilder.RenameColumn(
                name: "harvest_date",
                table: "Wines",
                newName: "deletedTime");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_wine_category_id",
                table: "Wines",
                newName: "IX_Wines_WineCategoryId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "profile_image_url",
                table: "Users",
                newName: "ProfileImageUrl");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "deletedTime");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WineCategories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "WineCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WineCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WineType",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "deletedBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WineName",
                table: "Wines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "BottleSize",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvailableStock",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Wines",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MFD",
                table: "Wines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Wines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdTime",
                table: "Wines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "deletedBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedTime",
                table: "Wines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "deletedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineCategories",
                table: "WineCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wines",
                table: "Wines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CheckRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequesterId = table.Column<long>(type: "bigint", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckRequests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IORequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequesterId = table.Column<long>(type: "bigint", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IORequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IORequests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    CurrentOccupancy = table.Column<int>(type: "int", nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    deletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    WineId = table.Column<long>(type: "bigint", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    deletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WineRooms_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckRequestDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckRequestId = table.Column<long>(type: "bigint", nullable: false),
                    CheckRequestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineId = table.Column<long>(type: "bigint", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MFD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCapacity = table.Column<int>(type: "int", nullable: false),
                    CheckerId = table.Column<long>(type: "bigint", nullable: false),
                    CheckerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineRoomId = table.Column<long>(type: "bigint", nullable: false),
                    ExpectedCurrQuantity = table.Column<int>(type: "int", nullable: false),
                    ReportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterAssigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscrepanciesFound = table.Column<int>(type: "int", nullable: true),
                    ActualQuantity = table.Column<int>(type: "int", nullable: false),
                    ReportFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckRequestDetails_CheckRequests_CheckRequestId",
                        column: x => x.CheckRequestId,
                        principalTable: "CheckRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckRequestDetails_WineRooms_WineRoomId",
                        column: x => x.WineRoomId,
                        principalTable: "WineRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IORequestDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineId = table.Column<long>(type: "bigint", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MFD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IORequestId = table.Column<long>(type: "bigint", nullable: false),
                    IORequestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckerId = table.Column<long>(type: "bigint", nullable: false),
                    CheckerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineRoomId = table.Column<long>(type: "bigint", nullable: false),
                    ReportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterAssigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscrepanciesFound = table.Column<int>(type: "int", nullable: true),
                    ActualQuantity = table.Column<int>(type: "int", nullable: false),
                    ReportFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IORequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IORequestDetails_IORequests_IORequestId",
                        column: x => x.IORequestId,
                        principalTable: "IORequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IORequestDetails_WineRooms_WineRoomId",
                        column: x => x.WineRoomId,
                        principalTable: "WineRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckRequestDetails_CheckRequestId",
                table: "CheckRequestDetails",
                column: "CheckRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckRequestDetails_WineRoomId",
                table: "CheckRequestDetails",
                column: "WineRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckRequests_RequesterId",
                table: "CheckRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_IORequestDetails_IORequestId",
                table: "IORequestDetails",
                column: "IORequestId");

            migrationBuilder.CreateIndex(
                name: "IX_IORequestDetails_WineRoomId",
                table: "IORequestDetails",
                column: "WineRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_IORequests_RequesterId",
                table: "IORequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_WineRooms_RoomId",
                table: "WineRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_WineRooms_WineId",
                table: "WineRooms",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_WineCategories_WineCategoryId",
                table: "Wines",
                column: "WineCategoryId",
                principalTable: "WineCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_WineCategories_WineCategoryId",
                table: "Wines");

            migrationBuilder.DropTable(
                name: "CheckRequestDetails");

            migrationBuilder.DropTable(
                name: "IORequestDetails");

            migrationBuilder.DropTable(
                name: "CheckRequests");

            migrationBuilder.DropTable(
                name: "IORequests");

            migrationBuilder.DropTable(
                name: "WineRooms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wines",
                table: "Wines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineCategories",
                table: "WineCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "MFD",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "createdTime",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "updatedTime",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "WineType",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "createdTime",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "deletedTime",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "updatedTime",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "updatedTime",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Wines",
                newName: "Wine");

            migrationBuilder.RenameTable(
                name: "WineCategories",
                newName: "Wine_Category");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Wine",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Wine",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WineName",
                table: "Wine",
                newName: "wine_name");

            migrationBuilder.RenameColumn(
                name: "WineCategoryId",
                table: "Wine",
                newName: "wine_category_id");

            migrationBuilder.RenameColumn(
                name: "BottleSize",
                table: "Wine",
                newName: "bottle_size");

            migrationBuilder.RenameColumn(
                name: "AvailableStock",
                table: "Wine",
                newName: "available_stock");

            migrationBuilder.RenameColumn(
                name: "AlcoholContent",
                table: "Wine",
                newName: "alcohol_content");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "Wine",
                newName: "harvest_date");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_WineCategoryId",
                table: "Wine",
                newName: "IX_Wine_wine_category_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Wine_Category",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Wine_Category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Wine_Category",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "User",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProfileImageUrl",
                table: "User",
                newName: "profile_image_url");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "User",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "User",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Wine",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "wine_name",
                table: "Wine",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "bottle_size",
                table: "Wine",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "available_stock",
                table: "Wine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "acidity_level",
                table: "Wine",
                type: "decimal(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "bottle_weight",
                table: "Wine",
                type: "decimal(6,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fermentation_process",
                table: "Wine",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "label_image_url",
                table: "Wine",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Wine",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sweetness_level",
                table: "Wine",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tannin_content",
                table: "Wine",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vintage",
                table: "Wine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "wine_ageing_time",
                table: "Wine",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wine_status",
                table: "Wine",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "acidity_level",
                table: "Wine_Category",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ageing_potential",
                table: "Wine_Category",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aroma_profile",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bottle_shape",
                table: "Wine_Category",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Wine_Category",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "flavor_profile",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "food_pairing",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "grape_variety",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ideal_serving_temp",
                table: "Wine_Category",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "production_method",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "region",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sugar_content",
                table: "Wine_Category",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tannin_level",
                table: "Wine_Category",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vineyard",
                table: "Wine_Category",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "User",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "profile_image_url",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "User",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password_hash",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "account_status",
                table: "User",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "wine_id_primary",
                table: "Wine",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "wine_category_id_primary",
                table: "Wine_Category",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "user_id_primary",
                table: "User",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Audit_Log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    action_description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    action_type = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    device_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    duration_ms = table.Column<int>(type: "int", nullable: true),
                    error_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ip_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    performed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    request_method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    request_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    response_size = table.Column<long>(type: "bigint", nullable: true),
                    response_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    response_time = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    session_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("audit_log_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Export_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_id = table.Column<long>(type: "bigint", nullable: false),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    customs_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    delivery_terms = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    destination_address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    expected_delivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    export_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fragile_items = table.Column<bool>(type: "bit", nullable: true),
                    insurance_coverage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    packaging_instructions = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    reporter_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    shipping_company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    shipping_tracking_number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    total_quantity = table.Column<int>(type: "int", nullable: true),
                    total_value = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("export_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign_2",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_foreign_2",
                        column: x => x.wine_id,
                        principalTable: "Wine",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Import_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_id = table.Column<long>(type: "bigint", nullable: false),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    customs_clearance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    delivery_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    expected_arrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    import_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    insurance_provider = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    reporter_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    shipping_method = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    supplier = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tax_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    total_quantity = table.Column<int>(type: "int", nullable: true),
                    total_value = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    transport_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    warehouse_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("import_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign_4",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_foreign",
                        column: x => x.wine_id,
                        principalTable: "Wine",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Check_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    attachments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    audit_reference = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    check_purpose = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    checker_assigned = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    discrepancies = table.Column<int>(type: "int", nullable: true),
                    expected_completion_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    items_checked = table.Column<int>(type: "int", nullable: true),
                    reporter_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    request_priority = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    request_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    requested_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    total_items = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventory_check_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign_8",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    climate_control = table.Column<bool>(type: "bit", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    current_occupancy = table.Column<int>(type: "int", nullable: true),
                    emergency_contact = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fire_safety_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    inspection_frequency = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    insurance_coverage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    location_address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    manager_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    number_of_employees = table.Column<int>(type: "int", nullable: true),
                    operational_hours = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    security_level = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    warehouse_area = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    warehouse_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    year_built = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("warehouse_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Additional_Import_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    export_request_id = table.Column<long>(type: "bigint", nullable: false),
                    import_request_id = table.Column<long>(type: "bigint", nullable: false),
                    inventory_check_request_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    additional_quantity = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    import_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reporter_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    supplier = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    total_value = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    transport_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    warehouse_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("additional_import_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "export_request_foreign_3",
                        column: x => x.export_request_id,
                        principalTable: "Export_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "import_request_foreign_3",
                        column: x => x.import_request_id,
                        principalTable: "Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "inventory_check_request_foreign_3",
                        column: x => x.inventory_check_request_id,
                        principalTable: "Inventory_Check_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_foreign_5",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Check_Request_Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inventory_check_request_id = table.Column<long>(type: "bigint", nullable: false),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false),
                    checker_assigned = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    discrepancies = table.Column<int>(type: "int", nullable: true),
                    expected_completion_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    items_checked = table.Column<int>(type: "int", nullable: true),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    request_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    requested_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    total_items = table.Column<int>(type: "int", nullable: true),
                    warehouse_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("check_request_warehouse_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "inventory_check_request_foreign_2",
                        column: x => x.inventory_check_request_id,
                        principalTable: "Inventory_Check_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "warehouse_foreign",
                        column: x => x.warehouse_id,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Wine_Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    import_request_id = table.Column<long>(type: "bigint", nullable: false),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_id = table.Column<long>(type: "bigint", nullable: false),
                    arrival_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    handling_instructions = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    humidity_level = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    inspection_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    last_inspection_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    rack = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    section = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    storage_temperature = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    warehouse_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    wine_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    wine_condition = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    wine_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("wine_warehouse_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "import_request_foreign_2",
                        column: x => x.import_request_id,
                        principalTable: "Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "warehouse_foreign_2",
                        column: x => x.warehouse_id,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_foreign_3",
                        column: x => x.wine_id,
                        principalTable: "Wine",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    additional_import_request_id = table.Column<long>(type: "bigint", nullable: true),
                    export_request_id = table.Column<long>(type: "bigint", nullable: true),
                    import_request_id = table.Column<long>(type: "bigint", nullable: true),
                    inventory_check_request_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    damage_report = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    discrepancies_found = table.Column<int>(type: "int", nullable: true),
                    file_attachment = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    final_approval_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    import_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    items_imported = table.Column<int>(type: "int", nullable: true),
                    prepared_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    report_description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    report_prepared_by = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    report_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    review_comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    sign_off_by = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    supplier_feedback = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("report_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "additional_import_request_foreign",
                        column: x => x.additional_import_request_id,
                        principalTable: "Additional_Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "export_request_foreign",
                        column: x => x.export_request_id,
                        principalTable: "Export_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "import_request_foreign",
                        column: x => x.import_request_id,
                        principalTable: "Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "inventory_check_request_foreign",
                        column: x => x.inventory_check_request_id,
                        principalTable: "Inventory_Check_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_foreign_6",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Export_Wine_Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    export_request_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_warehouse_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Export_W__3213E83FDCC5E67C", x => x.id);
                    table.ForeignKey(
                        name: "export_request_foreign_2",
                        column: x => x.export_request_id,
                        principalTable: "Export_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_warehouse_foreign",
                        column: x => x.wine_warehouse_id,
                        principalTable: "Wine_Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_export_request_id",
                table: "Additional_Import_Request",
                column: "export_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_import_request_id",
                table: "Additional_Import_Request",
                column: "import_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_inventory_check_request_id",
                table: "Additional_Import_Request",
                column: "inventory_check_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_user_id",
                table: "Additional_Import_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Log_user_id",
                table: "Audit_Log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Check_Request_Warehouse_inventory_check_request_id",
                table: "Check_Request_Warehouse",
                column: "inventory_check_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Check_Request_Warehouse_warehouse_id",
                table: "Check_Request_Warehouse",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Request_user_id",
                table: "Export_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Request_wine_id",
                table: "Export_Request",
                column: "wine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Wine_Warehouse_export_request_id",
                table: "Export_Wine_Warehouse",
                column: "export_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Wine_Warehouse_wine_warehouse_id",
                table: "Export_Wine_Warehouse",
                column: "wine_warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Import_Request_user_id",
                table: "Import_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Import_Request_wine_id",
                table: "Import_Request",
                column: "wine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Check_Request_user_id",
                table: "Inventory_Check_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_user_id",
                table: "Report",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__42A76907FBF5270C",
                table: "Report",
                column: "export_request_id",
                unique: true,
                filter: "[export_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__554DA09A96662158",
                table: "Report",
                column: "additional_import_request_id",
                unique: true,
                filter: "[additional_import_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__8099F7E53B1391DC",
                table: "Report",
                column: "inventory_check_request_id",
                unique: true,
                filter: "[inventory_check_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__C75CF497B655D9AD",
                table: "Report",
                column: "import_request_id",
                unique: true,
                filter: "[import_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_Warehouse_import_request_id",
                table: "Wine_Warehouse",
                column: "import_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_Warehouse_warehouse_id",
                table: "Wine_Warehouse",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_Warehouse_wine_id",
                table: "Wine_Warehouse",
                column: "wine_id");

            migrationBuilder.AddForeignKey(
                name: "wine_category_foreign",
                table: "Wine",
                column: "wine_category_id",
                principalTable: "Wine_Category",
                principalColumn: "id");
        }
    }
}
