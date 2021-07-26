using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLib.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    ParentCuisineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuisines_Cuisines_ParentCuisineId",
                        column: x => x.ParentCuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proviences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proviences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    ProvienceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Proviences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContactMob = table.Column<long>(type: "bigint", nullable: false),
                    ConatctTel = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Address = table.Column<string>(type: "varchar(max)", nullable: false),
                    ProvienceId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Discription = table.Column<string>(type: "varchar(max)", nullable: false),
                    SalesTax = table.Column<int>(type: "int", nullable: false),
                    OrderLedTime = table.Column<int>(type: "int", nullable: false),
                    PercentageCutOff = table.Column<int>(type: "int", nullable: false),
                    Reservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<byte[]>(type: "image", nullable: false),
                    Banner = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Proviences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuisineRestaurant",
                columns: table => new
                {
                    CuisinesId = table.Column<int>(type: "int", nullable: false),
                    RestaurantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineRestaurant", x => new { x.CuisinesId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_CuisineRestaurant_Cuisines_CuisinesId",
                        column: x => x.CuisinesId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuisineRestaurant_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCuisines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCuisines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCuisines_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    CuisineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_RestaurantCuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "RestaurantCuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_PostalCode",
                table: "Cities",
                columns: new[] { "Name", "PostalCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvienceId",
                table: "Cities",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineRestaurant_RestaurantsId",
                table: "CuisineRestaurant",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_ParentCuisineId",
                table: "Cuisines",
                column: "ParentCuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CuisineId",
                table: "Products",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RestaurantId",
                table: "Products",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Proviences_Name",
                table: "Proviences",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCuisines_RestaurantId",
                table: "RestaurantCuisines",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ProvienceId",
                table: "Restaurants",
                column: "ProvienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuisineRestaurant");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "RestaurantCuisines");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Proviences");
        }
    }
}
