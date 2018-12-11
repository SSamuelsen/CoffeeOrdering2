using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StephenJoshFinalProject.Migrations.StephenJoshFinalProject3
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrinkName",
                columns: table => new
                {
                    DrinkNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Americano = table.Column<bool>(nullable: false),
                    Carmelo = table.Column<bool>(nullable: false),
                    Nova = table.Column<bool>(nullable: false),
                    HotChocolate = table.Column<bool>(nullable: false),
                    Tea = table.Column<bool>(nullable: false),
                    LondonFog = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkName", x => x.DrinkNameId);
                });

            migrationBuilder.CreateTable(
                name: "DrinkSpecs",
                columns: table => new
                {
                    DrinkSpecsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tall = table.Column<bool>(nullable: false),
                    Grande = table.Column<bool>(nullable: false),
                    Iced = table.Column<bool>(nullable: false),
                    Hot = table.Column<bool>(nullable: false),
                    Frozen = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SpecialRequests = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkSpecs", x => x.DrinkSpecsId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderTotal = table.Column<double>(nullable: false),
                    PickUpTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "UserSubmittedOrder",
                columns: table => new
                {
                    UserSubmittedOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrinkNameId = table.Column<int>(nullable: true),
                    DrinkSpecsId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubmittedOrder", x => x.UserSubmittedOrderId);
                    table.ForeignKey(
                        name: "FK_UserSubmittedOrder_DrinkName_DrinkNameId",
                        column: x => x.DrinkNameId,
                        principalTable: "DrinkName",
                        principalColumn: "DrinkNameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubmittedOrder_DrinkSpecs_DrinkSpecsId",
                        column: x => x.DrinkSpecsId,
                        principalTable: "DrinkSpecs",
                        principalColumn: "DrinkSpecsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubmittedOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmittedOrder_DrinkNameId",
                table: "UserSubmittedOrder",
                column: "DrinkNameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmittedOrder_DrinkSpecsId",
                table: "UserSubmittedOrder",
                column: "DrinkSpecsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmittedOrder_OrderId",
                table: "UserSubmittedOrder",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSubmittedOrder");

            migrationBuilder.DropTable(
                name: "DrinkName");

            migrationBuilder.DropTable(
                name: "DrinkSpecs");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
