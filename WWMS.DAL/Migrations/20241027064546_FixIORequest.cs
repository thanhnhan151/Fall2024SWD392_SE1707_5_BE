using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixIORequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckerName",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "IORequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "IORequest",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
