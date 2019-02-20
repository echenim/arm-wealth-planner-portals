using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
