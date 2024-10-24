using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorWineRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IORequest_User_UserId",
                table: "IORequest");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_IORequestDetail_WineRoom_WineRoomId",
            //    table: "IORequestDetail");

            //migrationBuilder.DropIndex(
            //    name: "IX_IORequestDetail_WineRoomId",
            //    table: "IORequestDetail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WineCategory");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "WineCategory");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "WineCategory");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "WineCategory");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WineCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "WineCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "WineCategory");

            //migrationBuilder.DropColumn(
            //    name: "WineRoomId",
            //    table: "IORequestDetail");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                table: "WineRoom",
                newName: "InitialQuantity");

            //migrationBuilder.RenameColumn(
            //    name: "UserId",
            //    table: "IORequest",
            //    newName: "CheckerId");

            migrationBuilder.RenameIndex(
                name: "IX_IORequest_UserId",
                table: "IORequest",
                newName: "IX_IORequest_CheckerId");

            migrationBuilder.AddColumn<int>(
                name: "Export",
                table: "WineRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Import",
                table: "WineRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_IORequest_User_CheckerId",
                table: "IORequest",
                column: "CheckerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IORequest_User_CheckerId",
                table: "IORequest");

            //migrationBuilder.DropColumn(
            //    name: "CurrentQuantity",
            //    table: "WineRoom");

            migrationBuilder.DropColumn(
                name: "Export",
                table: "WineRoom");

            migrationBuilder.DropColumn(
                name: "Import",
                table: "WineRoom");

            migrationBuilder.RenameColumn(
                name: "InitialQuantity",
                table: "WineRoom",
                newName: "TotalQuantity");

            //migrationBuilder.RenameColumn(
            //    name: "CheckerId",
            //    table: "IORequest",
            //    newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IORequest_CheckerId",
                table: "IORequest",
                newName: "IX_IORequest_UserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WineCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "WineCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "WineCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "WineCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WineCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "WineCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "WineCategory",
                type: "datetime2",
                nullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "WineRoomId",
            //    table: "IORequestDetail",
            //    type: "bigint",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_IORequestDetail_WineRoomId",
            //    table: "IORequestDetail",
            //    column: "WineRoomId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_IORequest_User_UserId",
            //    table: "IORequest",
            //    column: "UserId",
            //    principalTable: "User",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_IORequestDetail_WineRoom_WineRoomId",
            //    table: "IORequestDetail",
            //    column: "WineRoomId",
            //    principalTable: "WineRoom",
            //    principalColumn: "Id");
        }
    }
}
