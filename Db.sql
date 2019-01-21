/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/21/2019 7:11:57 AM ******/
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
/****** Object:  Table [dbo].[ApplicationGroup]    Script Date: 1/21/2019 7:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationGroup](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Owner] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApplicationGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationGroupRoles]    Script Date: 1/21/2019 7:11:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationGroupRoles](
	[ApplicationGroupId] [nvarchar](450) NOT NULL,
	[ApplicationRoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ApplicationGroupRoles] PRIMARY KEY CLUSTERED 
(
	[ApplicationRoleId] ASC,
	[ApplicationGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 1/21/2019 7:11:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserGroups](
	[ApplicationUserId] [nvarchar](450) NOT NULL,
	[ApplicationGroupId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ApplicationUserGroups] PRIMARY KEY CLUSTERED 
(
	[ApplicationUserId] ASC,
	[ApplicationGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRole]    Script Date: 1/21/2019 7:11:59 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[AspNetUser]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 1/21/2019 7:12:00 AM ******/
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
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 1/21/2019 7:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFeatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ProductFeatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductKeyBenefit]    Script Date: 1/21/2019 7:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductKeyBenefit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ProductKeyBenefit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPerformance]    Script Date: 1/21/2019 7:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPerformance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ProductPerformance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/21/2019 7:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartFrom] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Image] [nvarchar](max) NOT NULL,
	[IsExpressionOfInterest] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 1/21/2019 7:12:00 AM ******/
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
	[OrderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PurchaseOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190120104456_arm', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190120142439_arm2', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190120143815_arm3', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190120143916_arm4', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190120143954_arm5', N'2.2.0-rtm-35687')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190120163149_arm6', N'2.2.0-rtm-35687')
SET IDENTITY_INSERT [dbo].[AspNetRole] ON 

INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Sales:Team', N'SALES:TEAM', N'be3233f9-14a6-4b9c-8c5a-c635478cd05a')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Sales:Team:Management', N'SALES:TEAM:MANAGEMENT', N'8a58f481-5eb0-4ebd-a0ee-8a934f88c118')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Administrator', N'ADMINISTRATOR', N'c38df6f6-2365-49ef-9631-639ac326c589')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, N'Super:Administrator', N'SUPER:ADMINISTRATOR', N'89cc682f-2236-421f-8cf6-53dbcce34bb9')
INSERT [dbo].[AspNetRole] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (5, N'Client', N'CLIENT', N'8fcf022a-aa72-49e9-b4c8-fb25d6e5945e')
SET IDENTITY_INSERT [dbo].[AspNetRole] OFF
SET IDENTITY_INSERT [dbo].[AspNetUser] ON 

INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (1, N'alu.olu@gmail.com', N'ALU.OLU@GMAIL.COM', N'alu.olu@gmail.com', N'ALU.OLU@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEM4Z6oPdv8WpjMerpJE8x5J+K5Im6D5vN6Inh9RKsIxhLnAAThWf3nrHkKmucSY5rA==', N'PDGQ7AVQMCCXEAGVZFQ5S4OG72Y5R6SR', N'd51b49a4-a461-40d9-ad94-df8f24058885', NULL, 0, 0, NULL, 1, 0, N'WA1234', N'Alu', N'Olu', N'external', N'1000022')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (2, N'rolse@gmail.com', N'ROLSE@GMAIL.COM', N'rolse@gmail.com', N'ROLSE@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOGgHtegSUVdAc27s66UqdKrGs2ZEOp5bfizRZMGYjg+C3AtPJH9YtKVIjkLabqqNQ==', N'MT3A7YZIIQFX745DLUSJWUQEOKCGGNOM', N'32859178-59da-43a7-9cb9-4df1a99e9f7c', NULL, 0, 0, NULL, 1, 0, N'WA0110', N'rolse', N'oyin', N'external', N'321022')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (3, N'mayowaogidipe@gmail.com', N'MAYOWAOGIDIPE@GMAIL.COM', N'mayowaogidipe@gmail.com', N'MAYOWAOGIDIPE@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIf8GK0fYCMiXY3u0CjY8gA1yNmOMVLfPZoOCt5RfORGVefuC40oWO991zTAocGeZw==', N'3TIDXB5QJ4VHG6C2LSPBAXLVI6XRWSIY', N'dbdf6203-5f79-4962-8d93-661d337352ef', NULL, 0, 0, NULL, 1, 0, N'WA98745', N'Mayowa', N'Ogidipe', N'external', N'776423')
INSERT [dbo].[AspNetUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserNameAlternative], [FirstName], [LastName], [IsCustomerOrStaff], [MembershipNumber]) VALUES (4, N'oghenne.mudiaga@gmail.com', N'OGHENNE.MUDIAGA@GMAIL.COM', N'oghenne.mudiaga@gmail.com', N'OGHENNE.MUDIAGA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFKDbvRDZENcdcggRTpVaefq4pjQed2x5jOlucEmH313xQa9gKx4ZZaDuQ/dmtdrsg==', N'V2Q6VQ57V6DEX4TACAEXTZUTF5PXNEX4', N'f24209dc-a592-4eb8-8d42-9a0824a34e3a', NULL, 0, 0, NULL, 1, 0, N'WA0045', N'Oghenne', N'Mudiaga', N'external', N'432423')
SET IDENTITY_INSERT [dbo].[AspNetUser] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (1, N'Mutual Fund')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (2, N'Pension')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (3, N'Real Estate')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [IsExpressionOfInterest]) VALUES (1, 1, N'nnn', CAST(56.00 AS Decimal(18, 2)), N'jjjj', N'dc95f36ca82347b2b1f8cc8fe93dc0a2.jpeg', N'No')
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [IsExpressionOfInterest]) VALUES (2, 1, N'ARM Aggressive Growth Fund', CAST(50000.00 AS Decimal(18, 2)), N'Meet long-term objectives such as education funding, property acquisition and the likes with the high capital growth obtainable in the Aggressive Growth Fund.', N'590d85dd5f944c529fc24c7632e96614.jpeg', N'No')
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [IsExpressionOfInterest]) VALUES (3, 1, N'ARM Discovery Fund', CAST(10000.00 AS Decimal(18, 2)), N'Are you looking for high yeilding investments over the long term to meet objectives such as education funding, property acquisition or leaving a legacy for loved ones?', N'ae8abef68b0347c2a39a93b9b4e4ddd9.jpeg', N'No')
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [IsExpressionOfInterest]) VALUES (4, 1, N'ARM Ethical Fund: Invest now', CAST(10000.00 AS Decimal(18, 2)), N'Put your money where your heart is, invest in a fund that grows your capital without compromising your ethics.', N'299829c1a27c4ce5b2a524bc0dc7237a.jpeg', N'No')
INSERT [dbo].[Products] ([Id], [ProductCategoryId], [Name], [StartFrom], [Description], [Image], [IsExpressionOfInterest]) VALUES (5, 3, N'Adiva Plainfields Phase II', CAST(1500000.00 AS Decimal(18, 2)), N'Adiva Phase II now selling! Over 1000 homes and plots delivered in Phase 1.', N'cb3adae4056c4a179ed3bcc60376031b.jpeg', N'Yes')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON 

INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (1, 1, 3, CAST(50000.00 AS Decimal(18, 2)), 1, CAST(N'2019-01-20T15:42:59.5966667' AS DateTime2))
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (2, 2, 4, CAST(50000.00 AS Decimal(18, 2)), 1, CAST(N'2019-01-20T16:01:13.3900000' AS DateTime2))
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (3, 1, 4, CAST(50000.00 AS Decimal(18, 2)), 1, CAST(N'2019-01-20T16:01:21.5900000' AS DateTime2))
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (4, 1, 1, CAST(50000.00 AS Decimal(18, 2)), 1, CAST(N'2019-01-20T16:01:32.1333333' AS DateTime2))
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (5, 3, 1, CAST(50000.00 AS Decimal(18, 2)), 1, CAST(N'2019-01-20T16:01:49.5133333' AS DateTime2))
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (6, 3, 5, CAST(0.00 AS Decimal(18, 2)), 1, CAST(N'2019-01-20T19:04:56.3266667' AS DateTime2))
INSERT [dbo].[PurchaseOrders] ([Id], [CustomerId], [ProductId], [Amount], [Quantity], [OrderDate]) VALUES (7, 2, 5, CAST(0.00 AS Decimal(18, 2)), 3, CAST(N'2019-01-20T19:05:16.8566667' AS DateTime2))
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
