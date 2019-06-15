using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProspectCode",
                table: "Person",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MembershipNumber",
                table: "ClientUpdateTemps",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProspectCode",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipNumber",
                table: "ClientUpdateTemps",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
