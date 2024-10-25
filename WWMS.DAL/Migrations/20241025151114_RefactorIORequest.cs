using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorIORequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableStock",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Wine");

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "IORequest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SuplierId",
                table: "IORequest",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suplier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IORequest_CustomerId",
                table: "IORequest",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IORequest_SuplierId",
                table: "IORequest",
                column: "SuplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_IORequest_Customer_CustomerId",
                table: "IORequest",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IORequest_Suplier_SuplierId",
                table: "IORequest",
                column: "SuplierId",
                principalTable: "Suplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IORequest_Customer_CustomerId",
                table: "IORequest");

            migrationBuilder.DropForeignKey(
                name: "FK_IORequest_Suplier_SuplierId",
                table: "IORequest");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Suplier");

            migrationBuilder.DropIndex(
                name: "IX_IORequest_CustomerId",
                table: "IORequest");

            migrationBuilder.DropIndex(
                name: "IX_IORequest_SuplierId",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "IORequest");

            migrationBuilder.DropColumn(
                name: "SuplierId",
                table: "IORequest");

            migrationBuilder.AddColumn<int>(
                name: "AvailableStock",
                table: "Wine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Wine",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
