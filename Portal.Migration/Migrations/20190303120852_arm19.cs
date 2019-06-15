using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvestmentInfo_Products_ProductId",
                table: "ProductInvestmentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductId",
                table: "WhatYouNeedToKNowAboutThisProduct");

            migrationBuilder.DropIndex(
                name: "IX_WhatYouNeedToKNowAboutThisProduct_ProductId",
                table: "WhatYouNeedToKNowAboutThisProduct");

            migrationBuilder.DropIndex(
                name: "IX_ProductInvestmentInfo_ProductId",
                table: "ProductInvestmentInfo");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "ProductInvestmentInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CartNumber = table.Column<string>(maxLength: 40, nullable: false),
                    AddToCartDate = table.Column<DateTime>(nullable: false),
                    PaymentTransactionNumber = table.Column<string>(maxLength: 150, nullable: true),
                    TransactionStatus = table.Column<string>(maxLength: 15, nullable: false),
                    OrderDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Person_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhatYouNeedToKNowAboutThisProduct_ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvestmentInfo_ProductsId",
                table: "ProductInvestmentInfo",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CustomerId",
                table: "PurchaseOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProductId",
                table: "PurchaseOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvestmentInfo_Products_ProductsId",
                table: "ProductInvestmentInfo",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvestmentInfo_Products_ProductsId",
                table: "ProductInvestmentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_WhatYouNeedToKNowAboutThisProduct_ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct");

            migrationBuilder.DropIndex(
                name: "IX_ProductInvestmentInfo_ProductsId",
                table: "ProductInvestmentInfo");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "ProductInvestmentInfo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatYouNeedToKNowAboutThisProduct_ProductId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvestmentInfo_ProductId",
                table: "ProductInvestmentInfo",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvestmentInfo_Products_ProductId",
                table: "ProductInvestmentInfo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
