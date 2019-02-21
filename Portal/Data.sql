ALTER TABLE [dbo].[PurchaseOrders] DROP CONSTRAINT [FK_PurchaseOrders_Products_ProductId]
GO
ALTER TABLE [dbo].[PurchaseOrders] DROP CONSTRAINT [FK_PurchaseOrders_AspNetUser_CustomerId]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId]
GO
ALTER TABLE [dbo].[ProductPerformance] DROP CONSTRAINT [FK_ProductPerformance_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductKeyBenefit] DROP CONSTRAINT [FK_ProductKeyBenefit_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductFeatures] DROP CONSTRAINT [FK_ProductFeatures_Products_ProductId]
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
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRole_RoleId]
GO
ALTER TABLE [dbo].[ApplicationUserGroups] DROP CONSTRAINT [FK_ApplicationUserGroups_ApplicationGroup_ApplicationGroupId]
GO
ALTER TABLE [dbo].[ApplicationGroupRoles] DROP CONSTRAINT [FK_ApplicationGroupRoles_ApplicationGroup_ApplicationGroupId]
GO
/****** Object:  Table [dbo].[Redemptions]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[Redemptions]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[PurchaseOrders]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[ProductPerformance]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ProductPerformance]
GO
/****** Object:  Table [dbo].[ProductKeyBenefit]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ProductKeyBenefit]
GO
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ProductFeatures]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ProductCategory]
GO
/****** Object:  Table [dbo].[ProcessPayments]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ProcessPayments]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[Person]
GO
/****** Object:  Table [dbo].[PaymentTransactionStatuses]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[PaymentTransactionStatuses]
GO
/****** Object:  Table [dbo].[DirectDebitTransactions]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[DirectDebitTransactions]
GO
/****** Object:  Table [dbo].[DirectDebit]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[DirectDebit]
GO
/****** Object:  Table [dbo].[DDebit]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[DDebit]
GO
/****** Object:  Table [dbo].[ClientUpdateTemps]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ClientUpdateTemps]
GO
/****** Object:  Table [dbo].[ClientUpdate]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ClientUpdate]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetUserTokens]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetUser]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[AspNetRole]
GO
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ApplicationUserGroups]
GO
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ApplicationGroupRoles]
GO
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[ApplicationGroup]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/21/2019 12:28:06 PM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/21/2019 12:28:06 PM ******/
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
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 2/21/2019 12:28:06 PM ******/
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
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 2/21/2019 12:28:06 PM ******/
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
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 2/21/2019 12:28:06 PM ******/
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
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 2/21/2019 12:28:06 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 2/21/2019 12:28:07 PM ******/
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
	[UserNameAlternative] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[IsCustomerOrStaff] [nvarchar](10) NOT NULL,
	[MembershipNumber] [nvarchar](20) NULL,
	[CustomerOnboardingDate] [datetime2](7) NOT NULL,
	[NewOrOld] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[ClientUpdate]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[ClientUpdateTemps]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[DDebit]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[DirectDebit]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[DirectDebitTransactions]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[PaymentTransactionStatuses]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 2/21/2019 12:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[IsCustomer] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessPayments]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2/21/2019 12:28:07 PM ******/
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
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 2/21/2019 12:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFeatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductFeatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductKeyBenefit]    Script Date: 2/21/2019 12:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductKeyBenefit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductKeyBenefit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPerformance]    Script Date: 2/21/2019 12:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPerformance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductPerformance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/21/2019 12:28:08 PM ******/
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
	[Benefits] [nvarchar](max) NULL,
	[Features] [nvarchar](max) NULL,
	[HowToBegin] [nvarchar](max) NULL,
	[InvestmentManagement] [nvarchar](max) NULL,
	[MoreInformation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 2/21/2019 12:28:08 PM ******/
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
/****** Object:  Table [dbo].[Redemptions]    Script Date: 2/21/2019 12:28:08 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190127120926_Arm', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190127121552_Arm1', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190128124331_Arm2', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190128125206_Arm3', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190129173227_Arm4', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190129181022_Arm5', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190201094508_arm6', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190204104426_arm7', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190211105308_arm8', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190211110248_arm9', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190219215350_arm10', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190220125017_arm11', N'2.2.0-rtm-35687')
SET IDENTITY_INSERT [dbo].[ApplicationGroup] ON 

INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (1, N'Administrator', N'BlaBlaCar is an online marketplace for carpooling. Its website and mobile apps connect drivers and passengers willing to travel together between cities and share the cost of the journey. Wikipedia', NULL)
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (2, N'Sales', N'sales team', NULL)
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (3, N'Marketing', N'marketing team', NULL)
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (4, N'Sales Manager', N'Roles for Sales manager', NULL)
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (5, N'IT', N'Permission for IT team', NULL)
SET IDENTITY_INSERT [dbo].[ApplicationGroup] OFF
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 1)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 2)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 3)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 4)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (2, 10)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (2, 19)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 9)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 10)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 11)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 12)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 20)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (4, 10)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (4, 19)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 3)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 9)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 10)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 11)
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 13)
INSERT [dbo].[ApplicationUserGroups] ([ApplicationUserId], [ApplicationGroupId]) VALUES (9, 4)
SET IDENTITY_INSERT [dbo].[AspNetRole] ON 

INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (1, N'Admin:can:add', N'ADMIN:CAN:ADD', N'8381da92-f33c-481e-ad30-c3dc6ea01c45', N'Admin')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (2, N'Admin:can:edit', N'ADMIN:CAN:EDIT', N'1bc1a254-c8e4-490f-8b52-8d0f007e9fb4', N'Admin')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (3, N'Admin:can:view', N'ADMIN:CAN:VIEW', N'd01e4fee-cd12-46fb-a975-06cda680eb3b', N'Admin')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (4, N'Admin:can:delete', N'ADMIN:CAN:DELETE', N'813fb92e-f072-4ed1-961f-121d45e47d68', N'Admin')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (5, N'sale:can:delete', N'SALE:CAN:DELETE', N'0d016704-c0c6-4b06-beea-9088190dccbf', N'Sales')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (6, N'orders:can:delete', N'ORDERS:CAN:DELETE', N'fadd2834-2a2b-45fe-82dc-1b5005fae751', N'Orders')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (7, N'product:can:delete', N'PRODUCT:CAN:DELETE', N'bcd447a0-0cb9-485c-9f1a-ad58982582a3', N'Products')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (8, N'customer:can:delete', N'CUSTOMER:CAN:DELETE', N'd9becbe3-62da-4f69-9469-a79739bc771a', N'Customer')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (9, N'customer:can:view', N'CUSTOMER:CAN:VIEW', N'e62cafc5-3c51-4924-bf89-659de96e8fbf', N'Customer')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (10, N'sale:can:view', N'SALE:CAN:VIEW', N'0abf2733-37a7-42b5-891a-3b4f2f070c23', N'Sales')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (11, N'orders:can:view', N'ORDERS:CAN:VIEW', N'e2253077-c2a8-4602-bd82-d588e12930db', N'Orders')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (12, N'product:can:view', N'PRODUCT:CAN:VIEW', N'6c6518be-a0e5-463f-8b71-d773fa330ea1', N'Products')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (13, N'report:can:view', N'REPORT:CAN:VIEW', N'3066b814-b24d-4c11-a551-2bd0363fac78', N'Reports')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (14, N'report:can:print', N'REPORT:CAN:PRINT', N'36811c62-df33-47d8-927a-59ef73577024', N'Reports')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (15, N'customer:can:add', N'CUSTOMER:CAN:ADD', N'ae0de691-e1a8-4c3a-b5c9-d01a2ad3a7be', N'Customer')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (16, N'customer:can:report', N'CUSTOMER:CAN:REPORT', N'390d1325-2b94-4877-95d2-0d92b0d78088', N'Customer')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (17, N'product:can:add', N'PRODUCT:CAN:ADD', N'54a253e7-ade9-4872-b95d-d16f24e59935', N'Products')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (18, N'product:can:edit', N'PRODUCT:CAN:EDIT', N'd53eb723-aa46-4463-a84c-5bba7e7fe9a8', N'Products')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (19, N'sale:can:print', N'SALE:CAN:PRINT', N'd08af887-490b-4533-9047-0f4ffc7fe92a', N'Sales')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (20, N'dashboard:can:view', N'DASHBOARD:CAN:VIEW', N'4e893bd0-e581-45f1-8bb0-61ab8e54bf2b', N'Dashboard')
SET IDENTITY_INSERT [dbo].[AspNetRole] OFF
SET IDENTITY_INSERT [dbo].[AspNetUser] ON 

INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (1, N'mark.john@gmail.com', N'MARK.JOHN@GMAIL.COM', N'mark.john@gmail.com', N'MARK.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGqVEWjBDt+xX+yYVM2/0tLrIqMw+6jUtgPgEInoDYJ/qMoIp4J2/T8sn3kT6tHZLg==', N'EJTD6VDPVPSZERTROCGDTYREO6ARD2QJ', N'ca2aed33-e364-4e0f-a74f-55bf81f59151', NULL, 0, 0, NULL, 1, 0, N'mark.john', N'Mark', N'John', N'External', N'W1234567', CAST(N'2019-01-29T19:20:00.6433333' AS DateTime2), N'PortalOnboarding')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (2, N'alice.john@gmail.com', N'ALICE.JOHN@GMAIL.COM', N'alice.john@gmail.com', N'ALICE.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEE+8QyAWb6+5OEgl/cVmcCFx/gtthj7lbEGsj95DTLusfsFYTnwy5/m1Bd836uoXGQ==', N'MD4VGI7SYXAWYDSSNLXVZAK655LEKFUH', N'25ecf38c-2dce-4e84-a7a1-089627cd3a9b', NULL, 0, 0, NULL, 1, 0, N'alice.john', N'Alic', N'John', N'External', N'W1034567', CAST(N'2019-01-29T19:20:00.6566667' AS DateTime2), N'PortalOnboarding')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (3, N'rosy.john@gmail.com', N'ROSY.JOHN@GMAIL.COM', N'rosy.john@gmail.com', N'ROSY.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBIScOMahWOYCMU6cTgPzwg3Ia4wO8H+5BaBa3mOyizeRSVKH9dog5GuNE4I0s4sIg==', N'AW7AAUBGAJMFWQVAURFGDXMQVP75CTXE', N'0d21cc45-10eb-43dd-8549-19876887d385', NULL, 0, 0, NULL, 1, 0, N'rosy.john', N'Rosy', N'John', N'External', N'W1024567', CAST(N'2019-01-29T19:20:00.6600000' AS DateTime2), N'PortalOnboarding')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (6, N'jesica.micheal@gmail.com', N'JESICA.MICHEAL@GMAIL.COM', N'jesica.micheal@gmail.com', N'JESICA.MICHEAL@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEE37pcWQRoAnQPZaBL5zqtdA/XTUg++ey9qfCxPMGuKxZ19dc7NfKnU2YuZTKrIjNg==', N'EGSHOGMGW6RJTDROXXAVK4SPQSE4JRTS', N'bd540bf8-df32-4f5a-ad76-9f3943425b66', NULL, 0, 0, NULL, 1, 0, N'jesica.micheal', N'Jesica', N'Micheal', N'External', N'W1060122', CAST(N'2019-01-29T19:20:00.6633333' AS DateTime2), N'PortalOnboarding')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (9, N'william.echenim@arm.com.ng', N'WILLIAM.ECHENIM@ARM.COM.NG', N'jackie@arm.com.ng', N'JACKIE@ARM.COM.NG', 0, N'AQAAAAEAACcQAAAAEALY25lRJJ7msIu3U6RjptLzQH3WONf1H7sWEuz/kVXcE55+8J4TWQJwh6jG02lXdQ==', N'URGMLK4DMRYEO6VVRYAWUGYLWONMQJSK', N'720afcbe-bc75-4372-a11c-a627d6a50c4f', NULL, 0, 0, NULL, 1, 0, NULL, N'Echenim', N'Jackie', N'internal', NULL, CAST(N'2019-01-29T19:20:00.6700000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[AspNetUser] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (1, N'Real Estate')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (2, N'Pension')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (3, N'Mutual Fund')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (4, N'Securities')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (5, N'Trusties')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (6, N'Insurance')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features], [HowToBegin], [InvestmentManagement], [MoreInformation]) VALUES (1016, 3, N'ARM Money Market Fund', CAST(0.00 AS Decimal(18, 2)), N'The ARM Money Market Fund offers a higher interest rate on your savings than a traditional savings account. And it doesn’t have to be long term; the ARM MMF allows you quick access to your money, competitive interest rates, regular tax free returns and expert fund management.', N'9c93a2adf71c4045bf042248c054c7e1.jpeg', N'Enter Amount', 1, N'<ul><li>Capital Preservation</li><li>Quarterly interest payments</li><li>Competitive interest rates</li><li>Expert fund management</li><li>Quick access to your money</li><li>Multiple &amp; convenient payment options</li></ul>', N'<ul><li>Low risk mutual fund</li><li>Regulated by the SEC</li><li>Listed on the NSE</li><li>Invests in verifiable instruments</li><li>Suitable for short term or long term investment</li></ul>', N'<p><strong>TO BEGIN, YOU WOULD NEED THE FOLLOWING:</strong></p><ul><li>Input the amount you would like to invest, then click Buy Now</li><li>Checkout your order</li><li>After successful payment, you would be presented with a link to the registration form.</li><li>Fill the form</li><li>Attach copies of your passport photo</li><li>Copy of picture page of identification(e.g. International Passport, Driver&rsquo;s License)</li><li>Utility bill (for minors, a scanned copy of parent&rsquo;s ID, Utility bill and minor&rsquo;s birth certificate.)</li></ul>', N'<ul><li>View accrued interests</li><li>Redeem funds online</li><li>View account statements</li><li>Set up or cancel direct debit</li><li>Top up and initiate new investments</li></ul>', N'<p><strong>THE FUND INVESTS IN:</strong></p><ul><li>Government securities: 25% &ndash; 95%</li><li>Other money market instruments such as Bankers&rsquo; Acceptances, certificates of deposits, commercial papers, collaterised repurchase agreements etc.: 5% &ndash; 75%</li></ul><p><strong>WHO IS THIS FOR</strong></p><ul><li>Do you currently have cash in a savings or current account and thinking of a Money Market Fund?</li><li>Do you wish that money could yield higher returns without the hassle of withholding tax and bank charges?</li><li>Are you saving up for your special day, payment of school fees or your dream holiday?</li><li>Or trying to save enough money to start a business or acquire that asset?</li></ul>')
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features], [HowToBegin], [InvestmentManagement], [MoreInformation]) VALUES (1017, 3, N'myron', CAST(23.00 AS Decimal(18, 2)), N'The ARM Money Market Fund offers a higher interest rate on your savings than a traditional savings account. And it doesn’t have to be long term; the ARM MMF allows you quick access to your money, competitive interest rates, regular tax free returns and expert fund management.', N'f5fbd39f9a0e41d1a05ebfcc900f9d15.jpeg', N'Fixed Amount', 1, N'', N'', N'', N'<h2 class="font__family-varela-round text-uppercase font__size-24 mb-40" style="margin-top: 0px; font-family: varela_roundregular, Montserrat, sans-serif; line-height: 1.1; color: #292b2c; font-size: 1.5rem; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; vertical-align: baseline; background-color: #ffffff; margin-bottom: 40px !important; text-transform: uppercase !important;"><strong>KEY BENEFITS</strong></h2><ul class="list-inline-2 brk-library-rendered" style="margin-bottom: 0px; margin-left: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; font-size: 15px; line-height: inherit; font-family: varela_roundregular, ''Open Sans'', sans-serif; vertical-align: top; list-style-position: initial; color: #222222; background-color: #ffffff;" data-brk-library="component__list"><li class="font__family-varela-round font__size-16 font__weight-bold" style="margin-bottom: 0px; margin-left: 0px; font-style: inherit; font-variant: inherit; font-weight: bold; font-stretch: inherit; font-size: 1rem; line-height: inherit; font-family: varela_roundregular, Montserrat, sans-serif; vertical-align: top; display: block; text-align: left;"><span class="text" style="padding: 0.4375em 0.4375em 0.4375em 3.125em; font: inherit; vertical-align: top; display: inline-block; position: relative; z-index: 1;">Capital Preservation</span></li><li class="font__family-varela-round font__size-16 font__weight-bold" style="margin-top: 4px; margin-bottom: 0px; margin-left: 0px; font-style: inherit; font-variant: inherit; font-weight: bold; font-stretch: inherit; font-size: 1rem; line-height: inherit; font-family: varela_roundregular, Montserrat, sans-serif; vertical-align: top; display: block; text-align: left;"><span class="text" style="padding: 0.4375em 0.4375em 0.4375em 3.125em; font: inherit; vertical-align: top; display: inline-block; position: relative; z-index: 1;">Quarterly interest payments</span></li><li class="font__family-varela-round font__size-16 font__weight-bold" style="margin-top: 4px; margin-bottom: 0px; margin-left: 0px; font-style: inherit; font-variant: inherit; font-weight: bold; font-stretch: inherit; font-size: 1rem; line-height: inherit; font-family: varela_roundregular, Montserrat, sans-serif; vertical-align: top; display: block; text-align: left;"><span class="text" style="padding: 0.4375em 0.4375em 0.4375em 3.125em; font: inherit; vertical-align: top; display: inline-block; position: relative; z-index: 1;">Competitive interest rates</span></li><li class="font__family-varela-round font__size-16 font__weight-bold" style="margin-top: 4px; margin-bottom: 0px; margin-left: 0px; font-style: inherit; font-variant: inherit; font-weight: bold; font-stretch: inherit; font-size: 1rem; line-height: inherit; font-family: varela_roundregular, Montserrat, sans-serif; vertical-align: top; display: block; text-align: left;"><span class="text" style="padding: 0.4375em 0.4375em 0.4375em 3.125em; font: inherit; vertical-align: top; display: inline-block; position: relative; z-index: 1;">Expert fund management</span></li><li class="font__family-varela-round font__size-16 font__weight-bold" style="margin-top: 4px; margin-bottom: 0px; margin-left: 0px; font-style: inherit; font-variant: inherit; font-weight: bold; font-stretch: inherit; font-size: 1rem; line-height: inherit; font-family: varela_roundregular, Montserrat, sans-serif; vertical-align: top; display: block; text-align: left;"><span class="text" style="padding: 0.4375em 0.4375em 0.4375em 3.125em; font: inherit; vertical-align: top; display: inline-block; position: relative; z-index: 1;">Quick access to your money</span></li><li class="font__family-varela-round font__size-16 font__weight-bold" style="margin-top: 4px; margin-bottom: 0px; margin-left: 0px; font-style: inherit; font-variant: inherit; font-weight: bold; font-stretch: inherit; font-size: 1rem; line-height: inherit; font-family: varela_roundregular, Montserrat, sans-serif; vertical-align: top; display: block; text-align: left;"><span class="text" style="padding: 0.4375em 0.4375em 0.4375em 3.125em; font: inherit; vertical-align: top; display: inline-block; position: relative; z-index: 1;">Multiple &amp; convenient payment options</span></li></ul>', N'')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON 

INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (92, 1, 1016, CAST(2300.50 AS Decimal(18, 2)), 1, N'100000001', CAST(N'2019-02-21T07:24:44.7066667' AS DateTime2), N'F87FF5181A424D7BB0D9963B5FEBF5C1', N'Succeed', N'Feb 21 2019  7:24AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (93, 2, 1016, CAST(5000.00 AS Decimal(18, 2)), 1, N'100000002', CAST(N'2019-02-21T07:24:44.7133333' AS DateTime2), N'27DE72C945084A07ACEA2C9814F9E11A', N'Succeed', N'Feb 21 2019  7:24AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (94, 1, 1016, CAST(6300.50 AS Decimal(18, 2)), 1, N'100000001', CAST(N'2019-02-21T07:26:50.0866667' AS DateTime2), NULL, N'Incart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (95, 2, 1016, CAST(1000.00 AS Decimal(18, 2)), 1, N'100000004', CAST(N'2019-02-21T07:26:50.0866667' AS DateTime2), NULL, N'Incart', NULL)
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (96, 3, 1016, CAST(2300.50 AS Decimal(18, 2)), 1, N'100000005', CAST(N'2019-02-21T07:30:36.6433333' AS DateTime2), N'FB240F3CD6D24FE4AC04C07ED8526BBE', N'Failed', N'Feb 21 2019  7:30AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (97, 6, 1016, CAST(5000.00 AS Decimal(18, 2)), 1, N'100000006', CAST(N'2019-02-21T07:30:36.6433333' AS DateTime2), N'B5D86857F02D4C5195D5DA5ADC6EE60F', N'Failed', N'Feb 21 2019  7:30AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (98, 6, 1016, CAST(1300.50 AS Decimal(18, 2)), 1, N'100000007', CAST(N'2019-02-21T07:43:41.2066667' AS DateTime2), N'4D5644595C43418DAB7628899E67EBD4', N'Succeed', N'Feb 21 2019  7:43AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (99, 6, 1016, CAST(34000.00 AS Decimal(18, 2)), 1, N'100000007', CAST(N'2019-02-21T07:43:41.2066667' AS DateTime2), N'D611714572104A85ABB56C48F0AA9F96', N'Succeed', N'Feb 21 2019  7:43AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (100, 6, 1016, CAST(1300.50 AS Decimal(18, 2)), 1, N'100000008', CAST(N'2019-02-21T08:27:22.2466667' AS DateTime2), N'A6E38D9CDB8A4CC096DB743E7CC0AF39', N'Succeed', N'Feb 21 2019  8:27AM')
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (101, 6, 1016, CAST(34000.00 AS Decimal(18, 2)), 1, N'100000008', CAST(N'2019-02-21T08:27:22.2466667' AS DateTime2), N'7C25BCCCC8DD4C6BBF671C97037E338D', N'Succeed', N'Feb 21 2019  8:27AM')
SET IDENTITY_INSERT [dbo].[PurchaseOrders] OFF
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
ALTER TABLE [dbo].[ProductFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatures_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductFeatures] CHECK CONSTRAINT [FK_ProductFeatures_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductKeyBenefit]  WITH CHECK ADD  CONSTRAINT [FK_ProductKeyBenefit_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductKeyBenefit] CHECK CONSTRAINT [FK_ProductKeyBenefit_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductPerformance]  WITH CHECK ADD  CONSTRAINT [FK_ProductPerformance_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductPerformance] CHECK CONSTRAINT [FK_ProductPerformance_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategory_ProductCategoryId]
GO
ALTER TABLE [dbo].[PurchaseOrders]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrders_AspNetUser_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrders] CHECK CONSTRAINT [FK_PurchaseOrders_AspNetUser_CustomerId]
GO
ALTER TABLE [dbo].[PurchaseOrders]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrders] CHECK CONSTRAINT [FK_PurchaseOrders_Products_ProductId]
GO
