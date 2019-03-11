using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsVoucher",
                table: "Products",
                newName: "IsVouchering");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsVouchering",
                table: "Products",
                newName: "IsVoucher");
        }
    }
}