using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailIdentifier",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "SessionTrackerIdentifier",
                table: "Carts",
                newName: "TransactionNo");

            migrationBuilder.CreateSequence(
                name: "DBTransManagerStartFrom10000000000",
                startValue: 10000000000L);

            migrationBuilder.AddColumn<string>(
                name: "OwnerIdentifier",
                table: "Carts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TransQIdenfier",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false, defaultValueSql: "NEXT VALUE FOR DBTransManagerStartFrom10000000000"),
                    Owner = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransQIdenfier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactional",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionNo = table.Column<long>(nullable: false),
                    ItemOwner = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderAndPurchaseStatus = table.Column<string>(maxLength: 15, nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactional_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactional_TransQIdenfier_TransactionNo",
                        column: x => x.TransactionNo,
                        principalTable: "TransQIdenfier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactional_ProductId",
                table: "Transactional",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactional_TransactionNo",
                table: "Transactional",
                column: "TransactionNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactional");

            migrationBuilder.DropTable(
                name: "TransQIdenfier");

            migrationBuilder.DropSequence(
                name: "DBTransManagerStartFrom10000000000");

            migrationBuilder.DropColumn(
                name: "OwnerIdentifier",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "TransactionNo",
                table: "Carts",
                newName: "SessionTrackerIdentifier");

            migrationBuilder.AddColumn<string>(
                name: "EmailIdentifier",
                table: "Carts",
                nullable: true);
        }
    }
}
