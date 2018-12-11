using Microsoft.EntityFrameworkCore.Migrations;

namespace StephenJoshFinalProject.Migrations.StephenJoshFinalProject2
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeShopLogin",
                columns: table => new
                {
                    CoffeeShopLoginId = table.Column<string>(nullable: false),
                    StoreCode = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShopLogin", x => x.CoffeeShopLoginId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeShopLogin");
        }
    }
}
