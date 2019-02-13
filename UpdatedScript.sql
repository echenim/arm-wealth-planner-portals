USE [ArmWealth]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 2/13/2019 2:26:28 PM ******/
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
/****** Object:  Table [dbo].[ProductKeyBenefit]    Script Date: 2/13/2019 2:26:29 PM ******/
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
/****** Object:  Table [dbo].[ProductPerformance]    Script Date: 2/13/2019 2:26:29 PM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 2/13/2019 2:26:29 PM ******/
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
	[IsActive] [nvarchar](10) NOT NULL,
	[Benefits] [nvarchar](max) NULL,
	[Features] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 2/13/2019 2:26:29 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190127120926_Arm', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190127121552_Arm1', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190128124331_Arm2', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190128125206_Arm3', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190129173227_Arm4', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190129181022_Arm5', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190201094508_arm6', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190204104426_arm7', N'2.2.0-rtm-35687')
GO
SET IDENTITY_INSERT [dbo].[ApplicationGroup] ON 
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (1, N'Administrator', N'BlaBlaCar is an online marketplace for carpooling. Its website and mobile apps connect drivers and passengers willing to travel together between cities and share the cost of the journey. Wikipedia', NULL)
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (2, N'Sales', N'sales team', NULL)
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (3, N'Marketing', N'marketing team', NULL)
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (4, N'Sales Manager', N'Roles for Sales manager', NULL)
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (5, N'IT', N'Permission for IT team', NULL)
GO
SET IDENTITY_INSERT [dbo].[ApplicationGroup] OFF
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 1)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 2)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 3)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (1, 4)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (2, 10)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (2, 19)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 9)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 10)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 11)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 12)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (3, 20)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (4, 10)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (4, 19)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 3)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 9)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 10)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 11)
GO
INSERT [dbo].[ApplicationGroupRoles] ([ApplicationGroupId], [ApplicationRoleId]) VALUES (5, 13)
GO
INSERT [dbo].[ApplicationUserGroups] ([ApplicationUserId], [ApplicationGroupId]) VALUES (9, 4)
GO
SET IDENTITY_INSERT [dbo].[AspNetRole] ON 
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (1, N'Admin:can:add', N'ADMIN:CAN:ADD', N'8381da92-f33c-481e-ad30-c3dc6ea01c45', N'Admin')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (2, N'Admin:can:edit', N'ADMIN:CAN:EDIT', N'1bc1a254-c8e4-490f-8b52-8d0f007e9fb4', N'Admin')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (3, N'Admin:can:view', N'ADMIN:CAN:VIEW', N'd01e4fee-cd12-46fb-a975-06cda680eb3b', N'Admin')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (4, N'Admin:can:delete', N'ADMIN:CAN:DELETE', N'813fb92e-f072-4ed1-961f-121d45e47d68', N'Admin')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (5, N'sale:can:delete', N'SALE:CAN:DELETE', N'0d016704-c0c6-4b06-beea-9088190dccbf', N'Sales')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (6, N'orders:can:delete', N'ORDERS:CAN:DELETE', N'fadd2834-2a2b-45fe-82dc-1b5005fae751', N'Orders')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (7, N'product:can:delete', N'PRODUCT:CAN:DELETE', N'bcd447a0-0cb9-485c-9f1a-ad58982582a3', N'Products')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (8, N'customer:can:delete', N'CUSTOMER:CAN:DELETE', N'd9becbe3-62da-4f69-9469-a79739bc771a', N'Customer')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (9, N'customer:can:view', N'CUSTOMER:CAN:VIEW', N'e62cafc5-3c51-4924-bf89-659de96e8fbf', N'Customer')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (10, N'sale:can:view', N'SALE:CAN:VIEW', N'0abf2733-37a7-42b5-891a-3b4f2f070c23', N'Sales')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (11, N'orders:can:view', N'ORDERS:CAN:VIEW', N'e2253077-c2a8-4602-bd82-d588e12930db', N'Orders')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (12, N'product:can:view', N'PRODUCT:CAN:VIEW', N'6c6518be-a0e5-463f-8b71-d773fa330ea1', N'Products')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (13, N'report:can:view', N'REPORT:CAN:VIEW', N'3066b814-b24d-4c11-a551-2bd0363fac78', N'Reports')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (14, N'report:can:print', N'REPORT:CAN:PRINT', N'36811c62-df33-47d8-927a-59ef73577024', N'Reports')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (15, N'customer:can:add', N'CUSTOMER:CAN:ADD', N'ae0de691-e1a8-4c3a-b5c9-d01a2ad3a7be', N'Customer')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (16, N'customer:can:report', N'CUSTOMER:CAN:REPORT', N'390d1325-2b94-4877-95d2-0d92b0d78088', N'Customer')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (17, N'product:can:add', N'PRODUCT:CAN:ADD', N'54a253e7-ade9-4872-b95d-d16f24e59935', N'Products')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (18, N'product:can:edit', N'PRODUCT:CAN:EDIT', N'd53eb723-aa46-4463-a84c-5bba7e7fe9a8', N'Products')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (19, N'sale:can:print', N'SALE:CAN:PRINT', N'd08af887-490b-4533-9047-0f4ffc7fe92a', N'Sales')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleGroupName]) VALUES (20, N'dashboard:can:view', N'DASHBOARD:CAN:VIEW', N'4e893bd0-e581-45f1-8bb0-61ab8e54bf2b', N'Dashboard')
GO
SET IDENTITY_INSERT [dbo].[AspNetRole] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUser] ON 
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (1, N'mark.john@gmail.com', N'MARK.JOHN@GMAIL.COM', N'mark.john@gmail.com', N'MARK.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGqVEWjBDt+xX+yYVM2/0tLrIqMw+6jUtgPgEInoDYJ/qMoIp4J2/T8sn3kT6tHZLg==', N'EJTD6VDPVPSZERTROCGDTYREO6ARD2QJ', N'ca2aed33-e364-4e0f-a74f-55bf81f59151', NULL, 0, 0, NULL, 1, 0, N'mark.john', N'Mark', N'John', N'External', N'W1234567', CAST(N'2019-01-29T19:20:00.6433333' AS DateTime2), NULL)
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (2, N'alice.john@gmail.com', N'ALICE.JOHN@GMAIL.COM', N'alice.john@gmail.com', N'ALICE.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEE+8QyAWb6+5OEgl/cVmcCFx/gtthj7lbEGsj95DTLusfsFYTnwy5/m1Bd836uoXGQ==', N'MD4VGI7SYXAWYDSSNLXVZAK655LEKFUH', N'25ecf38c-2dce-4e84-a7a1-089627cd3a9b', NULL, 0, 0, NULL, 1, 0, N'alice.john', N'Alic', N'John', N'External', N'W1034567', CAST(N'2019-01-29T19:20:00.6566667' AS DateTime2), NULL)
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (3, N'rosy.john@gmail.com', N'ROSY.JOHN@GMAIL.COM', N'rosy.john@gmail.com', N'ROSY.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBIScOMahWOYCMU6cTgPzwg3Ia4wO8H+5BaBa3mOyizeRSVKH9dog5GuNE4I0s4sIg==', N'AW7AAUBGAJMFWQVAURFGDXMQVP75CTXE', N'0d21cc45-10eb-43dd-8549-19876887d385', NULL, 0, 0, NULL, 1, 0, N'rosy.john', N'Rosy', N'John', N'External', N'W1024567', CAST(N'2019-01-29T19:20:00.6600000' AS DateTime2), NULL)
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (6, N'jesica.micheal@gmail.com', N'JESICA.MICHEAL@GMAIL.COM', N'jesica.micheal@gmail.com', N'JESICA.MICHEAL@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEE37pcWQRoAnQPZaBL5zqtdA/XTUg++ey9qfCxPMGuKxZ19dc7NfKnU2YuZTKrIjNg==', N'EGSHOGMGW6RJTDROXXAVK4SPQSE4JRTS', N'bd540bf8-df32-4f5a-ad76-9f3943425b66', NULL, 0, 0, NULL, 1, 0, N'jesica.micheal', N'Jesica', N'Micheal', N'External', N'W1060122', CAST(N'2019-01-29T19:20:00.6633333' AS DateTime2), NULL)
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber], [CustomerOnboardingDate], [NewOrOld]) VALUES (9, N'william.echenim@arm.com.ng', N'WILLIAM.ECHENIM@ARM.COM.NG', N'jackie@arm.com.ng', N'JACKIE@ARM.COM.NG', 0, N'AQAAAAEAACcQAAAAEALY25lRJJ7msIu3U6RjptLzQH3WONf1H7sWEuz/kVXcE55+8J4TWQJwh6jG02lXdQ==', N'URGMLK4DMRYEO6VVRYAWUGYLWONMQJSK', N'e3f565e7-9757-446a-a806-0a393217781a', NULL, 0, 0, NULL, 1, 0, NULL, N'Echenim', N'Jackie', N'internal', NULL, CAST(N'2019-01-29T19:20:00.6700000' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[AspNetUser] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 
GO
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (1, N'Real Estate')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (2, N'Pension')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (3, N'Mutual Fund')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (4, N'Securities')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (5, N'Trusties')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (6, N'Insurance')
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (7, 1, N'Lakowe Lakes Golf & Country Estate', CAST(0.00 AS Decimal(18, 2)), N'Garden view plots from N 30,000 per sqm
Fairway view plots from N 33,000 per sqm
Shell homes from N 19,886,000 per home', N'ef7364b6c6f44ec8b8b1a744d50afddd.jpeg', N'Expression of Interest', N'Yes', N'Prices from N33m/plot

Live your dream, buy a home in the Lakowe Lakes Golf and Country estate. View price list', N'Located five minutes from the Port Harcourt International Airport
Presents some of the most breath-taking views in Port Harcourt city
Safe and serene environment
First class Infrastructure in addition to a 24-hour security and support system')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (8, 1, N'Garden City Golf Estate: Reserve yours today', CAST(0.00 AS Decimal(18, 2)), N'Garden view plots from N 30,000 per sqm
Fairway view plots from N 33,000 per sqm
Shell homes from N 19,886,000 per home', N'0c6ce4241b644360bdcac48be5dec681.jpeg', N'Expression of Interest', N'Yes', N'Garden view plots from N 30,000 per sqm
Fairway view plots from N 33,000 per sqm
Shell homes from N 19,886,000 per home', N'Located five minutes from the Port Harcourt International Airport
Presents some of the most breath-taking views in Port Harcourt city
Safe and serene environment
First class Infrastructure in addition to a 24-hour security and support system')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (9, 2, N'ARM Pension’s Retirement Savings Account', CAST(0.00 AS Decimal(18, 2)), N'At ARM Pensions, tomorrow is always looking good. Partner with us for a better tomorrow.', N'67a54261e43042bf9702171dc8c6e92f.jpeg', N'Expression of Interest', N'No', N'Monthly contribution into Pensions account by both employer & employee
Funds reinvested by experts for returns
Periodic delivery of account statements
Regulated by PENCOM
PFA located in every state across the nation', N'Expert fund management
Easy account monitoring online
Excellent customer service across our offices nationwide
Easy access to benefits as and when due')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (10, 4, N'ARM StockTrade: Online stock trading', CAST(50000.00 AS Decimal(18, 2)), N'Get real-time trading insights and updates alongside the comfort of trading from wherever you are with ARM Stocktrade online stock trading. With your internet empowered device, you have all you need to trade in stocks online.

Why not take advantage of this opportunity?

How to Begin:

What you will need to open an account:

Means of Identification (soft copies of either Driver’s license, National I.D, Permanent Voter’s Card or International passport data page)
Proof of Address (soft copies of either Current Utility Bill; LAWMA bill, Electricity Bill, Water Bill, Driver’s License)
Signature Specimen; Upload scanned copy of signature
Passport Photograph (Digital copy)
Minimum sum of N50,000', N'232ecc1acd4a44d9b0cf2904a97b512a.jpeg', N'Enter Amount', N'Yes', N'Prompt trade execution
Real-time updates & research
No 3-day wait
Personalised service
Consolidation of multiple accounts', N'Place, buy and sell orders online
Invest with as little as 50,000
Track your investments from the comfort of your home')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (11, 3, N'ARM Discovery Fund', CAST(0.00 AS Decimal(18, 2)), N'This Discovery Fund is suitable for Investors who want high capital growth over the long term to meet objectives such as education funding, property acquisition or leaving a legacy for loved ones.

Key Benefits

Grow your wealth over the long term with returns above inflation
Earn multiple returns through capital appreciation and dividends
What does this fund invest in?

Equities: 80%-100%
Fixed income securities: 0%-20%
The proportion of the Fund invested in each of the asset classes will vary within the ranges provided as the market environment changes, and their potential risk and return change. However, the proportion will always remain within the ranges above.

How to Begin:

You would need the following:

Attach copies of your passport photo
Copy of picture page of identification(e.g. International Passport, Driver’s License)
Evidence of payment (teller or transfer receipt),
Utility bill (for minors, a scanned copy of parent’s ID, Utility bill and minor’s birth certificate.)
If you don’t want to buy now, you can download our form here.', N'2fdd0e1af8ea475595f0464f338bd89f.jpeg', N'Enter Amount', N'Yes', N'Long term wealth growth with returns above inflation
Multiple returns through capital appreciation and dividends
Easy Investment tracking online
Multiple & Convenient Payment options
Expert fund management', N'Suitable for long term investments
Open ended mutual fund
Listed on the NSE
Invests in equities & fixed asset securities')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (12, 3, N'ARM Ethical Fund: Invest now', CAST(0.00 AS Decimal(18, 2)), N'This Ethical Fund is suitable for Islamic investors who want long-term capital growth by investing strictly according to the principles of Islamic finance and ethical values

Key Benefits

– Achieve long-term capital growth

– Invest according to core Islamic values and beliefs

What the fund invests in?

Equities:30%-60%
Real estate: 20%-60%
Other investments: 10%-30%
The Fund invests only in investments screened by a Shari’ah Advisory Board. The Fund will not invest in any company that involves interest-bearing transactions, gambling, alcohol and tobacco, arms and ammunition or adult entertainment.

Minimum initial investment: N10,000

Minimum additional investment: N5,000

Investment Strategy
The ARM Ethical Fund fund only invests in investments screened by a Shari’ah Advisory Board. The fund will not invest in any company that involves interest-bearing transactions, gambling, alcohol and tobacco, arms and ammunition or adult entertainment.

Risk Level
More Facts

Type of Fund: Open-ended. This simply means that you can sell or buy into the Fund whenever they want.

Management Type: The Fund is managed on a discretionary basis, which simply means that the fund manager can take decisions to buy and sell assets without referring to the clients for every transaction

Management Fees: 1.5% of Net Asset Value (NAV) of the Fund

Fund Manager: ARM Investment Managers

Trustee: Royal Exchange Plc.

Registrars: United Securities Ltd.

Investment Tracking: Access to investment account online

Custodian: Citibank Nigeria Limited

Payment Options: Online Payment is available via the online portal and you can set up a standing instruction with your bank for periodic payments

How to Begin:

You would need the following:

Attach copies of your passport photo
Copy of picture page of identification(e.g. International Passport, Driver’s License)
Evidence of payment (teller or transfer receipt),
Utility bill (for minors, a scanned copy of parent’s ID, Utility bill and minor’s birth certificate.)
If you don’t want to buy now, you can download our form here.', N'c4d4f49628bf4ae5b3abadb6d7b9cb11.png', N'Fixed Amount', N'Yes', N'Expert fund management
Easy Investment tracking online
Achieve long-term capital growth
Invest in accordance with core Islamic values and beliefs
Multiple & Convenient Payment options', N'Invests in equities, real-estate and other ethical investments
Invests in investments screened by a Shari''ah Advisory Board
Open ended mutual fund')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes], [IsActive], [Benefits], [Features]) VALUES (13, 3, N'ARM Money Market Fund: Invest now', CAST(1000.00 AS Decimal(18, 2)), N'Do you currently have cash in a savings or current account and thinking of a Money Market Fund?
Do you wish that money could yield higher returns without the hassle of withholding tax and bank charges?
Are you saving up for your special day, payment of school fees or your dream holiday?
Or trying to save enough money to start a business or acquire that asset?

The ARM Money Market fund is for you. Invest that money in the ARM Money Market Fund today (ARM MMF).

The ARM Money Market Fund offers a higher interest rate on your savings than a traditional savings account. And it doesn’t have to be long term; the ARM MMF allows you quick access to your money, competitive interest rates, regular tax free returns and expert fund management.

The fund invests in

Government securities: 25% – 95%
Other money market instruments: 5% – 75%
Bankers’ Acceptances, certificates of deposits, commercial papers, collaterised repurchase agreements etc.', N'f4c93513bcd945278d6cdd6af09214d8.png', N'Fixed Amount', N'Yes', N'Capital Preservation
Quarterly interest payments
Competitive interest rates
Expert fund management
Quick access to your money
Multiple & convenient payment options', N'Low risk mutual fund
Regulated by the SEC
Listed on the NSE
Invests in verifiable instruments
Suitable for short term or long term investment')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON 
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (1, 1, 7, CAST(0.00 AS Decimal(18, 2)), 1, N'22B1ADD4250C42F09BC7530DA61CC61C', CAST(N'2019-01-29T14:09:23.3466667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (2, 1, 8, CAST(0.00 AS Decimal(18, 2)), 1, N'5B7FFADDCAD447EF971F88EB9464149F', CAST(N'2019-01-28T14:09:23.3466667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (3, 1, 9, CAST(0.00 AS Decimal(18, 2)), 1, N'1CD1F34A85DB4A87A347595EB25D6B92', CAST(N'2019-01-28T14:09:23.3466667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (4, 2, 7, CAST(0.00 AS Decimal(18, 2)), 1, N'ECF24AF1BA06429099C84D6030EF0283', CAST(N'2019-01-28T14:11:31.7566667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (5, 2, 8, CAST(0.00 AS Decimal(18, 2)), 1, N'3FEB678D62154591ADA516D21CCCAFC3', CAST(N'2019-01-29T14:11:31.7566667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (6, 2, 9, CAST(0.00 AS Decimal(18, 2)), 1, N'96C1CC68DC0048D181256993B5FEEACE', CAST(N'2019-01-28T14:11:31.7566667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (7, 3, 7, CAST(0.00 AS Decimal(18, 2)), 1, N'E7C05BD6FD6141298A14951569A7D968', CAST(N'2019-01-28T14:11:37.7966667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (8, 3, 8, CAST(0.00 AS Decimal(18, 2)), 1, N'AD45F5AFF02F4C98B893A6FA64B34C28', CAST(N'2019-01-28T14:11:37.7966667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (9, 3, 9, CAST(0.00 AS Decimal(18, 2)), 1, N'A655EE06A2974AEAB9D8DBBCA36B526C', CAST(N'2019-01-18T14:11:37.7966667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (10, 6, 7, CAST(0.00 AS Decimal(18, 2)), 1, N'37552A863FAE40EF8926E9C00B564996', CAST(N'2019-01-28T14:11:44.9866667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (11, 6, 8, CAST(0.00 AS Decimal(18, 2)), 1, N'49FF38162DCD4D239E604C4AC2910F05', CAST(N'2019-01-28T14:11:44.9866667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (12, 6, 9, CAST(0.00 AS Decimal(18, 2)), 1, N'47C49687E05749BC81679373E24A7F3D', CAST(N'2019-01-28T14:11:44.9866667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (13, 9, 7, CAST(0.00 AS Decimal(18, 2)), 1, N'816EB2632FC6407595A940A2B1A78E02', CAST(N'2019-01-28T14:11:51.6833333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (14, 9, 8, CAST(0.00 AS Decimal(18, 2)), 1, N'4D3A85F0038F4C68BA29891607854338', CAST(N'2019-01-28T14:11:51.6833333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (15, 9, 9, CAST(0.00 AS Decimal(18, 2)), 1, N'12F89F6154354519BCE6E43DD6559EA5', CAST(N'2019-01-28T14:11:51.6833333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (16, 1, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'35C94592F1C246D7BC200172BDD85CA7', CAST(N'2019-01-29T14:12:59.3800000' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (17, 2, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'055866CF78074A72A2C577179E6ED972', CAST(N'2019-01-29T14:13:15.1333333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (18, 2, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'993E7CA096A946438749FD8FCA5F00BF', CAST(N'2019-01-20T14:13:15.8700000' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (19, 3, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'ABBDE9468546455F94762F61FCB8D6CE', CAST(N'2019-01-28T14:13:23.7033333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (20, 3, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'BA35F532E37742BB90FB5F200A41FF78', CAST(N'2019-01-28T14:13:24.0366667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (21, 3, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'58467FFD93714AE9824AF7D98978B38B', CAST(N'2019-01-28T14:13:24.3533333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (22, 3, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'78673B82A6F04F2988D6417BF10F7637', CAST(N'2019-01-08T14:13:30.5366667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (23, 3, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'35F324F0E5E548668AAF940948BE60EB', CAST(N'2019-01-08T14:13:30.8133333' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (24, 2, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'53917F05FB6A4A1AB10E77B6CE576F37', CAST(N'2019-01-07T14:13:38.5566667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (25, 2, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'163906BD66584C77BAFE5CC7AF15B1A3', CAST(N'2019-01-07T14:13:38.7300000' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (26, 1, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'F25E4CE171054FEA94425DA716496956', CAST(N'2019-01-29T14:13:49.7600000' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (27, 1, 10, CAST(50000.00 AS Decimal(18, 2)), 1, N'69791C2E072D4ED79667E14F1F7D4902', CAST(N'2019-01-28T14:13:50.1766667' AS DateTime2), NULL, N'InCart', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (28, 1, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'3909247517284ACAA81539230B35113A', CAST(N'2019-01-29T15:02:52.1133333' AS DateTime2), N'TR1102813493D84612BE21AD46F669E215', N'Succeed', N'2019-01-29 15:02:52.1133333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (29, 1, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'186E9BEBC611416E971973029930CF69', CAST(N'2019-01-29T15:02:52.1133333' AS DateTime2), N'TRACC4C6411E8240DEB33B9D16BB5F8D1A', N'Succeed', N'2019-01-29 15:02:52.1133333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (30, 1, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'F2E0A93BC92D4DCB9031E160C98BED9A', CAST(N'2019-01-29T15:02:52.1133333' AS DateTime2), N'TR0F9763C806FF47348971A50E12172066', N'Succeed', N'2019-01-29 15:02:52.1133333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (31, 1, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'B36C1F3C7380468DB77899422BF73731', CAST(N'2019-01-29T15:02:52.1133333' AS DateTime2), N'TR6C3A1037F8A241D1A10B93383EC87EA0', N'Succeed', N'2019-01-29 15:02:52.1133333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (32, 2, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'E38EC6A5ABAF4521958E8EB8926FBF17', CAST(N'2019-01-29T15:03:00.5566667' AS DateTime2), N'TR329530235E3645B59D820C4E38108064', N'Succeed', N'2019-01-29 15:03:00.5566667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (33, 2, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'DB4C05B7120E4C8791CF8024A0C00F83', CAST(N'2019-01-29T15:03:00.5566667' AS DateTime2), N'TRD10D5BD19F964DD5874753154C82FD53', N'Succeed', N'2019-01-29 15:03:00.5566667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (34, 2, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'E01B4DE5B5F749AEAE810D7F82EAA1A1', CAST(N'2019-01-29T15:03:00.5566667' AS DateTime2), N'TR1536BAF5BDCD48DB941047315845853B', N'Succeed', N'2019-01-29 15:03:00.5566667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (35, 2, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'D0FF4F55872C416085CB0A6CFB50CD7E', CAST(N'2019-01-29T15:03:00.5566667' AS DateTime2), N'TR1378EB06724048C0A103AF7FCA3B8C74', N'Succeed', N'2019-01-29 15:03:00.5566667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (36, 3, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'16E609039E19474C9F14FA20B2B1BA84', CAST(N'2019-01-29T15:03:14.3600000' AS DateTime2), N'TRA78D272A11B14899B7A376CA9E9DABE5', N'Succeed', N'2019-01-29 15:03:14.3600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (37, 3, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'411C7B2B40774C2FA54B1DF527F21A06', CAST(N'2019-01-29T15:03:14.3600000' AS DateTime2), N'TRE0F57F356BA543A19B6AF8F349CBA37E', N'Succeed', N'2019-01-29 15:03:14.3600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (38, 3, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'0CFAACCF888A4A19B7021BCE4FB10CB9', CAST(N'2019-01-29T15:03:14.3600000' AS DateTime2), N'TR895740B9EA1D46FDA7615DE24BBF0C65', N'Succeed', N'2019-01-29 15:03:14.3600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (39, 3, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'F7254465FFE14EAC90C426A688BEAB0B', CAST(N'2019-01-29T15:03:14.3600000' AS DateTime2), N'TR8E37441A83BE4CB4AD8051D4C6460C33', N'Succeed', N'2019-01-29 15:03:14.3600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (40, 6, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'5C11EA34B6A340CEA3345EE53E31413F', CAST(N'2019-01-29T15:03:19.6333333' AS DateTime2), N'TRE60DDC4C4F7C477E8E0C36B746424CCD', N'Succeed', N'2019-01-29 15:03:19.6333333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (41, 6, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'D1422F881E7A4719A5BB445AD1CE0DE2', CAST(N'2019-01-29T15:03:19.6333333' AS DateTime2), N'TR85E490180DAE435D8CA9F7670A3AFB04', N'Succeed', N'2019-01-29 15:03:19.6333333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (42, 6, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'C3F10041F8C6486C95DD72BC8DF11613', CAST(N'2019-01-29T15:03:19.6333333' AS DateTime2), N'TR0ABA247B340F43299B5820BE472CE06C', N'Succeed', N'2019-01-29 15:03:19.6333333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (43, 6, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'0AED16A9BC0F4B98BF52DAFEFD4A78A9', CAST(N'2019-01-29T15:03:19.6333333' AS DateTime2), N'TR174CEAC5404B40C18DB7F5C56DE86AE6', N'Succeed', N'2019-01-29 15:03:19.6333333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (44, 6, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'A12C7064D63C482EB58ADA08E41B1B2B', CAST(N'2019-01-29T15:03:33.5000000' AS DateTime2), N'TR8CC6ABDAAD884B7693AAEFAE2F7B190A', N'Succeed', N'2019-01-29 15:03:33.5000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (45, 6, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'41476E5B37A645929D4083EDA8FC076D', CAST(N'2019-01-29T15:03:33.5000000' AS DateTime2), N'TR3F894BCC37DA4847A46C5407BE279EE0', N'Succeed', N'2019-01-29 15:03:33.5000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (46, 6, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'00A350693A7942AB80CA02905A87FC89', CAST(N'2019-01-29T15:03:33.5000000' AS DateTime2), N'TR7557CA16F7804FC9B74728DDEDDCD977', N'Succeed', N'2019-01-29 15:03:33.5000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (47, 6, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'2617DAD4ED7945078143C9E6F2FCB206', CAST(N'2019-01-29T15:03:33.5000000' AS DateTime2), N'TR1999725102FC4AC095B39C21B84BFE28', N'Succeed', N'2019-01-29 15:03:33.5000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (48, 3, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'1F436BCF1D6B417F8D67A02ABEBC06F5', CAST(N'2019-01-29T15:03:50.8766667' AS DateTime2), N'TRD9A7E7BA958248B9BDA3B8DD1462CBBB', N'Succeed', N'2019-01-29 15:03:50.8766667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (49, 3, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'CEE7CA20067B442AB50ADDB822A68014', CAST(N'2019-01-29T15:03:50.8766667' AS DateTime2), N'TR7039846742544489AD6BDD8EB5EE9E6C', N'Succeed', N'2019-01-29 15:03:50.8766667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (50, 3, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'3D7F15F91DD74D12B0522B7860FB5ABF', CAST(N'2019-01-29T15:03:50.8766667' AS DateTime2), N'TRD76C33DE04D6414697DA882DC7B5FF76', N'Succeed', N'2019-01-29 15:03:50.8766667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (51, 3, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'214A0203A096468D87EF35DDF7E404BB', CAST(N'2019-01-29T15:03:50.8766667' AS DateTime2), N'TRD323E824B42341DCA1A740D0A88C1CB8', N'Succeed', N'2019-01-29 15:03:50.8766667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (52, 2, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'743709951E3742969399F9B08438406B', CAST(N'2019-01-29T15:03:54.1600000' AS DateTime2), N'TRD56472A7A0D443B1AAD992E6FE571E9D', N'Succeed', N'2019-01-29 15:03:54.1600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (53, 2, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'A2F7A0E1CB9F4C62A49C2CDC0CACA587', CAST(N'2019-01-29T15:03:54.1600000' AS DateTime2), N'TRF282E1F044CC4BF497FA80B13E1738AE', N'Succeed', N'2019-01-29 15:03:54.1600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (54, 2, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'0E9DA1363E884C8DA7157379154314DD', CAST(N'2019-01-29T15:03:54.1600000' AS DateTime2), N'TR7D53BED205D2447A8824280D992C02C4', N'Succeed', N'2019-01-29 15:03:54.1600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (55, 2, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'2421D333551645578048918624093236', CAST(N'2019-01-29T15:03:54.1600000' AS DateTime2), N'TREE0FF401E4A847348CA6047EB5181218', N'Succeed', N'2019-01-29 15:03:54.1600000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (56, 1, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'5768FB3F680642A68C1A786BCCE91341', CAST(N'2019-01-29T15:03:57.2200000' AS DateTime2), N'TR2785CFFB1672463C825C6AC362835ECC', N'Succeed', N'2019-01-29 15:03:57.2200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (57, 1, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'BB5FA48D8BAF420BB52CF69D4836B8E5', CAST(N'2019-01-29T15:03:57.2200000' AS DateTime2), N'TRDDE7BB94728F45B6802F18C43A951396', N'Succeed', N'2019-01-29 15:03:57.2200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (58, 1, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'E703C94ADB1044B49354404DEB269635', CAST(N'2019-01-29T15:03:57.2200000' AS DateTime2), N'TR573CD7676FFD4C669A4AC13E4A8F6408', N'Succeed', N'2019-01-29 15:03:57.2200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (59, 1, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'A7359DED90D8437D9BE42D1589CE9038', CAST(N'2019-01-29T15:03:57.2200000' AS DateTime2), N'TR178AC8DA6B774E88BB88A152950A8A9C', N'Succeed', N'2019-01-29 15:03:57.2200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (60, 1, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'C6C2A1C6C9154C20AE0FD21F7ED74D22', CAST(N'2019-01-29T15:04:48.3000000' AS DateTime2), N'TR7725A0F246E94C5289C7E7A980348D87', N'Succeed', N'2019-01-29 15:04:48.3000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (61, 1, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'5016F108994A461BBF43B7032E870E10', CAST(N'2019-01-29T15:04:48.3000000' AS DateTime2), N'TRCADC8822A37243FDBDC90F92564E97F6', N'Succeed', N'2019-01-29 15:04:48.3000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (62, 1, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'E0840D2346FE4CE18DC990AE889E934B', CAST(N'2019-01-29T15:04:48.3000000' AS DateTime2), N'TR873BE572B8714C38B898599FAE72BA58', N'Succeed', N'2019-01-29 15:04:48.3000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (63, 1, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'D99880C7FD7E4D899CD7B1CD0BEC6385', CAST(N'2019-01-29T15:04:48.3000000' AS DateTime2), N'TR6B2C217F94914D5AA266332151F8534D', N'Succeed', N'2019-01-29 15:04:48.3000000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (64, 1, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'12DEF2A916614EE8BC7CB905F4AABE13', CAST(N'2018-01-29T15:04:48.8900000' AS DateTime2), N'TRE65753E0E1ED4FB18DF25978E8BD6F1B', N'Succeed', N'2019-01-29 15:04:48')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (65, 1, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'12DEF2A916614EE8BC7CB905F4AABE13', CAST(N'2018-01-29T15:04:48.8900000' AS DateTime2), N'TR538B7FF3BE57416AA9BD876BFCBE92F0', N'Succeed', N'2019-01-29 15:04:48')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (66, 1, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'55A73717BE0441279CCA82BDE819980C', CAST(N'2019-01-29T15:04:48.8900000' AS DateTime2), N'TRC55D70313C5649B18D55C1CF2DA7AA4F', N'Succeed', N'2019-01-29 15:04:48.8900000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (67, 1, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'3EBD059B9BAB403DABDF0565EAFA500A', CAST(N'2019-01-29T15:04:48.8900000' AS DateTime2), N'TR8114FFBF0FB041FD873270F2618B62EF', N'Succeed', N'2019-01-29 15:04:48.8900000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (68, 2, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'BC52AD701D1848EDAF1DF94379B926E3', CAST(N'2019-01-29T15:04:51.3200000' AS DateTime2), N'TR76BD018BA98E4388B24E8CC7932C44F7', N'Succeed', N'2019-01-29 15:04:51.3200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (69, 2, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'EF7CD7A436C5439292AEF58D2287C4F2', CAST(N'2018-12-29T15:04:51.3200000' AS DateTime2), N'TR47B4857E71BF4F3B8D3FF8CFD105F471', N'Succeed', N'2019-01-29 15:04:51')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (70, 2, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'73BC8AA1D5474F188950C64D049A1056', CAST(N'2019-01-29T15:04:51.3200000' AS DateTime2), N'TR7D1941AFF72A4403805C4FC111A6FB50', N'Succeed', N'2019-01-29 15:04:51.3200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (71, 2, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'F7DF444EE2A34269856F6ABB067CD499', CAST(N'2019-01-29T15:04:51.3200000' AS DateTime2), N'TR0282AA709275422EA23B56B9004BE487', N'Succeed', N'2019-01-29 15:04:51.3200000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (72, 2, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'EF7CD7A436C5439292AEF58D2287C4F2', CAST(N'2018-12-20T15:04:51.7800000' AS DateTime2), N'TR1E9F990F12FC4CCBB3DC6BB233F71FE5', N'Succeed', N'2019-01-29 15:04:51')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (73, 2, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'FA3BA48B6F1F4E04980CF4828C0D4F41', CAST(N'2019-01-05T15:04:51.7800000' AS DateTime2), N'TR25420CE4100F48DCA99A1AA56171CB34', N'Succeed', N'2019-01-29 15:04:51.7800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (74, 2, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'0A15B579995244A29389294CF0E3AF1D', CAST(N'2019-01-29T15:04:51.7800000' AS DateTime2), N'TRC718722410D44AE788F66689025BCFF0', N'Succeed', N'2019-01-29 15:04:51.7800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (75, 2, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'868BE5FA2BE64D1EAEFE469699AEC0FC', CAST(N'2019-01-29T15:04:51.7800000' AS DateTime2), N'TR10E2FBB263304C32AF84C2AF7ABEF3C4', N'Succeed', N'2019-01-29 15:04:51.7800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (76, 3, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'87B9E9B909044DF1BDE386391AEC0B86', CAST(N'2019-01-12T15:04:54.3166667' AS DateTime2), N'TR7232A8462EF947878E2F88B83F024AA2', N'Succeed', N'2019-01-29 15:04:54.3166667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (77, 3, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'B219D53C894D4E7DA2B56930F5FAF02F', CAST(N'2019-01-29T15:04:54.3166667' AS DateTime2), N'TR842D38A22530417898E71CD36ADE373D', N'Succeed', N'2019-01-29 15:04:54.3166667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (78, 3, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'F75970414CD34052BE93C572C3E9ED51', CAST(N'2019-01-29T15:04:54.3166667' AS DateTime2), N'TRF14C63DAFE7149838BE21E5F3F5DD3B5', N'Succeed', N'2019-01-29 15:04:54.3166667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (79, 3, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'1257E6BCD3F343E4B9B12A327B541614', CAST(N'2019-01-29T15:04:54.3166667' AS DateTime2), N'TRB7C5ABCA1E42406DA81629B16D045C37', N'Succeed', N'2019-01-29 15:04:54.3166667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (80, 3, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'F3414173B8904F928ED76586E65EF549', CAST(N'2019-01-10T15:04:54.7266667' AS DateTime2), N'TR1C04EEFE67E94789925EF008F6C8AA0E', N'Succeed', N'2019-01-29 15:04:54.7266667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (81, 3, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'16551157BC3D4DBBBF837FA95DD03743', CAST(N'2019-01-29T15:04:54.7266667' AS DateTime2), N'TR384D21CA752C41D5A87B3A29CAB8D19C', N'Succeed', N'2019-01-29 15:04:54.7266667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (82, 3, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'00C76A1F9D594AF5A3AE4ABAE080CF8D', CAST(N'2019-01-01T15:04:54.7266667' AS DateTime2), N'TR0D97B28ED9A84FA9848838ED0E714043', N'Succeed', N'2019-01-29 15:04:54.7266667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (83, 3, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'04B7289B9F8A4BD09B49A4DD3A7F6454', CAST(N'2019-01-29T15:04:54.7266667' AS DateTime2), N'TRF36BEA928337419A9FEF63495169FCCA', N'Succeed', N'2019-01-29 15:04:54.7266667')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (84, 6, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'D0C9B58685844A96BA18BDE4D7E5F1DF', CAST(N'2019-01-29T15:04:57.6800000' AS DateTime2), N'TR39B58CA6FD34430B9D2BD6EF7D01EED1', N'Succeed', N'2019-01-29 15:04:57.6800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (85, 6, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'4DF0F9BD7ECF4C6A90F6F6CE13E7C282', CAST(N'2019-01-29T15:04:57.6800000' AS DateTime2), N'TRCDAA518D9DF741D2879552D3CDF04BFA', N'Failed', N'2019-01-29 15:04:57.6800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (86, 6, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'43AAC5CBD9C0425680F93C142801F5A2', CAST(N'2019-01-29T15:04:57.6800000' AS DateTime2), N'TRA9A07CDF3B98409A8D9338B588EA3654', N'Failed', N'2019-01-29 15:04:57.6800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (87, 6, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'8D78F7CD6EF74F0F811052868D376BBB', CAST(N'2019-01-29T15:04:57.6800000' AS DateTime2), N'TRAF87D5A609594851A0F1154D8688C7B1', N'Failed', N'2019-01-29 15:04:57.6800000')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (88, 6, 10, CAST(12000.00 AS Decimal(18, 2)), 1, N'6D76881A161D4A039EF6BF9C4C61B9FA', CAST(N'2019-01-29T15:04:58.0933333' AS DateTime2), N'TR7904F0C5849E4C3DB4D64368E9FF1088', N'Succeed', N'2019-01-29 15:04:58')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (89, 6, 11, CAST(12000.00 AS Decimal(18, 2)), 1, N'6D76881A161D4A039EF6BF9C4C61B9FA', CAST(N'2019-01-29T15:04:58.0933333' AS DateTime2), N'TR0EBDC4A12B2F46B99DE2C15EE37C2116', N'Succeed', N'2019-01-29 15:04:58')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (90, 6, 12, CAST(12000.00 AS Decimal(18, 2)), 1, N'79D6D3ED54824006ACBAF7B38FB7A3BB', CAST(N'2019-01-29T15:04:58.0933333' AS DateTime2), N'TR81E49C30CCAB418D9F0CD1971B44C912', N'Succeed', N'2019-01-29 15:04:58.0933333')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [CartNumber], [AddToCartDate], [PaymentTransactionNumber], [TransactionStatus], [OrderDate]) VALUES (91, 6, 13, CAST(12000.00 AS Decimal(18, 2)), 1, N'987660FACBDF4255883479101DE59200', CAST(N'2019-01-29T15:04:58.0933333' AS DateTime2), N'TR80FA60B6DA9A44A29690CB82108C484E', N'Failed', N'2019-01-29 15:04:58.0933333')
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrders] OFF
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [IsActive]
GO
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
