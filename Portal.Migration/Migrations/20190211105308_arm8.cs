using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDebit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirectDebitReference = table.Column<string>(nullable: true),
                    StatusCode = table.Column<string>(nullable: true),
                    StatusMessage = table.Column<string>(nullable: true),
                    DebitAmount = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    CardMask = table.Column<string>(nullable: true),
                    AmountApproved = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDebit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDebit");
        }
    }
}
