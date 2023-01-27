using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisuolorinapi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
                    PurchasedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSales_ProductStatus_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_Users_PurchasedBy",
                        column: x => x.PurchasedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SaleTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSaleId = table.Column<int>(type: "int", nullable: false),
                    SaleStatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleTrackings_ProductSales_ProductSaleId",
                        column: x => x.ProductSaleId,
                        principalTable: "ProductSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleTrackings_SaleStatus_SaleStatusId",
                        column: x => x.SaleStatusId,
                        principalTable: "SaleStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleTrackings_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_ProductId",
                table: "ProductSales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_ProductStatusId",
                table: "ProductSales",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_PurchasedBy",
                table: "ProductSales",
                column: "PurchasedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTrackings_ProductSaleId",
                table: "SaleTrackings",
                column: "ProductSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTrackings_SaleStatusId",
                table: "SaleTrackings",
                column: "SaleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTrackings_UpdatedBy",
                table: "SaleTrackings",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleTrackings");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "SaleStatus");

            migrationBuilder.DropTable(
                name: "ProductStatus");
        }
    }
}
