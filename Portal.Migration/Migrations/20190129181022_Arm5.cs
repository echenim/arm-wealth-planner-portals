using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class Arm5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomerOnboardingDate",
                table: "AspNetUser",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomerOnboardingDate",
                table: "AspNetUser",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
