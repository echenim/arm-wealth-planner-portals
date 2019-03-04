using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvestmentInfo_Products_ProductsId",
                table: "ProductInvestmentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "ProductInvestmentInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WhatYouNeedToKNowAboutThisProduct_ProductsId",
                table: "WhatYouNeedToKNowAboutThisProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvestmentInfo_ProductsId",
                table: "ProductInvestmentInfo",
                column: "ProductsId");

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
    }
}
