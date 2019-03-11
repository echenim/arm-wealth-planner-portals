using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsVoucher",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vouchering",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    VoucherCode = table.Column<string>(maxLength: 13, nullable: false),
                    VourcherPin = table.Column<string>(maxLength: 40, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExpiringDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchering_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vouchering_ProductId",
                table: "Vouchering",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vouchering");

            migrationBuilder.DropColumn(
                name: "IsVoucher",
                table: "Products");
        }
    }
}
