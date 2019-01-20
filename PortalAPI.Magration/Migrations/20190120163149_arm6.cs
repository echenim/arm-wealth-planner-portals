using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalAPI.Magration.Migrations
{
    public partial class arm6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsExpressionOfInterest",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExpressionOfInterest",
                table: "Products");
        }
    }
}