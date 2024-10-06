using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReporterNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "reporter_name",
                table: "Inventory_Check_Request",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reporter_name",
                table: "Import_Request",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reporter_name",
                table: "Export_Request",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reporter_name",
                table: "Additional_Import_Request",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reporter_name",
                table: "Inventory_Check_Request");

            migrationBuilder.DropColumn(
                name: "reporter_name",
                table: "Import_Request");

            migrationBuilder.DropColumn(
                name: "reporter_name",
                table: "Export_Request");

            migrationBuilder.DropColumn(
                name: "reporter_name",
                table: "Additional_Import_Request");
        }
    }
}
