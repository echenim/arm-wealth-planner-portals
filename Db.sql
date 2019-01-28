/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/28/2019 7:05:14 AM ******/
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
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 1/28/2019 7:05:15 AM ******/
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
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 1/28/2019 7:05:15 AM ******/
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
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 1/28/2019 7:05:15 AM ******/
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
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 1/28/2019 7:05:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRole](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 1/28/2019 7:05:16 AM ******/
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
 CONSTRAINT [PK_AspNetUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[ProductKeyBenefit]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[ProductPerformance]    Script Date: 1/28/2019 7:05:16 AM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 1/28/2019 7:05:17 AM ******/
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
	[ProductTypes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 1/28/2019 7:05:17 AM ******/
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
	[OrderDate] [datetime2](7) NULL,
 CONSTRAINT [PK_PurchaseOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190127120926_Arm', N'2.2.0-rtm-35687')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190127121552_Arm1', N'2.2.0-rtm-35687')
GO
SET IDENTITY_INSERT [dbo].[ApplicationGroup] ON 
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (1, N'Administrator', N'BlaBlaCar is an online marketplace for carpooling. Its website and mobile apps connect drivers and passengers willing to travel together between cities and share the cost of the journey. Wikipedia', NULL)
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (2, N'Sales', N'sales team', NULL)
GO
INSERT [dbo].[ApplicationGroup] ([Id], [Name], [Description], [Owner]) VALUES (3, N'Marketing', N'marketing team', NULL)
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
SET IDENTITY_INSERT [dbo].[AspNetRole] ON 
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin:can:add', N'ADMIN:CAN:ADD', N'8381da92-f33c-481e-ad30-c3dc6ea01c45')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Admin:can:edit', N'ADMIN:CAN:EDIT', N'1bc1a254-c8e4-490f-8b52-8d0f007e9fb4')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Admin:can:view', N'ADMIN:CAN:VIEW', N'd01e4fee-cd12-46fb-a975-06cda680eb3b')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, N'Admin:can:delete', N'ADMIN:CAN:DELETE', N'813fb92e-f072-4ed1-961f-121d45e47d68')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (5, N'sale:can:delete', N'SALE:CAN:DELETE', N'0d016704-c0c6-4b06-beea-9088190dccbf')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (6, N'orders:can:delete', N'ORDERS:CAN:DELETE', N'fadd2834-2a2b-45fe-82dc-1b5005fae751')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (7, N'product:can:delete', N'PRODUCT:CAN:DELETE', N'bcd447a0-0cb9-485c-9f1a-ad58982582a3')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (8, N'customer:can:delete', N'CUSTOMER:CAN:DELETE', N'd9becbe3-62da-4f69-9469-a79739bc771a')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (9, N'customer:can:view', N'CUSTOMER:CAN:VIEW', N'e62cafc5-3c51-4924-bf89-659de96e8fbf')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (10, N'sale:can:view', N'SALE:CAN:VIEW', N'0abf2733-37a7-42b5-891a-3b4f2f070c23')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (11, N'orders:can:view', N'ORDERS:CAN:VIEW', N'e2253077-c2a8-4602-bd82-d588e12930db')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (12, N'product:can:view', N'PRODUCT:CAN:VIEW', N'6c6518be-a0e5-463f-8b71-d773fa330ea1')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (13, N'report:can:view', N'REPORT:CAN:VIEW', N'3066b814-b24d-4c11-a551-2bd0363fac78')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (14, N'report:can:print', N'REPORT:CAN:PRINT', N'36811c62-df33-47d8-927a-59ef73577024')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (15, N'customer:can:add', N'CUSTOMER:CAN:ADD', N'ae0de691-e1a8-4c3a-b5c9-d01a2ad3a7be')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (16, N'customer:can:report', N'CUSTOMER:CAN:REPORT', N'390d1325-2b94-4877-95d2-0d92b0d78088')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (17, N'product:can:add', N'PRODUCT:CAN:ADD', N'54a253e7-ade9-4872-b95d-d16f24e59935')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (18, N'product:can:edit', N'PRODUCT:CAN:EDIT', N'd53eb723-aa46-4463-a84c-5bba7e7fe9a8')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (19, N'sale:can:print', N'SALE:CAN:PRINT', N'd08af887-490b-4533-9047-0f4ffc7fe92a')
GO
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (20, N'dashboard:can:view', N'DASHBOARD:CAN:VIEW', N'4e893bd0-e581-45f1-8bb0-61ab8e54bf2b')
GO
SET IDENTITY_INSERT [dbo].[AspNetRole] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUser] ON 
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (1, N'mark.john@gmail.com', N'MARK.JOHN@GMAIL.COM', N'mark.john@gmail.com', N'MARK.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGqVEWjBDt+xX+yYVM2/0tLrIqMw+6jUtgPgEInoDYJ/qMoIp4J2/T8sn3kT6tHZLg==', N'EJTD6VDPVPSZERTROCGDTYREO6ARD2QJ', N'ca2aed33-e364-4e0f-a74f-55bf81f59151', NULL, 0, 0, NULL, 1, 0, N'mark.john', N'Mark', N'John', N'External', N'W1234567')
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (2, N'alice.john@gmail.com', N'ALICE.JOHN@GMAIL.COM', N'alice.john@gmail.com', N'ALICE.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEE+8QyAWb6+5OEgl/cVmcCFx/gtthj7lbEGsj95DTLusfsFYTnwy5/m1Bd836uoXGQ==', N'MD4VGI7SYXAWYDSSNLXVZAK655LEKFUH', N'25ecf38c-2dce-4e84-a7a1-089627cd3a9b', NULL, 0, 0, NULL, 1, 0, N'alice.john', N'Alic', N'John', N'External', N'W1034567')
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (3, N'rosy.john@gmail.com', N'ROSY.JOHN@GMAIL.COM', N'rosy.john@gmail.com', N'ROSY.JOHN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBIScOMahWOYCMU6cTgPzwg3Ia4wO8H+5BaBa3mOyizeRSVKH9dog5GuNE4I0s4sIg==', N'AW7AAUBGAJMFWQVAURFGDXMQVP75CTXE', N'0d21cc45-10eb-43dd-8549-19876887d385', NULL, 0, 0, NULL, 1, 0, N'rosy.john', N'Rosy', N'John', N'External', N'W1024567')
GO
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (6, N'jesica.micheal@gmail.com', N'JESICA.MICHEAL@GMAIL.COM', N'jesica.micheal@gmail.com', N'JESICA.MICHEAL@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEE37pcWQRoAnQPZaBL5zqtdA/XTUg++ey9qfCxPMGuKxZ19dc7NfKnU2YuZTKrIjNg==', N'EGSHOGMGW6RJTDROXXAVK4SPQSE4JRTS', N'bd540bf8-df32-4f5a-ad76-9f3943425b66', NULL, 0, 0, NULL, 1, 0, N'jesica.micheal', N'Jesica', N'Micheal', N'External', N'W1060122')
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
SET IDENTITY_INSERT [dbo].[ProductFeatures] ON 
GO
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [Description]) VALUES (1, 4, N'Most “how to” technology articles gloss over real world implementation pitfalls. This one is no exception. However, you’re more likely to encounter a vexing design roadblock when implementing a fluent interface than a technical one. The problem is that the fluent interface is neither design pattern nor framework. It is a style of API; and as such suffers the same challenges you’d face when designing any API. Of course, the fluent interface introduces its own additional flavor of API design challenges.')
GO
SET IDENTITY_INSERT [dbo].[ProductFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductKeyBenefit] ON 
GO
INSERT [dbo].[ProductKeyBenefit] ([Id], [ProductId], [Description]) VALUES (1, 4, N'Most “how to” technology articles gloss over real world implementation pitfalls. This one is no exception. However, you’re more likely to encounter a vexing design roadblock when implementing a fluent interface than a technical one. The problem is that the fluent interface is neither design pattern nor framework. It is a style of API; and as such suffers the same challenges you’d face when designing any API. Of course, the fluent interface introduces its own additional flavor of API design challenges.')
GO
SET IDENTITY_INSERT [dbo].[ProductKeyBenefit] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes]) VALUES (2, 5, N'myron', CAST(500.00 AS Decimal(18, 2)), N'Most “how to” technology articles gloss over real world implementation pitfalls. This one is no exception. However, you’re more likely to encounter a vexing design roadblock when implementing a fluent interface than a technical one. The problem is that the fluent interface is neither design pattern nor framework. It is a style of API; and as such suffers the same challenges you’d face when designing any API. Of course, the fluent interface introduces its own additional flavor of API design challenges.', N'1b5cdc251c1d498ab6616f6de41fd5e5.jpeg', N'Fixed Amount')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes]) VALUES (3, 6, N'Life Saver', CAST(0.00 AS Decimal(18, 2)), N'Most “how to” technology articles gloss over real world implementation pitfalls. This one is no exception. However, you’re more likely to encounter a vexing design roadblock when implementing a fluent interface than a technical one. The problem is that the fluent interface is neither design pattern nor framework. It is a style of API; and as such suffers the same challenges you’d face when designing any API. Of course, the fluent interface introduces its own additional flavor of API design challenges.', N'6028af7887fe4f719050d61e27efa3a9.jpeg', N'Enter Amount')
GO
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [ProductTypes]) VALUES (4, 6, N'blabla', CAST(0.00 AS Decimal(18, 2)), N'Most “how to” technology articles gloss over real world implementation pitfalls. This one is no exception. However, you’re more likely to encounter a vexing design roadblock when implementing a fluent interface than a technical one. The problem is that the fluent interface is neither design pattern nor framework. It is a style of API; and as such suffers the same challenges you’d face when designing any API. Of course, the fluent interface introduces its own additional flavor of API design challenges.', N'2e32d8862e9643658e21762eb336236c.jpeg', N'Enter Amount')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
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
