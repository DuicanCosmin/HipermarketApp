using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HipermarketApp.Migrations
{
    public partial class addedClasses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SellPrice");

            migrationBuilder.AddColumn<long>(
                name: "SafetyStock",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZoneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Location_Zones_ZoneID",
                        column: x => x.ZoneID,
                        principalTable: "Zones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductsID = table.Column<int>(type: "int", nullable: false),
                    SuppliersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductsID, x.SuppliersID });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Suppliers_SuppliersID",
                        column: x => x.SuppliersID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_ZoneID",
                table: "Location",
                column: "ZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SuppliersID",
                table: "ProductSupplier",
                column: "SuppliersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropColumn(
                name: "SafetyStock",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Products",
                newName: "Price");
        }
    }
}
