using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLib.Migrations
{
    public partial class InitialCatalogProductAddOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "AddOns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddOns_ProductId",
                table: "AddOns",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddOns_Products_ProductId",
                table: "AddOns",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddOns_Products_ProductId",
                table: "AddOns");

            migrationBuilder.DropIndex(
                name: "IX_AddOns_ProductId",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "AddOns");
        }
    }
}
