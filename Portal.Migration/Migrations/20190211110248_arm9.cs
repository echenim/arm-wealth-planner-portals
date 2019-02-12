using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.AddMigration.Migrations
{
    public partial class arm9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembershipNumber = table.Column<int>(nullable: false),
                    ProgressStatus = table.Column<string>(nullable: true),
                    EvaluationStatus = table.Column<string>(nullable: true),
                    Passport = table.Column<byte[]>(nullable: true),
                    Signature = table.Column<byte[]>(nullable: true),
                    Thumbprint = table.Column<byte[]>(nullable: true),
                    ValidID = table.Column<byte[]>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    Jurisdiction = table.Column<string>(nullable: true),
                    IsKYCApproved = table.Column<bool>(nullable: true),
                    IsPassportApproved = table.Column<bool>(nullable: true),
                    IsSignatureApproved = table.Column<bool>(nullable: true),
                    IsThumbprintApproved = table.Column<bool>(nullable: true),
                    IsValidIdApproved = table.Column<bool>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUpdate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientUpdateTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembershipNumber = table.Column<int>(nullable: false),
                    ProgressStatus = table.Column<string>(nullable: true),
                    EvaluationStatus = table.Column<string>(nullable: true),
                    Passport = table.Column<byte[]>(nullable: true),
                    Signature = table.Column<byte[]>(nullable: true),
                    Thumbprint = table.Column<byte[]>(nullable: true),
                    ValidID = table.Column<byte[]>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    Jurisdiction = table.Column<string>(nullable: true),
                    IsKYCApproved = table.Column<bool>(nullable: true),
                    IsPassportApproved = table.Column<bool>(nullable: true),
                    IsSignatureApproved = table.Column<bool>(nullable: true),
                    IsThumbprintApproved = table.Column<bool>(nullable: true),
                    IsValidIdApproved = table.Column<bool>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUpdateTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectDebit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    ArmVendorUserName = table.Column<string>(nullable: true),
                    ArmCustomerId = table.Column<int>(nullable: false),
                    ArmCustomerName = table.Column<string>(nullable: true),
                    ArmDdAmt = table.Column<int>(nullable: false),
                    ArmStartDate = table.Column<DateTime>(nullable: false),
                    ArmFrequency = table.Column<string>(nullable: true),
                    ArmTranxNotiUrl = table.Column<string>(nullable: true),
                    ArmPaymentParams = table.Column<string>(nullable: true),
                    ArmHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectDebit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectDebitTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    ArmVendorUsername = table.Column<string>(nullable: true),
                    ArmCustomerId = table.Column<string>(nullable: true),
                    ArmCustomerName = table.Column<string>(nullable: true),
                    ArmDdAmt = table.Column<decimal>(nullable: false),
                    ArmStartDate = table.Column<DateTime>(nullable: false),
                    ArmFrequency = table.Column<string>(nullable: true),
                    ArmDdNotiUrl = table.Column<string>(nullable: true),
                    ArmPaymentParams = table.Column<string>(nullable: true),
                    ArmHash = table.Column<string>(nullable: true),
                    ArmXmlData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectDebitTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionReference = table.Column<string>(nullable: true),
                    PaymentReference = table.Column<string>(nullable: true),
                    TransactionAmount = table.Column<decimal>(nullable: false),
                    TransactionStatusCode = table.Column<string>(nullable: true),
                    TransactionStatusMessage = table.Column<string>(nullable: true),
                    TransactionCurrency = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    PaymentParameters = table.Column<string>(nullable: true),
                    DateSubmitted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    ArmVendorUserName = table.Column<string>(nullable: true),
                    ArmTranxId = table.Column<string>(nullable: true),
                    ArmTranxAmount = table.Column<string>(nullable: true),
                    ArmCustomerId = table.Column<string>(nullable: true),
                    ArmCustomerName = table.Column<string>(nullable: true),
                    ArmTranxCurr = table.Column<string>(nullable: true),
                    ArmTranxNotiUrl = table.Column<string>(nullable: true),
                    ArmXmlData = table.Column<string>(nullable: true),
                    ArmPaymentParams = table.Column<string>(nullable: true),
                    PaymentRequest = table.Column<string>(nullable: true),
                    ArmHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redemptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerReference = table.Column<string>(nullable: true),
                    RedeemedProducts = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    ReasonOther = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redemptions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientUpdate");

            migrationBuilder.DropTable(
                name: "ClientUpdateTemps");

            migrationBuilder.DropTable(
                name: "DirectDebit");

            migrationBuilder.DropTable(
                name: "DirectDebitTransactions");

            migrationBuilder.DropTable(
                name: "PaymentTransactionStatuses");

            migrationBuilder.DropTable(
                name: "ProcessPayments");

            migrationBuilder.DropTable(
                name: "Redemptions");
        }
    }
}
