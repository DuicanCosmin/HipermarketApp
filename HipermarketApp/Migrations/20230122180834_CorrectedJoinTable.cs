using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HipermarketApp.Migrations
{
    public partial class CorrectedJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsSupplierDetails",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeadTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSupplierDetails", x => new { x.ProductID, x.SupplierID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsSupplierDetails");
        }
    }
}
