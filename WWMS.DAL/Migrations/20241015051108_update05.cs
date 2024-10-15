using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "Wines",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "Wines",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "Wines",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "Wines",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "Wines",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Wines",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "WineRooms",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "WineRooms",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "WineRooms",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "WineRooms",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "WineRooms",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "WineRooms",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "WineCategories",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "WineCategories",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "WineCategories",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "WineCategories",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "WineCategories",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "WineCategories",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "Users",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "Users",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "Users",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "Users",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "Users",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Users",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "Rooms",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "Rooms",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "Rooms",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "Rooms",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "Rooms",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Rooms",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "IORequests",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "IORequests",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "IORequests",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "IORequests",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "IORequests",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "IORequests",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "IORequestDetails",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "IORequestDetails",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "IORequestDetails",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "IORequestDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "IORequestDetails",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "IORequestDetails",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "CheckRequests",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "CheckRequests",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "CheckRequests",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "CheckRequests",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "CheckRequests",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "CheckRequests",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "CheckRequestDetails",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "CheckRequestDetails",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "deletedTime",
                table: "CheckRequestDetails",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "CheckRequestDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "CheckRequestDetails",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "CheckRequestDetails",
                newName: "CreatedBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "Wines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Wines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "Rooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Rooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "IORequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "IORequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "IORequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "IORequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "IORequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "IORequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "IORequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "IORequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "CheckRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CheckRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CheckRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "CheckRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CheckRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "CheckRequestDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CheckRequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CheckRequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "CheckRequestDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CheckRequestDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Wines",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Wines",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Wines",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Wines",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Wines",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Wines",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "WineRooms",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "WineRooms",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "WineRooms",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "WineRooms",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "WineRooms",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "WineRooms",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "WineCategories",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "WineCategories",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "WineCategories",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "WineCategories",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "WineCategories",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "WineCategories",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Users",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Users",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Users",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Users",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Users",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Users",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Rooms",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Rooms",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Rooms",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Rooms",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Rooms",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Rooms",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "IORequests",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "IORequests",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "IORequests",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "IORequests",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "IORequests",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "IORequests",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "IORequestDetails",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "IORequestDetails",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "IORequestDetails",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "IORequestDetails",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "IORequestDetails",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "IORequestDetails",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "CheckRequests",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "CheckRequests",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "CheckRequests",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "CheckRequests",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "CheckRequests",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "CheckRequests",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "CheckRequestDetails",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "CheckRequestDetails",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "CheckRequestDetails",
                newName: "deletedTime");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "CheckRequestDetails",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "CheckRequestDetails",
                newName: "createdTime");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "CheckRequestDetails",
                newName: "createdBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "Wines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "Wines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "WineRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "WineRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "WineCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "WineCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "IORequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "IORequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "deletedBy",
                table: "IORequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "IORequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "IORequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "deletedBy",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "IORequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "IORequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "CheckRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "CheckRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "deletedBy",
                table: "CheckRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "CheckRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "CheckRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedTime",
                table: "CheckRequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "CheckRequestDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "deletedBy",
                table: "CheckRequestDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdTime",
                table: "CheckRequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "CheckRequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
