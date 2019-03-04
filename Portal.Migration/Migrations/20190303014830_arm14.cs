using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductInvestmentInfo",
                newName: "Abs");

            migrationBuilder.AddColumn<string>(
                name: "RangOrCost",
                table: "ProductInvestmentInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RangOrCost",
                table: "ProductInvestmentInfo");

            migrationBuilder.RenameColumn(
                name: "Abs",
                table: "ProductInvestmentInfo",
                newName: "Title");
        }
    }
}
