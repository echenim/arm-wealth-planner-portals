﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.AddMigration;

namespace Portal.AddMigration.Migrations
{
    [DbContext(typeof(MigDbContext))]
    partial class MigDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserLogin<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<long>");
                });

            modelBuilder.Entity("Portal.Domain.Models.Carts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CartNoOrCustomerIdentifier")
                        .IsRequired();

                    b.Property<DateTime>("OnCartDateTime");

                    b.Property<int>("ProductId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Portal.Domain.Models.ClientUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EvaluationStatus");

                    b.Property<bool?>("IsKYCApproved");

                    b.Property<bool?>("IsPassportApproved");

                    b.Property<bool?>("IsSignatureApproved");

                    b.Property<bool?>("IsThumbprintApproved");

                    b.Property<bool?>("IsValidIdApproved");

                    b.Property<string>("Jurisdiction");

                    b.Property<int>("MembershipNumber");

                    b.Property<byte[]>("Passport");

                    b.Property<string>("ProgressStatus");

                    b.Property<byte[]>("Signature");

                    b.Property<string>("TaxNumber");

                    b.Property<byte[]>("Thumbprint");

                    b.Property<byte[]>("ValidID");

                    b.HasKey("Id");

                    b.ToTable("ClientUpdate");
                });

            modelBuilder.Entity("Portal.Domain.Models.ClientUpdateTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EvaluationStatus");

                    b.Property<bool?>("IsKYCApproved");

                    b.Property<bool?>("IsPassportApproved");

                    b.Property<bool?>("IsSignatureApproved");

                    b.Property<bool?>("IsThumbprintApproved");

                    b.Property<bool?>("IsValidIdApproved");

                    b.Property<string>("Jurisdiction");

                    b.Property<int>("MembershipNumber");

                    b.Property<byte[]>("Passport");

                    b.Property<string>("ProgressStatus");

                    b.Property<byte[]>("Signature");

                    b.Property<string>("TaxNumber");

                    b.Property<byte[]>("Thumbprint");

                    b.Property<byte[]>("ValidID");

                    b.HasKey("Id");

                    b.ToTable("ClientUpdateTemps");
                });

            modelBuilder.Entity("Portal.Domain.Models.DDebit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountApproved");

                    b.Property<string>("CardMask");

                    b.Property<string>("CardType");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("CustomerId");

                    b.Property<decimal>("DebitAmount");

                    b.Property<string>("DirectDebitReference");

                    b.Property<string>("StatusCode");

                    b.Property<string>("StatusMessage");

                    b.HasKey("Id");

                    b.ToTable("DDebit");
                });

            modelBuilder.Entity("Portal.Domain.Models.DirectDebit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<int>("ArmCustomerId");

                    b.Property<string>("ArmCustomerName");

                    b.Property<int>("ArmDdAmt");

                    b.Property<string>("ArmFrequency");

                    b.Property<string>("ArmHash");

                    b.Property<string>("ArmPaymentParams");

                    b.Property<DateTime>("ArmStartDate");

                    b.Property<string>("ArmTranxNotiUrl");

                    b.Property<string>("ArmVendorUserName");

                    b.HasKey("Id");

                    b.ToTable("DirectDebit");
                });

            modelBuilder.Entity("Portal.Domain.Models.DirectDebitTransactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ArmCustomerId");

                    b.Property<string>("ArmCustomerName");

                    b.Property<decimal>("ArmDdAmt");

                    b.Property<string>("ArmDdNotiUrl");

                    b.Property<string>("ArmFrequency");

                    b.Property<string>("ArmHash");

                    b.Property<string>("ArmPaymentParams");

                    b.Property<DateTime>("ArmStartDate");

                    b.Property<string>("ArmVendorUsername");

                    b.Property<string>("ArmXmlData");

                    b.HasKey("Id");

                    b.ToTable("DirectDebitTransactions");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.HasKey("Id");

                    b.ToTable("ApplicationGroup");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationGroupRole", b =>
                {
                    b.Property<long>("ApplicationRoleId");

                    b.Property<long>("ApplicationGroupId");

                    b.HasKey("ApplicationRoleId", "ApplicationGroupId");

                    b.HasIndex("ApplicationGroupId");

                    b.ToTable("ApplicationGroupRoles");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("RoleGroupName");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRole");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<long>("PersonId");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PersonId");

                    b.ToTable("AspNetUser");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUserGroup", b =>
                {
                    b.Property<long>("ApplicationUserId");

                    b.Property<long>("ApplicationGroupId");

                    b.HasKey("ApplicationUserId", "ApplicationGroupId");

                    b.HasIndex("ApplicationGroupId");

                    b.ToTable("ApplicationUserGroups");
                });

            modelBuilder.Entity("Portal.Domain.Models.MemberShip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("OnCreated");

                    b.Property<long>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.ToTable("MemberShip");
                });

            modelBuilder.Entity("Portal.Domain.Models.PaymentTransactionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("DateSubmitted");

                    b.Property<string>("PaymentParameters");

                    b.Property<string>("PaymentReference");

                    b.Property<decimal>("TransactionAmount");

                    b.Property<string>("TransactionCurrency");

                    b.Property<string>("TransactionReference");

                    b.Property<string>("TransactionStatusCode");

                    b.Property<string>("TransactionStatusMessage");

                    b.HasKey("Id");

                    b.ToTable("PaymentTransactionStatuses");
                });

            modelBuilder.Entity("Portal.Domain.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BioetricVerificationNumber")
                        .HasMaxLength(15);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("IsCustomer")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MemberShipNo");

                    b.Property<DateTime>("OnCreated");

                    b.Property<string>("PortalOnBoarding");

                    b.Property<string>("Tel")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Portal.Domain.Models.ProcessPayments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ArmCustomerId");

                    b.Property<string>("ArmCustomerName");

                    b.Property<string>("ArmHash");

                    b.Property<string>("ArmPaymentParams");

                    b.Property<string>("ArmTranxAmount");

                    b.Property<string>("ArmTranxCurr");

                    b.Property<string>("ArmTranxId");

                    b.Property<string>("ArmTranxNotiUrl");

                    b.Property<string>("ArmVendorUserName");

                    b.Property<string>("ArmXmlData");

                    b.Property<string>("PaymentRequest");

                    b.HasKey("Id");

                    b.ToTable("ProcessPayments");
                });

            modelBuilder.Entity("Portal.Domain.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Portal.Domain.Models.ProductInvestmentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abs")
                        .IsRequired();

                    b.Property<DateTime>("OnCreated");

                    b.Property<int>("ProductId");

                    b.Property<string>("RangOrCost");

                    b.Property<string>("Sections")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInvestmentInfo");
                });

            modelBuilder.Entity("Portal.Domain.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ProductCategoryId");

                    b.Property<string>("ProductTypes")
                        .IsRequired();

                    b.Property<decimal>("StartFrom")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Portal.Domain.Models.PurchaseOrders", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddToCartDate");

                    b.Property<decimal>("Amount");

                    b.Property<string>("CartNumber")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<long>("CustomerId");

                    b.Property<string>("OrderDate");

                    b.Property<string>("PaymentTransactionNumber")
                        .HasMaxLength(150);

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("Portal.Domain.Models.Redemption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("CustomerReference");

                    b.Property<string>("Reason");

                    b.Property<string>("ReasonOther");

                    b.Property<string>("RedeemedProducts");

                    b.HasKey("Id");

                    b.ToTable("Redemptions");
                });

            modelBuilder.Entity("Portal.Domain.Models.Referrer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OnCreated");

                    b.Property<long>("PersonId");

                    b.Property<string>("ReferrerEmail")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Referrer");
                });

            modelBuilder.Entity("Portal.Domain.Models.WhatYouNeedToKNowAboutThisProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Hierarchy");

                    b.Property<DateTime>("OnCreated");

                    b.Property<int>("ProductId");

                    b.Property<string>("Sections")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("WhatYouNeedToKNowAboutThisProduct");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>");

                    b.ToTable("AspNetRoleClaim");

                    b.HasDiscriminator().HasValue("ApplicationRoleClaim");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUserClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>");

                    b.ToTable("AspNetUserClaim");

                    b.HasDiscriminator().HasValue("ApplicationUserClaim");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUserLogin", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>");

                    b.ToTable("AspNetUserLogin");

                    b.HasDiscriminator().HasValue("ApplicationUserLogin");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<long>");

                    b.ToTable("AspNetUserRole");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUserToken", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserToken<long>");

                    b.ToTable("AspNetUserToken");

                    b.HasDiscriminator().HasValue("ApplicationUserToken");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Portal.Domain.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.Carts", b =>
                {
                    b.HasOne("Portal.Domain.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationGroupRole", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationGroup")
                        .WithMany("ApplicationRoles")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUser", b =>
                {
                    b.HasOne("Portal.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.Identity.ApplicationUserGroup", b =>
                {
                    b.HasOne("Portal.Domain.Models.Identity.ApplicationGroup")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.MemberShip", b =>
                {
                    b.HasOne("Portal.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.ProductInvestmentInfo", b =>
                {
                    b.HasOne("Portal.Domain.Models.Products", "Products")
                        .WithMany("ProductInvestmentInfos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.Products", b =>
                {
                    b.HasOne("Portal.Domain.Models.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.PurchaseOrders", b =>
                {
                    b.HasOne("Portal.Domain.Models.Person", "Person")
                        .WithMany("PurchaseOrderses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Portal.Domain.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.Referrer", b =>
                {
                    b.HasOne("Portal.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Portal.Domain.Models.WhatYouNeedToKNowAboutThisProduct", b =>
                {
                    b.HasOne("Portal.Domain.Models.Products", "Products")
                        .WithMany("WhatYouNeedToKNowAboutThisProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
