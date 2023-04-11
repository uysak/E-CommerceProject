using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CargoDetails_CargoDetailId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CargoDetails");

            migrationBuilder.RenameColumn(
                name: "CargoDetailId",
                table: "Products",
                newName: "CargoFirmId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CargoDetailId",
                table: "Products",
                newName: "IX_Products_CargoFirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CargoFirms_CargoFirmId",
                table: "Products",
                column: "CargoFirmId",
                principalTable: "CargoFirms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CargoFirms_CargoFirmId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CargoFirmId",
                table: "Products",
                newName: "CargoDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CargoFirmId",
                table: "Products",
                newName: "IX_Products_CargoDetailId");

            migrationBuilder.CreateTable(
                name: "CargoDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirmId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CalculatedPrice = table.Column<double>(type: "double", nullable: false),
                    Desi = table.Column<double>(type: "double", nullable: false),
                    ExtraCharge = table.Column<double>(type: "double", nullable: true),
                    HasFee = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoDetails_CargoFirms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "CargoFirms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_FirmId",
                table: "CargoDetails",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_ProductId",
                table: "CargoDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CargoDetails_CargoDetailId",
                table: "Products",
                column: "CargoDetailId",
                principalTable: "CargoDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
