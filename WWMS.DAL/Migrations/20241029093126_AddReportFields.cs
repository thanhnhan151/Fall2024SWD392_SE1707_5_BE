using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReportFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualQuantity",
                table: "IORequestDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscrepanciesFound",
                table: "IORequestDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportCode",
                table: "IORequestDetail",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReportDescription",
                table: "IORequestDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportFile",
                table: "IORequestDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterAssigned",
                table: "IORequestDetail",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualQuantity",
                table: "IORequestDetail");

            migrationBuilder.DropColumn(
                name: "DiscrepanciesFound",
                table: "IORequestDetail");

            migrationBuilder.DropColumn(
                name: "ReportCode",
                table: "IORequestDetail");

            migrationBuilder.DropColumn(
                name: "ReportDescription",
                table: "IORequestDetail");

            migrationBuilder.DropColumn(
                name: "ReportFile",
                table: "IORequestDetail");

            migrationBuilder.DropColumn(
                name: "ReporterAssigned",
                table: "IORequestDetail");
        }
    }
}
