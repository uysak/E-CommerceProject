using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cargodetailupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CargoDetails");

            migrationBuilder.AddColumn<double>(
                name: "CalculatedPrice",
                table: "CargoDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Desi",
                table: "CargoDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CargoDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_ProductId",
                table: "CargoDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_Products_ProductId",
                table: "CargoDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_Products_ProductId",
                table: "CargoDetails");

            migrationBuilder.DropIndex(
                name: "IX_CargoDetails_ProductId",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "CalculatedPrice",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "Desi",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CargoDetails");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ProductRate",
                table: "Products",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CargoDetails",
                type: "double",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
