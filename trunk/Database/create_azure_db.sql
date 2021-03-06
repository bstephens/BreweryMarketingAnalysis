/****** Object:  Table [dbo].[AnnualSales]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnnualSales](
	[AnnualSalesID] [int] IDENTITY(1,1) NOT NULL,
	[MfrID] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Sales] [decimal](18, 0) NOT NULL,
 CONSTRAINT [IDX_PK_AnnualSales] PRIMARY KEY CLUSTERED 
(
	[AnnualSalesID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Brand]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[MfrID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[Name] [varchar](45) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Alcohol] [decimal](3, 1) NOT NULL,
	[Calories] [int] NOT NULL,
 CONSTRAINT [IDX_PK_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[BrewedAt]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrewedAt](
	[BrandID] [int] NOT NULL,
	[BreweryID] [int] NOT NULL,
 CONSTRAINT [IDX_PK_BrewedAt] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC,
	[BreweryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Brewery]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brewery](
	[BreweryID] [int] IDENTITY(1,1) NOT NULL,
	[MfrID] [int] NOT NULL,
	[Name] [int] NOT NULL,
	[Opened] [datetime] NOT NULL,
	[City] [varchar](45) NOT NULL,
	[State] [varchar](45) NOT NULL,
	[Country] [varchar](45) NOT NULL,
 CONSTRAINT [IDX_PK_Brewery] PRIMARY KEY CLUSTERED 
(
	[BreweryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[MfrID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](45) NOT NULL,
	[Country] [varchar](45) NOT NULL,
	[Capacity] [int] NOT NULL,
	[City] [varchar](45) NOT NULL,
	[State] [varchar](45) NOT NULL,
 CONSTRAINT [IDX_PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[MfrID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Ranking]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranking](
	[RankingID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [IDX_PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[RankingID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[SocialMediaInfo]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMediaInfo](
	[SocialMediaInfoID] [int] IDENTITY(1,1) NOT NULL,
	[BrandID] [int] NOT NULL,
	[Information] [varchar](max) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[SearchDate] [date] NOT NULL,
 CONSTRAINT [IDX_PK_SocialMediaInfo] PRIMARY KEY CLUSTERED 
(
	[SocialMediaInfoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Type]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](45) NOT NULL,
	[Description] [varchar](45) NOT NULL,
 CONSTRAINT [IDX_PK_Type] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/26/2014 11:33:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](45) NOT NULL,
	[LastName] [varchar](45) NOT NULL,
	[ScreenName] [varchar](45) NOT NULL,
	[AccessToken] [varchar](2000) NOT NULL,
	[AccessTokenSecret] [varchar](2000) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsSubscribed] [bit] NOT NULL,
 CONSTRAINT [IDX_PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (1, 8, 1, N'Fat Tire', N'', CAST(0x0000A2FA0173B7AF AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (2, 8, 11, N'Mighty Arrow', N'', CAST(0x0000A2FA0173B7AF AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (3, 8, 5, N'1554', N'', CAST(0x0000A2FA0173B7AF AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (4, 7, 13, N'Carlesberg', N'', CAST(0x0000A2FA0173B7B0 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (5, 7, 13, N'Holsten Pilsner', N'', CAST(0x0000A2FA0173B7B0 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (6, 7, 13, N'Baltika no. 3', N'', CAST(0x0000A2FA0173B7B0 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (7, 5, 10, N'Samuel Adams Boston Lager', N'', CAST(0x0000A2FA0173B7B1 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (8, 5, 17, N'Samuel Adams Cold Snap', N'', CAST(0x0000A2FA0173B7B1 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (9, 5, 10, N'Samuel Adams Oktoberfest', N'', CAST(0x0000A2FA0173B7B1 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (10, 6, 10, N'Genesee', N'', CAST(0x0000A2FA0173B7B4 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (11, 6, 8, N'Magic Hat ', N'', CAST(0x0000A2FA0173B7B4 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (12, 6, 12, N'Labatt Blue', N'', CAST(0x0000A2FA0173B7B4 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (13, 17, 4, N'Arrogant Bastard Ale', N'', CAST(0x0000A2FA0173B7B4 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (14, 17, 11, N'Stone Pale Ale', N'', CAST(0x0000A2FA0173B7B5 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (15, 17, 7, N'Stone Ruination IPA', N'', CAST(0x0000A2FA0173B7B5 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (16, 18, 2, N'Brooklyn Lager', N'', CAST(0x0000A2FA0173B7B5 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (17, 18, 3, N'Brooklyn Brown Ale', N'', CAST(0x0000A2FA0173B7B5 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (18, 18, 7, N'Brooklyn East India Pale Ale', N'', CAST(0x0000A2FA0173B7B5 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (19, 1, 13, N'Stella Artois', N'', CAST(0x0000A2FA0173B7B5 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (20, 1, 10, N'Becks', N'', CAST(0x0000A2FA0173B7B6 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (21, 1, 10, N'Budwiser', N'', CAST(0x0000A2FA0173B7B6 AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (22, 1, 10, N'Bud Light', N'', CAST(0x0000A2FA0173B7BA AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (23, 4, 10, N'Traditional Lager', N'', CAST(0x0000A2FA0173B7BA AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (24, 4, 5, N'Black and Tan', N'', CAST(0x0000A2FA0173B7BA AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (25, 4, 14, N'Porter', N'', CAST(0x0000A2FA0173B7BB AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (26, 3, 11, N'Shipyard Light', N'', CAST(0x0000A2FA0173B7BB AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (27, 3, 6, N'Shipyard Brown Ale', N'', CAST(0x0000A2FA0173B7BB AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (28, 3, 15, N'Shipyard Pumpkin', N'', CAST(0x0000A2FA0173B7BB AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (29, 2, 16, N'Purple Haze', N'', CAST(0x0000A2FA0173B7BB AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (30, 2, 6, N'Turbodog', N'', CAST(0x0000A2FA0173B7BC AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (31, 2, 1, N'Amber', N'', CAST(0x0000A2FA0173B7BC AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (32, 19, 9, N'Extra Stout', N'', CAST(0x0000A2FA0173B7BC AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (33, 19, 9, N'Guinness Draught', N'', CAST(0x0000A2FA0173B7BC AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (34, 20, 7, N'60 Minute IPA', N'', CAST(0x0000A2FA0173B7BD AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (35, 20, 7, N'90 Minute IPA', N'', CAST(0x0000A2FA0173B7BD AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
INSERT [dbo].[Brand] ([BrandID], [MfrID], [TypeID], [Name], [Description], [StartDate], [Alcohol], [Calories]) VALUES (36, 20, 7, N'120 Minute IPA', N'', CAST(0x0000A2FA0173B7BD AS DateTime), CAST(0.0 AS Decimal(3, 1)), 0)
SET IDENTITY_INSERT [dbo].[Brand] OFF
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (1, N'Anheuser-Busch Inc.', N'US', 339945117, N'St. Louis ', N'MO')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (2, N'Abita Brewing Co.', N'US', 360000, N'Abita Springs', N'LA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (3, N'Shipyard Brewing Co.', N'US', 816410, N'Portland', N'ME')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (4, N'D. G. Yuengling and Son Inc.', N'US', 2500000, N'Pottsville', N'PA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (5, N'Boston Beer Co.', N'US', 2746000, N'Boston', N'MA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (6, N'North American Breweries', N'US', 1400000, N'Rochester', N'NY')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (7, N'Carlsberg Group', N'DK', 118164578, N'Copenhagen', N'')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (8, N'New Belgium Brewing Co.', N'US', 764424, N'Fort Collins', N'CO')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (9, N'Craft Brew Alliance, Inc.', N'US', 724900, N'Portland', N'OR')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (10, N'Heineken International', N'NL', 116738888, N'Amsterdam', N'')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (11, N'Sierra Nevada Brewing Co.', N'US', 780000, N'Chico', N'CA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (12, N'MillerCoors', N'US', 65020000, N'Chicago', N'IL')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (13, N'Lagunitas Brewing Co.', N'US', 520000, N'Petaluma', N'CA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (14, N'Bell''s Brewery, Inc.', N'US', 216000, N'Galesburg', N'MI')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (15, N'Matt Brewing Co.', N'US', 208000, N'Utica', N'NY')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (16, N'Harpoon Brewery', N'US', 193000, N'Boston', N'MA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (17, N'Stone Brewing Co.', N'US', 213277, N'Escondido', N'CA')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (18, N'Brooklyn Brewery', N'US', 120000, N'Brooklyn', N'NY')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (19, N'St. James''s Gate Brewery Brewing Co.', N'IE', 50700000, N'Dublin', N'')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (20, N'Dogfish Head Craft Brewery', N'US', 175000, N'Milton', N'DE')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (21, N'The Gambrinus Co.', N'US', 567100, N'San Antonio', N'TX')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (22, N'Minhas Craft Brewery', N'US', 280000, N'Monroe', N'WI')
INSERT [dbo].[Manufacturer] ([MfrID], [Name], [Country], [Capacity], [City], [State]) VALUES (23, N'Deschutes Brewery', N'US', 220900, N'Bend', N'OR')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (1, N'Amber Ale', N'Amber Ale')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (2, N'American Amber Lager', N'American Amber Lager')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (3, N'American Brown Ale', N'American Brown Ale')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (4, N'American Strong Ale', N'American Strong Ale')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (5, N'Black Lager', N'Black Lager')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (6, N'Brown Ale', N'Brown Ale')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (7, N'India Pale Ale', N'India Pale Ale')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (8, N'India Pale Lager', N'India Pale Lager')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (9, N'Irish Dry Stout', N'Irish Dry Stout')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (10, N'Lager', N'Lager')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (11, N'Pale Ale', N'Pale Ale')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (12, N'Pale Lager', N'Pale Lager')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (13, N'Pilsner', N'Pilsner')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (14, N'Porter', N'Porter')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (15, N'Pumpkin', N'Pumpkin')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (16, N'Fruit', N'Fruit')
INSERT [dbo].[Type] ([TypeID], [Name], [Description]) VALUES (17, N'White Ale', N'White Ale')
SET IDENTITY_INSERT [dbo].[Type] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [ScreenName], [AccessToken], [AccessTokenSecret], [IsAdmin], [CreatedOn], [IsSubscribed]) VALUES (1, N'Blake', N'Blake', N'wtflmtfa', N'160214682-LfN3vFToDKicEbtXHHkKvX3Uph3mLcfRAtQ5fpn1', N'453V90YK6dstPafaRJxV9mpG23sdNQ07BPD251BfTkITK', 1, CAST(0x0000A2FA0163225E AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[AnnualSales]  WITH CHECK ADD  CONSTRAINT [FK_AnnualSales_Manufacturer] FOREIGN KEY([MfrID])
REFERENCES [dbo].[Manufacturer] ([MfrID])
GO
ALTER TABLE [dbo].[AnnualSales] CHECK CONSTRAINT [FK_AnnualSales_Manufacturer]
GO
ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [FK_Brand_Manufacturer] FOREIGN KEY([MfrID])
REFERENCES [dbo].[Manufacturer] ([MfrID])
GO
ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [FK_Brand_Manufacturer]
GO
ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [FK_Brand_Type] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Type] ([TypeID])
GO
ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [FK_Brand_Type]
GO
ALTER TABLE [dbo].[BrewedAt]  WITH CHECK ADD  CONSTRAINT [FK_BrewedAt_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[BrewedAt] CHECK CONSTRAINT [FK_BrewedAt_Brand]
GO
ALTER TABLE [dbo].[BrewedAt]  WITH CHECK ADD  CONSTRAINT [FK_BrewedAt_Brewery] FOREIGN KEY([BreweryID])
REFERENCES [dbo].[Brewery] ([BreweryID])
GO
ALTER TABLE [dbo].[BrewedAt] CHECK CONSTRAINT [FK_BrewedAt_Brewery]
GO
ALTER TABLE [dbo].[Brewery]  WITH CHECK ADD  CONSTRAINT [FK_Brewery_Manufacturer] FOREIGN KEY([MfrID])
REFERENCES [dbo].[Manufacturer] ([MfrID])
GO
ALTER TABLE [dbo].[Brewery] CHECK CONSTRAINT [FK_Brewery_Manufacturer]
GO
ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_Ranking_Band] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_Ranking_Band]
GO
ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_Ranking_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_Ranking_User]
GO
ALTER TABLE [dbo].[SocialMediaInfo]  WITH CHECK ADD  CONSTRAINT [FK_SocialMediaInfo_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[SocialMediaInfo] CHECK CONSTRAINT [FK_SocialMediaInfo_Brand]
GO
