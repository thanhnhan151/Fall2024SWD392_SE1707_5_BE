using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckRequestDetails_CheckRequests_CheckRequestId",
                table: "CheckRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckRequestDetails_WineRooms_WineRoomId",
                table: "CheckRequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckRequests_Users_RequesterId",
                table: "CheckRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequestDetails_IORequests_IORequestId",
                table: "IORequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequestDetails_WineRooms_WineRoomId",
                table: "IORequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequests_Users_RequesterId",
                table: "IORequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WineRooms_Rooms_RoomId",
                table: "WineRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_WineRooms_Wines_WineId",
                table: "WineRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_AlcoholByVolume_AlcoholByVolumeId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_BottleSize_BottleSizeId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Brand_BrandId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Class_ClassId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Cork_CorkId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Country_CountryId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Qualification_QualificationId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Taste_TasteId",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_WineCategories_WineCategoryId",
                table: "Wines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wines",
                table: "Wines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineRooms",
                table: "WineRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineCategories",
                table: "WineCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IORequests",
                table: "IORequests");

            migrationBuilder.DropIndex(
                name: "IX_IORequests_RequesterId",
                table: "IORequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IORequestDetails",
                table: "IORequestDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckRequests",
                table: "CheckRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckRequestDetails",
                table: "CheckRequestDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "CurrQuantity",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "WineRooms");

            migrationBuilder.DropColumn(
                name: "PriorityLevel",
                table: "IORequests");

            migrationBuilder.DropColumn(
                name: "RequesterId",
                table: "IORequests");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "IORequests");

            migrationBuilder.DropColumn(
                name: "ActualQuantity",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "CheckerId",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "CheckerName",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "DiscrepanciesFound",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "IORequestCode",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "MFD",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "ReportCode",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "ReportDescription",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "ReportFile",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "ReporterAssigned",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "IORequestDetails");

            migrationBuilder.DropColumn(
                name: "WineName",
                table: "IORequestDetails");

            migrationBuilder.RenameTable(
                name: "Wines",
                newName: "Wine");

            migrationBuilder.RenameTable(
                name: "WineRooms",
                newName: "WineRoom");

            migrationBuilder.RenameTable(
                name: "WineCategories",
                newName: "WineCategory");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "IORequests",
                newName: "IORequest");

            migrationBuilder.RenameTable(
                name: "IORequestDetails",
                newName: "IORequestDetail");

            migrationBuilder.RenameTable(
                name: "CheckRequests",
                newName: "CheckRequest");

            migrationBuilder.RenameTable(
                name: "CheckRequestDetails",
                newName: "CheckRequestDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_WineCategoryId",
                table: "Wine",
                newName: "IX_Wine_WineCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_TasteId",
                table: "Wine",
                newName: "IX_Wine_TasteId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_QualificationId",
                table: "Wine",
                newName: "IX_Wine_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_CountryId",
                table: "Wine",
                newName: "IX_Wine_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_CorkId",
                table: "Wine",
                newName: "IX_Wine_CorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_ClassId",
                table: "Wine",
                newName: "IX_Wine_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_BrandId",
                table: "Wine",
                newName: "IX_Wine_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_BottleSizeId",
                table: "Wine",
                newName: "IX_Wine_BottleSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wines_AlcoholByVolumeId",
                table: "Wine",
                newName: "IX_Wine_AlcoholByVolumeId");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                table: "WineRoom",
                newName: "CurrentQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_WineRooms_WineId",
                table: "WineRoom",
                newName: "IX_WineRoom_WineId");

            migrationBuilder.RenameIndex(
                name: "IX_WineRooms_RoomId",
                table: "WineRoom",
                newName: "IX_WineRoom_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameColumn(
                name: "RequesterName",
                table: "IORequest",
                newName: "SupplierName");

            migrationBuilder.DropIndex(
                name: "IX_IORequestDetails_WineRoomId",
                table: "IORequestDetail");

            migrationBuilder.RenameIndex(
                name: "IX_IORequestDetails_IORequestId",
                table: "IORequestDetail",
                newName: "IX_IORequestDetail_IORequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckRequests_RequesterId",
                table: "CheckRequest",
                newName: "IX_CheckRequest_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckRequestDetails_WineRoomId",
                table: "CheckRequestDetail",
                newName: "IX_CheckRequestDetail_WineRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckRequestDetails_CheckRequestId",
                table: "CheckRequestDetail",
                newName: "IX_CheckRequestDetail_CheckRequestId");

            migrationBuilder.AddColumn<string>(
                name: "CheckerName",
                table: "IORequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "IORequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                table: "IORequest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CheckerId",
                table: "IORequest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "WineRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "WineRoomId",
                table: "IORequestDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wine",
                table: "Wine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineRoom",
                table: "WineRoom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineCategory",
                table: "WineCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IORequest",
                table: "IORequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IORequestDetail",
                table: "IORequestDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckRequest",
                table: "CheckRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckRequestDetail",
                table: "CheckRequestDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IORequest_RoomId",
                table: "IORequest",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_IORequest_UserId",
                table: "IORequest",
                column: "CheckerId");

            migrationBuilder.CreateIndex(
                name: "IX_IORequestDetail_WineId",
                table: "IORequestDetail",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRequest_User_RequesterId",
                table: "CheckRequest",
                column: "RequesterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRequestDetail_CheckRequest_CheckRequestId",
                table: "CheckRequestDetail",
                column: "CheckRequestId",
                principalTable: "CheckRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRequestDetail_WineRoom_WineRoomId",
                table: "CheckRequestDetail",
                column: "WineRoomId",
                principalTable: "WineRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IORequest_Room_RoomId",
                table: "IORequest",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IORequest_User_UserId",
                table: "IORequest",
                column: "CheckerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IORequestDetail_IORequest_IORequestId",
                table: "IORequestDetail",
                column: "IORequestId",
                principalTable: "IORequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);          

            migrationBuilder.AddForeignKey(
                name: "FK_IORequestDetail_Wine_WineId",
                table: "IORequestDetail",
                column: "WineId",
                principalTable: "Wine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_AlcoholByVolume_AlcoholByVolumeId",
                table: "Wine",
                column: "AlcoholByVolumeId",
                principalTable: "AlcoholByVolume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_BottleSize_BottleSizeId",
                table: "Wine",
                column: "BottleSizeId",
                principalTable: "BottleSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Brand_BrandId",
                table: "Wine",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Class_ClassId",
                table: "Wine",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Cork_CorkId",
                table: "Wine",
                column: "CorkId",
                principalTable: "Cork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Country_CountryId",
                table: "Wine",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Qualification_QualificationId",
                table: "Wine",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Taste_TasteId",
                table: "Wine",
                column: "TasteId",
                principalTable: "Taste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_WineCategory_WineCategoryId",
                table: "Wine",
                column: "WineCategoryId",
                principalTable: "WineCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WineRoom_Room_RoomId",
                table: "WineRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WineRoom_Wine_WineId",
                table: "WineRoom",
                column: "WineId",
                principalTable: "Wine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckRequest_User_RequesterId",
                table: "CheckRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckRequestDetail_CheckRequest_CheckRequestId",
                table: "CheckRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckRequestDetail_WineRoom_WineRoomId",
                table: "CheckRequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequest_Room_RoomId",
                table: "IORequest");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequest_User_UserId",
                table: "IORequest");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequestDetail_IORequest_IORequestId",
                table: "IORequestDetail");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_IORequestDetail_WineRoom_WineRoomId",
            //    table: "IORequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequestDetail_Wine_WineId",
                table: "IORequestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_AlcoholByVolume_AlcoholByVolumeId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_BottleSize_BottleSizeId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Brand_BrandId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Class_ClassId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Cork_CorkId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Country_CountryId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Qualification_QualificationId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Taste_TasteId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_Wine_WineCategory_WineCategoryId",
                table: "Wine");

            migrationBuilder.DropForeignKey(
                name: "FK_WineRoom_Room_RoomId",
                table: "WineRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_WineRoom_Wine_WineId",
                table: "WineRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineRoom",
                table: "WineRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineCategory",
                table: "WineCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wine",
                table: "Wine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IORequestDetail",
                table: "IORequestDetail");

            migrationBuilder.DropIndex(
                name: "IX_IORequestDetail_WineId",
                table: "IORequestDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IORequest",
                table: "IORequest");

            migrationBuilder.DropIndex(
                name: "IX_IORequest_RoomId",
                table: "IORequest");

            migrationBuilder.DropIndex(
                name: "IX_IORequest_UserId",
                table: "IORequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckRequestDetail",
                table: "CheckRequestDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckRequest",
                table: "CheckRequest");

            migrationBuilder.DropColumn(
                name: "CheckerName",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "IORequest");

            migrationBuilder.RenameTable(
                name: "WineRoom",
                newName: "WineRooms");

            migrationBuilder.RenameTable(
                name: "WineCategory",
                newName: "WineCategories");

            migrationBuilder.RenameTable(
                name: "Wine",
                newName: "Wines");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "IORequestDetail",
                newName: "IORequestDetails");

            migrationBuilder.RenameTable(
                name: "IORequest",
                newName: "IORequests");

            migrationBuilder.RenameTable(
                name: "CheckRequestDetail",
                newName: "CheckRequestDetails");

            migrationBuilder.RenameTable(
                name: "CheckRequest",
                newName: "CheckRequests");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "WineRooms",
                newName: "TotalQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_WineRoom_WineId",
                table: "WineRooms",
                newName: "IX_WineRooms_WineId");

            migrationBuilder.RenameIndex(
                name: "IX_WineRoom_RoomId",
                table: "WineRooms",
                newName: "IX_WineRooms_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_WineCategoryId",
                table: "Wines",
                newName: "IX_Wines_WineCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_TasteId",
                table: "Wines",
                newName: "IX_Wines_TasteId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_QualificationId",
                table: "Wines",
                newName: "IX_Wines_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_CountryId",
                table: "Wines",
                newName: "IX_Wines_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_CorkId",
                table: "Wines",
                newName: "IX_Wines_CorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_ClassId",
                table: "Wines",
                newName: "IX_Wines_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_BrandId",
                table: "Wines",
                newName: "IX_Wines_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_BottleSizeId",
                table: "Wines",
                newName: "IX_Wines_BottleSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wine_AlcoholByVolumeId",
                table: "Wines",
                newName: "IX_Wines_AlcoholByVolumeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_IORequestDetail_WineRoomId",
                table: "IORequestDetails",
                newName: "IX_IORequestDetails_WineRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_IORequestDetail_IORequestId",
                table: "IORequestDetails",
                newName: "IX_IORequestDetails_IORequestId");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "IORequests",
                newName: "RequesterName");

            migrationBuilder.RenameIndex(
                name: "IX_CheckRequestDetail_WineRoomId",
                table: "CheckRequestDetails",
                newName: "IX_CheckRequestDetails_WineRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckRequestDetail_CheckRequestId",
                table: "CheckRequestDetails",
                newName: "IX_CheckRequestDetails_CheckRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckRequest_RequesterId",
                table: "CheckRequests",
                newName: "IX_CheckRequests_RequesterId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrQuantity",
                table: "WineRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WineRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WineRoomId",
                table: "IORequestDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualQuantity",
                table: "IORequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CheckerId",
                table: "IORequestDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CheckerName",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "IORequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "IORequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscrepanciesFound",
                table: "IORequestDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IORequestCode",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MFD",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportCode",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReportDescription",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportFile",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterAssigned",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                table: "IORequestDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "IORequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WineName",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriorityLevel",
                table: "IORequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "RequesterId",
                table: "IORequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "IORequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineRooms",
                table: "WineRooms",
                column: "Id");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IORequestDetails",
                table: "IORequestDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IORequests",
                table: "IORequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckRequestDetails",
                table: "CheckRequestDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckRequests",
                table: "CheckRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IORequests_RequesterId",
                table: "IORequests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRequestDetails_CheckRequests_CheckRequestId",
                table: "CheckRequestDetails",
                column: "CheckRequestId",
                principalTable: "CheckRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRequestDetails_WineRooms_WineRoomId",
                table: "CheckRequestDetails",
                column: "WineRoomId",
                principalTable: "WineRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckRequests_Users_RequesterId",
                table: "CheckRequests",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IORequestDetails_IORequests_IORequestId",
                table: "IORequestDetails",
                column: "IORequestId",
                principalTable: "IORequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IORequestDetails_WineRooms_WineRoomId",
                table: "IORequestDetails",
                column: "WineRoomId",
                principalTable: "WineRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IORequests_Users_RequesterId",
                table: "IORequests",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WineRooms_Rooms_RoomId",
                table: "WineRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WineRooms_Wines_WineId",
                table: "WineRooms",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_AlcoholByVolume_AlcoholByVolumeId",
                table: "Wines",
                column: "AlcoholByVolumeId",
                principalTable: "AlcoholByVolume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_BottleSize_BottleSizeId",
                table: "Wines",
                column: "BottleSizeId",
                principalTable: "BottleSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Brand_BrandId",
                table: "Wines",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Class_ClassId",
                table: "Wines",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Cork_CorkId",
                table: "Wines",
                column: "CorkId",
                principalTable: "Cork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Country_CountryId",
                table: "Wines",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Qualification_QualificationId",
                table: "Wines",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Taste_TasteId",
                table: "Wines",
                column: "TasteId",
                principalTable: "Taste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_WineCategories_WineCategoryId",
                table: "Wines",
                column: "WineCategoryId",
                principalTable: "WineCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
