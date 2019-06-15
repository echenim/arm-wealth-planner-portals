using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HowToBegin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InvestmentManagement",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MoreInformation",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowToBegin",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestmentManagement",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoreInformation",
                table: "Products",
                nullable: true);
        }
    }
}
