using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLib.Migrations
{
    public partial class InitialCatalogUpdateCuisineState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisines_Cuisines_ParentCuisineId",
                table: "Cuisines");

            migrationBuilder.DropIndex(
                name: "IX_Cuisines_ParentCuisineId",
                table: "Cuisines");

            migrationBuilder.DropColumn(
                name: "ParentCuisineId",
                table: "Cuisines");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Cuisines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Cuisines");

            migrationBuilder.AddColumn<int>(
                name: "ParentCuisineId",
                table: "Cuisines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_ParentCuisineId",
                table: "Cuisines",
                column: "ParentCuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisines_Cuisines_ParentCuisineId",
                table: "Cuisines",
                column: "ParentCuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
