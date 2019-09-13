using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpcot.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    DatePlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyOrders_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    DatePlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellOrders_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    ExecutedDate = table.Column<DateTime>(nullable: false),
                    BuyOrderId = table.Column<int>(nullable: true),
                    SellOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_BuyOrders_BuyOrderId",
                        column: x => x.BuyOrderId,
                        principalTable: "BuyOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trades_SellOrders_SellOrderId",
                        column: x => x.SellOrderId,
                        principalTable: "SellOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trades_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Barclays" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Vattenfall" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Skania" });

            migrationBuilder.CreateIndex(
                name: "IX_BuyOrders_StockId",
                table: "BuyOrders",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrders_StockId",
                table: "SellOrders",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_BuyOrderId",
                table: "Trades",
                column: "BuyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SellOrderId",
                table: "Trades",
                column: "SellOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_StockId",
                table: "Trades",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "BuyOrders");

            migrationBuilder.DropTable(
                name: "SellOrders");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
