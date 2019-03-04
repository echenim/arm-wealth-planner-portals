using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "MemberShip",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(nullable: false),
                    Number = table.Column<string>(maxLength: 15, nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberShip_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_Name",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberShip_Number",
                table: "MemberShip",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberShip_PersonId",
                table: "MemberShip",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberShip");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_Name",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_Person_Email",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
