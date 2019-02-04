using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewOrOld",
                table: "AspNetUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleGroupName",
                table: "AspNetRole",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewOrOld",
                table: "AspNetUser");

            migrationBuilder.DropColumn(
                name: "RoleGroupName",
                table: "AspNetRole");
        }
    }
}
