using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlcoholContent",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "BottleSize",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "WineType",
                table: "WineCategories");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "AlcoholByVolumeId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BottleSizeId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ClassId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CorkId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "ExportPrice",
                table: "Wines",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ImportPrice",
                table: "Wines",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "QualificationId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TasteId",
                table: "Wines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "WineCategories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AlcoholByVolume",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlcoholByVolumeType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholByVolume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BottleSize",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BottleSizeType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottleSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cork",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorkType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taste",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasteType = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taste", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wines_AlcoholByVolumeId",
                table: "Wines",
                column: "AlcoholByVolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_BottleSizeId",
                table: "Wines",
                column: "BottleSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_BrandId",
                table: "Wines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_ClassId",
                table: "Wines",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_CorkId",
                table: "Wines",
                column: "CorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_CountryId",
                table: "Wines",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_QualificationId",
                table: "Wines",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_TasteId",
                table: "Wines",
                column: "TasteId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

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

            migrationBuilder.DropTable(
                name: "AlcoholByVolume");

            migrationBuilder.DropTable(
                name: "BottleSize");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Cork");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Taste");

            migrationBuilder.DropIndex(
                name: "IX_Wines_AlcoholByVolumeId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_BottleSizeId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_BrandId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_ClassId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_CorkId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_CountryId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_QualificationId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_TasteId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AlcoholByVolumeId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "BottleSizeId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "CorkId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "ExportPrice",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "ImportPrice",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "TasteId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AddColumn<decimal>(
                name: "AlcoholContent",
                table: "Wines",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottleSize",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "WineCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WineCategories",
                type: "nvarchar(500)",
                maxLength: 500,
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
                name: "Role",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
