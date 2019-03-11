using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartNoOrCustomerIdentifier",
                table: "Carts",
                newName: "IpIdentifier");

            migrationBuilder.AddColumn<string>(
                name: "EmailIdentifier",
                table: "Carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailIdentifier",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "IpIdentifier",
                table: "Carts",
                newName: "CartNoOrCustomerIdentifier");
        }
    }
}
