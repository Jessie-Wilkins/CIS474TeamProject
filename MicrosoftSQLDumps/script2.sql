USE [master]
GO
/****** Object:  Database [cis474TeamProject]    Script Date: 12/2/2018 12:31:08 AM ******/
CREATE DATABASE [cis474TeamProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cis474TeamProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cis474TeamProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cis474TeamProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cis474TeamProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [cis474TeamProject] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cis474TeamProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cis474TeamProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cis474TeamProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cis474TeamProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cis474TeamProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cis474TeamProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [cis474TeamProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cis474TeamProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cis474TeamProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cis474TeamProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cis474TeamProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cis474TeamProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cis474TeamProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cis474TeamProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cis474TeamProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cis474TeamProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cis474TeamProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cis474TeamProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cis474TeamProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cis474TeamProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cis474TeamProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cis474TeamProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cis474TeamProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cis474TeamProject] SET RECOVERY FULL 
GO
ALTER DATABASE [cis474TeamProject] SET  MULTI_USER 
GO
ALTER DATABASE [cis474TeamProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cis474TeamProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cis474TeamProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cis474TeamProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cis474TeamProject] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'cis474TeamProject', N'ON'
GO
ALTER DATABASE [cis474TeamProject] SET QUERY_STORE = OFF
GO
USE [cis474TeamProject]
GO
/****** Object:  Schema [m2ss]    Script Date: 12/2/2018 12:31:09 AM ******/
CREATE SCHEMA [m2ss]
GO
/****** Object:  Schema [team_project475]    Script Date: 12/2/2018 12:31:09 AM ******/
CREATE SCHEMA [team_project475]
GO
/****** Object:  Table [team_project475].[contains]    Script Date: 12/2/2018 12:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [team_project475].[contains](
	[ItemID] [int] NOT NULL,
	[OptID] [int] NOT NULL,
 CONSTRAINT [PK_contains_ItemID] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[OptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [team_project475].[customer]    Script Date: 12/2/2018 12:31:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [team_project475].[customer](
	[CustomerID] [bigint] IDENTITY(7,1) NOT NULL,
	[CustomerName] [nvarchar](150) NULL,
	[PhoneNumber] [bigint] NULL,
	[Address] [nvarchar](80) NULL,
	[Email] [nvarchar](200) NULL,
	[CreditCardNumber] [bigint] NULL,
	[username] [nvarchar](80) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_customer_CustomerID] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [team_project475].[menu]    Script Date: 12/2/2018 12:31:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [team_project475].[menu](
	[ItemID] [bigint] IDENTITY(23,1) NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[BasePrice] [numeric](5, 2) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [menu$ItemID] UNIQUE CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [team_project475].[options]    Script Date: 12/2/2018 12:31:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [team_project475].[options](
	[OptID] [bigint] IDENTITY(22,1) NOT NULL,
	[OptName] [nvarchar](50) NULL,
 CONSTRAINT [options$OptID] UNIQUE CLUSTERED 
(
	[OptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [team_project475].[orders]    Script Date: 12/2/2018 12:31:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [team_project475].[orders](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [numeric](7, 2) NULL,
	[OptionsSelected] [nvarchar](500) NULL,
	[ETA] [time](7) NULL,
	[CustomerID] [int] NULL,
	[DateOfPurchase] [date] NULL,
	[ItemsSelected] [nchar](500) NULL,
 CONSTRAINT [orders$OrderID] UNIQUE CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [team_project475].[customer] ON 

INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (1, N'Smith, John', 1111111111, N'Baker Street', N'jsmith@mail.com', 1111111111111111, N'jsmith', N'password123')
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (3, N'Smith, Jane', 2222222222, N'Bonker Street', N'jgirlsmith@mail.com', 2222222222222222, NULL, NULL)
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (4, N'Burgundy, Ron', 3333333333, N'San Diego Street', N'imkindofabigdeal@mail.com', 3333333333333333, NULL, NULL)
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (5, NULL, NULL, NULL, NULL, NULL, N'wilkinsj', N'password')
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (6, NULL, NULL, NULL, NULL, NULL, N'testname', N'password')
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (7, NULL, NULL, NULL, NULL, NULL, N'test2', N'test2')
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (8, NULL, NULL, NULL, NULL, NULL, N'John', N'John')
INSERT [team_project475].[customer] ([CustomerID], [CustomerName], [PhoneNumber], [Address], [Email], [CreditCardNumber], [username], [password]) VALUES (9, NULL, NULL, NULL, NULL, NULL, N'jsmith', N'password123')
SET IDENTITY_INSERT [team_project475].[customer] OFF
SET IDENTITY_INSERT [team_project475].[menu] ON 

INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (1, N'Single Hamburger', CAST(6.00 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (2, N'Double Hamburger', CAST(7.00 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (4, N'Triple Hamburger', CAST(8.00 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (5, N'Chili Bowl', CAST(4.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (6, N'Loaded Potato Bowl', CAST(4.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (7, N'Broccoli Cheese Bowl', CAST(4.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (8, N'Vegetable Soup Bowl', CAST(4.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (9, N'Soup of the Day Bowl', CAST(4.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (10, N'Chili Cup', CAST(2.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (11, N'Loaded Potato Cup', CAST(2.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (12, N'Broccoli Cheese Cup', CAST(2.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (13, N'Vegetable Soup Cup', CAST(2.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (14, N'Soup of the Day Cup', CAST(2.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (15, N'Fries', CAST(2.50 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (16, N'Fried Greenbeans', CAST(3.75 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (17, N'Fried Mushrooms', CAST(4.00 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (18, N'Side Salad', CAST(3.25 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (19, N'Fresh Seasonal Fruit', CAST(3.25 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (20, N'Ice Cream Sundae', CAST(3.50 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (21, N'Cake of the Day', CAST(2.50 AS Numeric(5, 2)), N'')
INSERT [team_project475].[menu] ([ItemID], [ItemName], [BasePrice], [Description]) VALUES (22, N'Pie of the Day', CAST(2.50 AS Numeric(5, 2)), N'')
SET IDENTITY_INSERT [team_project475].[menu] OFF
SET IDENTITY_INSERT [team_project475].[options] ON 

INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (1, N'Cheese')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (2, N'Bacon')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (3, N'Lettuce')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (4, N'Tomato')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (5, N'Mayo')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (6, N'Ketchup')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (7, N'Mustard')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (8, N'Pickle')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (9, N'Onion')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (10, N'Carrots')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (11, N'Croutons')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (12, N'Ranch')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (13, N'French')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (14, N'Thousand Island')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (15, N'Italian')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (16, N'House Dressing')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (17, N'Hot Fudge')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (18, N'Hot Caramel')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (19, N'Sprinkles')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (20, N'Oreos')
INSERT [team_project475].[options] ([OptID], [OptName]) VALUES (21, N'Peanut Butter Cup')
SET IDENTITY_INSERT [team_project475].[options] OFF
SET IDENTITY_INSERT [team_project475].[orders] ON 

INSERT [team_project475].[orders] ([OrderID], [TotalPrice], [OptionsSelected], [ETA], [CustomerID], [DateOfPurchase], [ItemsSelected]) VALUES (1, CAST(30.00 AS Numeric(7, 2)), N'tomato', CAST(N'00:23:23' AS Time), 1, CAST(N'2018-12-01' AS Date), N'burger                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ')
INSERT [team_project475].[orders] ([OrderID], [TotalPrice], [OptionsSelected], [ETA], [CustomerID], [DateOfPurchase], [ItemsSelected]) VALUES (2, CAST(6.00 AS Numeric(7, 2)), N'System.Collections.Generic.Dictionary`2+ValueCollection[System.Int32,System.String]', CAST(N'00:23:00' AS Time), 1, CAST(N'2018-12-01' AS Date), N'System.Collections.Generic.Dictionary`2+ValueCollection[System.Int32,System.String]                                                                                                                                                                                                                                                                                                                                                                                                                                 ')
INSERT [team_project475].[orders] ([OrderID], [TotalPrice], [OptionsSelected], [ETA], [CustomerID], [DateOfPurchase], [ItemsSelected]) VALUES (3, CAST(6.00 AS Numeric(7, 2)), N'[1, ]', CAST(N'00:23:00' AS Time), 1, CAST(N'2018-12-02' AS Date), N'[1, Single Hamburger $6.00]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ')
SET IDENTITY_INSERT [team_project475].[orders] OFF
/****** Object:  Index [customer$CustomerID]    Script Date: 12/2/2018 12:31:11 AM ******/
ALTER TABLE [team_project475].[customer] ADD  CONSTRAINT [customer$CustomerID] UNIQUE NONCLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [CustomerName]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [PhoneNumber]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [Address]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [Email]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [CreditCardNumber]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [username]
GO
ALTER TABLE [team_project475].[customer] ADD  DEFAULT (NULL) FOR [password]
GO
ALTER TABLE [team_project475].[menu] ADD  DEFAULT (NULL) FOR [ItemName]
GO
ALTER TABLE [team_project475].[menu] ADD  DEFAULT (NULL) FOR [BasePrice]
GO
ALTER TABLE [team_project475].[menu] ADD  DEFAULT (NULL) FOR [Description]
GO
ALTER TABLE [team_project475].[options] ADD  DEFAULT (NULL) FOR [OptName]
GO
ALTER TABLE [team_project475].[orders] ADD  CONSTRAINT [DF__orders__TotalPri__619B8048]  DEFAULT (NULL) FOR [TotalPrice]
GO
ALTER TABLE [team_project475].[orders] ADD  CONSTRAINT [DF__orders__OptionsS__628FA481]  DEFAULT (NULL) FOR [OptionsSelected]
GO
ALTER TABLE [team_project475].[orders] ADD  CONSTRAINT [DF__orders__ETA__6383C8BA]  DEFAULT (NULL) FOR [ETA]
GO
ALTER TABLE [team_project475].[orders] ADD  CONSTRAINT [DF__orders__Customer__6477ECF3]  DEFAULT (NULL) FOR [CustomerID]
GO
ALTER TABLE [team_project475].[orders] ADD  CONSTRAINT [DF__orders__DateOfPu__656C112C]  DEFAULT (NULL) FOR [DateOfPurchase]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'team_project475.`contains`' , @level0type=N'SCHEMA',@level0name=N'team_project475', @level1type=N'TABLE',@level1name=N'contains'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'team_project475.customer' , @level0type=N'SCHEMA',@level0name=N'team_project475', @level1type=N'TABLE',@level1name=N'customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'team_project475.menu' , @level0type=N'SCHEMA',@level0name=N'team_project475', @level1type=N'TABLE',@level1name=N'menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'team_project475.options' , @level0type=N'SCHEMA',@level0name=N'team_project475', @level1type=N'TABLE',@level1name=N'options'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'team_project475.orders' , @level0type=N'SCHEMA',@level0name=N'team_project475', @level1type=N'TABLE',@level1name=N'orders'
GO
USE [master]
GO
ALTER DATABASE [cis474TeamProject] SET  READ_WRITE 
GO
