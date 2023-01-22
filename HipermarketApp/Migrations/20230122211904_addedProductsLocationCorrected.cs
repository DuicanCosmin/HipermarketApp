using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HipermarketApp.Migrations
{
    public partial class addedProductsLocationCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsOnLocation",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", precision: 14, scale: 2, nullable: false),
                    MinQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOnLocation", x => new { x.ProductId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_ProductsOnLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductsOnLocation_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSupplierDetails_SupplierID",
                table: "ProductsSupplierDetails",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOnLocation_LocationId",
                table: "ProductsOnLocation",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSupplierDetails_Products_ProductID",
                table: "ProductsSupplierDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSupplierDetails_Suppliers_SupplierID",
                table: "ProductsSupplierDetails",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSupplierDetails_Products_ProductID",
                table: "ProductsSupplierDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSupplierDetails_Suppliers_SupplierID",
                table: "ProductsSupplierDetails");

            migrationBuilder.DropTable(
                name: "ProductsOnLocation");

            migrationBuilder.DropIndex(
                name: "IX_ProductsSupplierDetails_SupplierID",
                table: "ProductsSupplierDetails");
        }
    }
}
