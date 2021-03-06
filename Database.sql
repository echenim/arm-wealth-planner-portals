ALTER TABLE [dbo].[WhatYouNeedToKNowAboutThisProduct] DROP CONSTRAINT [FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductId]
GO
ALTER TABLE [dbo].[Referrer] DROP CONSTRAINT [FK_Referrer_Person_PersonId]
GO
ALTER TABLE [dbo].[PurchaseOrders] DROP CONSTRAINT [FK_PurchaseOrders_Products_ProductId]
GO
ALTER TABLE [dbo].[PurchaseOrders] DROP CONSTRAINT [FK_PurchaseOrders_Person_CustomerId]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId]
GO
ALTER TABLE [dbo].[ProductInvestmentInfo] DROP CONSTRAINT [FK_ProductInvestmentInfo_Products_ProductId]
GO
ALTER TABLE [dbo].[MemberShip] DROP CONSTRAINT [FK_MemberShip_Person_PersonId]
GO
ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRole_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUser] DROP CONSTRAINT [FK_AspNetUser_Person_PersonId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRole_RoleId]
GO
ALTER TABLE [dbo].[ApplicationUserGroups] DROP CONSTRAINT [FK_ApplicationUserGroups_ApplicationGroup_ApplicationGroupId]
GO
ALTER TABLE [dbo].[ApplicationGroupRoles] DROP CONSTRAINT [FK_ApplicationGroupRoles_ApplicationGroup_ApplicationGroupId]
GO
/****** Object:  Table [dbo].[WhatYouNeedToKNowAboutThisProduct]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[WhatYouNeedToKNowAboutThisProduct]
GO
/****** Object:  Table [dbo].[Referrer]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[Referrer]
GO
/****** Object:  Table [dbo].[Redemptions]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[Redemptions]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[PurchaseOrders]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[ProductInvestmentInfo]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ProductInvestmentInfo]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ProductCategory]
GO
/****** Object:  Table [dbo].[ProcessPayments]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ProcessPayments]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[Person]
GO
/****** Object:  Table [dbo].[PaymentTransactionStatuses]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[PaymentTransactionStatuses]
GO
/****** Object:  Table [dbo].[MemberShip]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[MemberShip]
GO
/****** Object:  Table [dbo].[DirectDebitTransactions]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[DirectDebitTransactions]
GO
/****** Object:  Table [dbo].[DirectDebit]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[DirectDebit]
GO
/****** Object:  Table [dbo].[DDebit]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[DDebit]
GO
/****** Object:  Table [dbo].[ClientUpdateTemps]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ClientUpdateTemps]
GO
/****** Object:  Table [dbo].[ClientUpdate]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ClientUpdate]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetUserTokens]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetUser]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[AspNetRole]
GO
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ApplicationUserGroups]
GO
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ApplicationGroupRoles]
GO
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[ApplicationGroup]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/4/2019 1:29:47 PM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Owner] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApplicationGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationGroupRoles](
	[ApplicationGroupId] [bigint] NOT NULL,
	[ApplicationRoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_ApplicationGroupRoles] PRIMARY KEY CLUSTERED 
(
	[ApplicationRoleId] ASC,
	[ApplicationGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserGroups](
	[ApplicationUserId] [bigint] NOT NULL,
	[ApplicationGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_ApplicationUserGroups] PRIMARY KEY CLUSTERED 
(
	[ApplicationUserId] ASC,
	[ApplicationGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRole](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[RoleGroupName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[PersonId] [bigint] NOT NULL,
 CONSTRAINT [PK_AspNetUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [bigint] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [bigint] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientUpdate]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientUpdate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MembershipNumber] [int] NOT NULL,
	[ProgressStatus] [nvarchar](max) NULL,
	[EvaluationStatus] [nvarchar](max) NULL,
	[Passport] [varbinary](max) NULL,
	[Signature] [varbinary](max) NULL,
	[Thumbprint] [varbinary](max) NULL,
	[ValidID] [varbinary](max) NULL,
	[TaxNumber] [nvarchar](max) NULL,
	[Jurisdiction] [nvarchar](max) NULL,
	[IsKYCApproved] [bit] NULL,
	[IsPassportApproved] [bit] NULL,
	[IsSignatureApproved] [bit] NULL,
	[IsThumbprintApproved] [bit] NULL,
	[IsValidIdApproved] [bit] NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ClientUpdate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientUpdateTemps]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientUpdateTemps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MembershipNumber] [int] NOT NULL,
	[ProgressStatus] [nvarchar](max) NULL,
	[EvaluationStatus] [nvarchar](max) NULL,
	[Passport] [varbinary](max) NULL,
	[Signature] [varbinary](max) NULL,
	[Thumbprint] [varbinary](max) NULL,
	[ValidID] [varbinary](max) NULL,
	[TaxNumber] [nvarchar](max) NULL,
	[Jurisdiction] [nvarchar](max) NULL,
	[IsKYCApproved] [bit] NULL,
	[IsPassportApproved] [bit] NULL,
	[IsSignatureApproved] [bit] NULL,
	[IsThumbprintApproved] [bit] NULL,
	[IsValidIdApproved] [bit] NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ClientUpdateTemps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DDebit]    Script Date: 3/4/2019 1:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DDebit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DirectDebitReference] [nvarchar](max) NULL,
	[StatusCode] [nvarchar](max) NULL,
	[StatusMessage] [nvarchar](max) NULL,
	[DebitAmount] [decimal](18, 2) NOT NULL,
	[CustomerId] [nvarchar](max) NULL,
	[CardType] [nvarchar](max) NULL,
	[CardMask] [nvarchar](max) NULL,
	[AmountApproved] [decimal](18, 2) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DDebit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DirectDebit]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectDebit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](max) NULL,
	[ArmVendorUserName] [nvarchar](max) NULL,
	[ArmCustomerId] [int] NOT NULL,
	[ArmCustomerName] [nvarchar](max) NULL,
	[ArmDdAmt] [int] NOT NULL,
	[ArmStartDate] [datetime2](7) NOT NULL,
	[ArmFrequency] [nvarchar](max) NULL,
	[ArmTranxNotiUrl] [nvarchar](max) NULL,
	[ArmPaymentParams] [nvarchar](max) NULL,
	[ArmHash] [nvarchar](max) NULL,
 CONSTRAINT [PK_DirectDebit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DirectDebitTransactions]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectDebitTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](max) NULL,
	[ArmVendorUsername] [nvarchar](max) NULL,
	[ArmCustomerId] [nvarchar](max) NULL,
	[ArmCustomerName] [nvarchar](max) NULL,
	[ArmDdAmt] [decimal](18, 2) NOT NULL,
	[ArmStartDate] [datetime2](7) NOT NULL,
	[ArmFrequency] [nvarchar](max) NULL,
	[ArmDdNotiUrl] [nvarchar](max) NULL,
	[ArmPaymentParams] [nvarchar](max) NULL,
	[ArmHash] [nvarchar](max) NULL,
	[ArmXmlData] [nvarchar](max) NULL,
 CONSTRAINT [PK_DirectDebitTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberShip]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberShip](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonId] [bigint] NOT NULL,
	[Number] [nvarchar](15) NOT NULL,
	[OnCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MemberShip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTransactionStatuses]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTransactionStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionReference] [nvarchar](max) NULL,
	[PaymentReference] [nvarchar](max) NULL,
	[TransactionAmount] [decimal](18, 2) NOT NULL,
	[TransactionStatusCode] [nvarchar](max) NULL,
	[TransactionStatusMessage] [nvarchar](max) NULL,
	[TransactionCurrency] [nvarchar](max) NULL,
	[CustomerId] [nvarchar](max) NULL,
	[PaymentParameters] [nvarchar](max) NULL,
	[DateSubmitted] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PaymentTransactionStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Tel] [nvarchar](15) NULL,
	[BioetricVerificationNumber] [nvarchar](15) NULL,
	[IsCustomer] [bit] NOT NULL,
	[PortalOnBoarding] [nvarchar](max) NULL,
	[OnCreated] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[MemberShipNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessPayments]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](max) NULL,
	[ArmVendorUserName] [nvarchar](max) NULL,
	[ArmTranxId] [nvarchar](max) NULL,
	[ArmTranxAmount] [nvarchar](max) NULL,
	[ArmCustomerId] [nvarchar](max) NULL,
	[ArmCustomerName] [nvarchar](max) NULL,
	[ArmTranxCurr] [nvarchar](max) NULL,
	[ArmTranxNotiUrl] [nvarchar](max) NULL,
	[ArmXmlData] [nvarchar](max) NULL,
	[ArmPaymentParams] [nvarchar](max) NULL,
	[PaymentRequest] [nvarchar](max) NULL,
	[ArmHash] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProcessPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductInvestmentInfo]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInvestmentInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Sections] [nvarchar](max) NOT NULL,
	[Abs] [nvarchar](max) NOT NULL,
	[OnCreated] [datetime2](7) NOT NULL,
	[RangOrCost] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductInvestmentInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartFrom] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NOT NULL,
	[ProductTypes] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CartNumber] [nvarchar](40) NOT NULL,
	[AddToCartDate] [datetime2](7) NOT NULL,
	[PaymentTransactionNumber] [nvarchar](150) NULL,
	[TransactionStatus] [nvarchar](15) NOT NULL,
	[OrderDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_PurchaseOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Redemptions]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Redemptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerReference] [nvarchar](max) NULL,
	[RedeemedProducts] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Reason] [nvarchar](max) NULL,
	[ReasonOther] [nvarchar](max) NULL,
 CONSTRAINT [PK_Redemptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referrer]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referrer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonId] [bigint] NOT NULL,
	[ReferrerEmail] [nvarchar](max) NOT NULL,
	[OnCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Referrer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WhatYouNeedToKNowAboutThisProduct]    Script Date: 3/4/2019 1:29:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WhatYouNeedToKNowAboutThisProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Sections] [nvarchar](max) NOT NULL,
	[Hierarchy] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[OnCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_WhatYouNeedToKNowAboutThisProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190226083306_arm1', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190226085219_arm2', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190228054331_arm3', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190228055650_arm4', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190228060548_arm5', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190228064951_arm6', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190228072204_arm7', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190302151612_arm13', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303014830_arm14', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303051530_arm15', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303115617_arm16', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303115906_arm17', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303120523_arm18', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303120852_arm19', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190303125658_arm20', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190304071842_arm22', N'2.2.0-rtm-35687')
SET IDENTITY_INSERT [dbo].[AspNetUser] ON 

INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [PersonId]) VALUES (20002, N'ome.alika@marketmoni.com', N'OME.ALIKA@MARKETMONI.COM', N'ome.alika@marketmoni.com', N'OME.ALIKA@MARKETMONI.COM', 0, N'AQAAAAEAACcQAAAAEMuk+es6dDlEI+nlKrl6VTWkbXXFeAElKlaEOpvyzWcEoPtLUhYe/ZqGbDhptcBS5A==', N'FJWFFGY4UYE6CGTHJS53P3CYEKQTHK7P', N'9cebe165-8a0e-4348-b970-eab980c440f6', NULL, 0, 0, NULL, 1, 0, 30002)
SET IDENTITY_INSERT [dbo].[AspNetUser] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [Email], [Tel], [BioetricVerificationNumber], [IsCustomer], [PortalOnBoarding], [OnCreated], [Address], [MemberShipNo]) VALUES (30002, N'Ome', N'Alika', N'Female', N'ome.alika@marketmoni.com', N'+2347003290000', N'12345678901', 1, N'NPB', CAST(N'2019-03-04T06:41:00.7214384' AS DateTime2), N'17 Tinubu St, Lagos', NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (1002, N'Insurance')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (1, N'Mutual Funds')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (1003, N'Pension')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (4, N'Real Estate')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (3, N'Securities')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (2, N'Trustees')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[ProductInvestmentInfo] ON 

INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (1, 1003, N'Minimum Investment', N'Minimum initial investment', CAST(N'2019-03-03T13:04:52.5242830' AS DateTime2), N'1,000')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (2, 1003, N'Minimum Investment', N'Minimum additional investment', CAST(N'2019-03-03T13:05:48.6414949' AS DateTime2), N'1,000')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (3, 1003, N'Risk Level', N'Low', CAST(N'2019-03-03T13:08:12.3082494' AS DateTime2), NULL)
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (4, 1003, N'What the Fund invests in', N'Short-term government securities:', CAST(N'2019-03-03T13:08:53.1057652' AS DateTime2), N'25% – 95%')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (8, 1004, N'Minimum Investment', N'Minimum initial investment ', CAST(N'2019-03-03T15:24:09.9130753' AS DateTime2), N'50,000')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (9, 1004, N'Minimum Investment', N'Minimum additional investment', CAST(N'2019-03-03T15:24:33.7561479' AS DateTime2), N'10,000')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (10, 1004, N'Risk Level', N'High', CAST(N'2019-03-03T15:25:22.4866691' AS DateTime2), NULL)
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (11, 1004, N'What the Fund invests in', N'Equities:', CAST(N'2019-03-03T15:25:55.7459531' AS DateTime2), N'75% – 100%')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (12, 1004, N'What the Fund invests in', N'Fixed income securities: ', CAST(N'2019-03-03T15:26:12.4654369' AS DateTime2), N'0% – 25%')
INSERT [dbo].[ProductInvestmentInfo] ([Id], [ProductId], [Sections], [Abs], [OnCreated], [RangOrCost]) VALUES (1002, 1005, N'Minimum Investment', N'Minimum initial investment', CAST(N'2019-03-04T10:59:20.6416638' AS DateTime2), N'1,000')
SET IDENTITY_INSERT [dbo].[ProductInvestmentInfo] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (1003, 1, N'ARM Money Market Fund', CAST(0.00 AS Decimal(18, 2)), N'The ARM Money Market Fund offers a higher interest rate on your savings than a traditional savings account. And it doesn’t have to be long term; the ARM MMF allows you quick access to your money, competitive interest rates, regular tax free returns and expert fund management.', N'9ab4c86328b241edb5fc74bbff811943.jpeg', N'Enter Amount', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (1004, 1, N'ARM Aggressive Growth Fund', CAST(0.00 AS Decimal(18, 2)), N'Regardless of your risk appetite or investment goal, you’ll find a mutual fund that suits you just fine. Mutual funds typically pool funds from multiple investors and invest in verifiable instruments such as government bonds.

Although the interest rate offered on all our Mutual funds are not static, they are always competitive and substantial.', N'e937e590e577493e82f6833b85f1b1dd.jpeg', N'Voucher System', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (1005, 1, N'ARM Discovery Fund', CAST(0.00 AS Decimal(18, 2)), N'The ARM Money Market Fund offers a higher interest rate on your savings than a traditional savings account. And it doesn’t have to be long term; the ARM MMF allows you quick access to your money, competitive interest rates, regular tax free returns and expert fund management.', N'dd05123ef9d44212a9fb066d566b9507.jpeg', N'Voucher System', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (1006, 1, N'ARM Ethical Fund', CAST(0.00 AS Decimal(18, 2)), N'The ARM Money Market Fund offers a higher interest rate on your savings than a traditional savings account. And it doesn’t have to be long term; the ARM MMF allows you quick access to your money, competitive interest rates, regular tax free returns and expert fund management.', N'7572538370be4de99ba7201809fe8376.jpeg', N'Enter Amount', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (2008, 1003, N'Additional Voluntary Contribution', CAST(0.00 AS Decimal(18, 2)), N'Additional Voluntary Contribution (AVC) is an extra fund you can opt to add to your mandatory pension contributions, or simply set aside as retirement savings. These funds would be deducted from your monthly emolument by your employer and remitted into your ARM Pensions Retirement Savings Account (RSA), along with your regular pension contributions.', N'94ea0e003bd74e16a68057da1fbcb3ed.jpeg', N'Expression of Interest', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (2009, 1002, N'Life Protection Plan', CAST(10000.00 AS Decimal(18, 2)), N'Everyone worries about the future because you never know when you may fall ill or be unable to work. You also want to know that when you are gone, your family won’t be affected. If something happened to you, who will pay for the things that your family needs?', N'9c4474247f2a44fb90c6d9e064008067.jpeg', N'Enter Amount', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (2010, 1002, N'Life Saving Plans', CAST(50000.00 AS Decimal(18, 2)), N'What are your immediate and future goals? A brand-new car, a vacation to your dream holiday destination, to further your education, or a home of your own? You may not have all the cash to pay for them now, but you can save money towards realising these beautiful desires. ARM Life Savings Plus is designed to help you achieve your goals easily.', N'ba6a70e9bd4f4f56b634f72d55ac006b.jpeg', N'Enter Amount', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (2011, 1003, N'Retirement Savings', CAST(0.00 AS Decimal(18, 2)), N'Contributing to a Retirement Savings Account (RSA) According to the Pension Reform Act 2014, your employer is mandated to make contributions from your salary into your Retirement Savings Account starting from July 2014, in the following proportions:', N'38a76e3b749642a8a99ba4b665aae806.jpeg', N'Expression of Interest', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (2012, 3, N'StockTrade: Online Stock Trading', CAST(10000.00 AS Decimal(18, 2)), N'Trade Stocks Online with AvaTrade. With AvaTrade you can buy stocks CFDs in the world''s biggest companies with a click of a button. Our CFD Stock trading ...', N'2d0cbf5e14a2492089710a5448c64845.jpeg', N'Enter Amount', 1)
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive]) VALUES (2013, 4, N'Adiva Plainfields Phase II', CAST(0.00 AS Decimal(18, 2)), N'diva Phase II now selling! Over 1000 homes and plots delivered in Phase 1.

Experience the peace that comes with living in a state-of-the-art home, buy your Adiva Phase II property today. Payment plans available for 18 months. View price list here', N'636223f2c3944a4dbee054c063bbfda7.jpeg', N'Expression of Interest', 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON 

INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (1, 30002, 1003, CAST(500008800.00 AS Decimal(18, 2)), 1, N'100000000000000', CAST(N'2019-01-20T15:42:59.5966667' AS DateTime2), NULL, N'InCart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (2, 30002, 1003, CAST(504566788000.00 AS Decimal(18, 2)), 1, N'100000000000002', CAST(N'2019-01-20T16:01:13.3900000' AS DateTime2), NULL, N'InCart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (3, 30002, 1003, CAST(5087654000.00 AS Decimal(18, 2)), 1, N'100000000000003', CAST(N'2019-01-20T16:01:21.5900000' AS DateTime2), NULL, N'InCart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (4, 30002, 1004, CAST(50000.00 AS Decimal(18, 2)), 1, N'100000000000004', CAST(N'2019-01-20T16:01:32.1333333' AS DateTime2), NULL, N'InCart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (5, 30002, 1006, CAST(50000.00 AS Decimal(18, 2)), 1, N'100000000000005', CAST(N'2019-01-20T16:01:49.5133333' AS DateTime2), NULL, N'InCart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (6, 30002, 1005, CAST(0.00 AS Decimal(18, 2)), 1, N'100000000000006', CAST(N'2019-01-20T19:04:56.3266667' AS DateTime2), NULL, N'InCart', NULL)
SET IDENTITY_INSERT [dbo].[PurchaseOrders] OFF
SET IDENTITY_INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ON 

INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ([Id], [ProductId], [Sections], [Hierarchy], [Title], [Description], [OnCreated]) VALUES (1003, 1003, N'More Info', 1, N'THE FUND INVESTS IN', N'Government securities: 25% – 95%||Other money market instruments such as Bankers’ Acceptances, certificates of deposits, commercial papers, collaterised repurchase agreements etc.: 5% – 75%', CAST(N'2019-03-03T12:59:51.6869778' AS DateTime2))
INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ([Id], [ProductId], [Sections], [Hierarchy], [Title], [Description], [OnCreated]) VALUES (1004, 1003, N'More Info', 1, N'WHO IS THIS FOR', N'Do you currently have cash in a savings or current account and thinking of a Money Market Fund?||Do you wish that money could yield higher returns without the hassle of withholding tax and bank charges?||Are you saving up for your special day, payment of school fees or your dream holiday?||Or trying to save enough money to start a business or acquire that asset?', CAST(N'2019-03-03T13:00:52.2425818' AS DateTime2))
INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ([Id], [ProductId], [Sections], [Hierarchy], [Title], [Description], [OnCreated]) VALUES (2003, 1005, N'More Info', 1, N'THE FUND INVESTS IN:', N'Capital Preservation||Quarterly interest payments||Competitive interest rates||Expert fund management||Quick access to your money||Multiple & convenient payment options', CAST(N'2019-03-04T11:00:50.5300178' AS DateTime2))
INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ([Id], [ProductId], [Sections], [Hierarchy], [Title], [Description], [OnCreated]) VALUES (2004, 2008, N'More Info', 0, N'MORE INFO', N'We realize that an employee’s choice of PFA will go a long way in determining his or her quality of life after retirement.||Therefore it is our responsibility to provide capital preservation, competitive investment returns and outstanding customer service to each client who entrusts us with their retirement funds.||AVC differs from other regular savings you may have, as it is deducted from your salary before tax. This is a significant advantage of the AVC, as it means the contributions are tax-free and lower your overall tax liability.', CAST(N'2019-03-04T11:37:55.2663485' AS DateTime2))
INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ([Id], [ProductId], [Sections], [Hierarchy], [Title], [Description], [OnCreated]) VALUES (2005, 2008, N'Key Benefits', 0, N'KEY BENEFITS', N'Freedom to choose size and frequency of contributions||Can serve as targeted savings towards projects||Expert fund management||Lowers your over-all tax burden with tax free contributions', CAST(N'2019-03-04T11:41:08.6025997' AS DateTime2))
INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] ([Id], [ProductId], [Sections], [Hierarchy], [Title], [Description], [OnCreated]) VALUES (2006, 2008, N'Key Features', 0, N'KEY FEATURES', N'Additional savings added to your RSA voluntarily||Managed alongside your regular RSA||Voluntary contributions withdrawn before tax||Accessible at any time', CAST(N'2019-03-04T11:42:28.9380704' AS DateTime2))
SET IDENTITY_INSERT [dbo].[WhatYouNeedToKNowAboutThisProduct] OFF
ALTER TABLE [dbo].[ApplicationGroupRoles]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationGroupRoles_ApplicationGroup_ApplicationGroupId] FOREIGN KEY([ApplicationGroupId])
REFERENCES [dbo].[ApplicationGroup] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationGroupRoles] CHECK CONSTRAINT [FK_ApplicationGroupRoles_ApplicationGroup_ApplicationGroupId]
GO
ALTER TABLE [dbo].[ApplicationUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserGroups_ApplicationGroup_ApplicationGroupId] FOREIGN KEY([ApplicationGroupId])
REFERENCES [dbo].[ApplicationGroup] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserGroups] CHECK CONSTRAINT [FK_ApplicationUserGroups_ApplicationGroup_ApplicationGroupId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRole] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRole_RoleId]
GO
ALTER TABLE [dbo].[AspNetUser]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUser_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUser] CHECK CONSTRAINT [FK_AspNetUser_Person_PersonId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRole] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRole_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUser_UserId]
GO
ALTER TABLE [dbo].[MemberShip]  WITH CHECK ADD  CONSTRAINT [FK_MemberShip_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberShip] CHECK CONSTRAINT [FK_MemberShip_Person_PersonId]
GO
ALTER TABLE [dbo].[ProductInvestmentInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProductInvestmentInfo_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInvestmentInfo] CHECK CONSTRAINT [FK_ProductInvestmentInfo_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId]
GO
ALTER TABLE [dbo].[PurchaseOrders]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrders_Person_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrders] CHECK CONSTRAINT [FK_PurchaseOrders_Person_CustomerId]
GO
ALTER TABLE [dbo].[PurchaseOrders]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrders] CHECK CONSTRAINT [FK_PurchaseOrders_Products_ProductId]
GO
ALTER TABLE [dbo].[Referrer]  WITH CHECK ADD  CONSTRAINT [FK_Referrer_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Referrer] CHECK CONSTRAINT [FK_Referrer_Person_PersonId]
GO
ALTER TABLE [dbo].[WhatYouNeedToKNowAboutThisProduct]  WITH CHECK ADD  CONSTRAINT [FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WhatYouNeedToKNowAboutThisProduct] CHECK CONSTRAINT [FK_WhatYouNeedToKNowAboutThisProduct_Products_ProductId]
GO
