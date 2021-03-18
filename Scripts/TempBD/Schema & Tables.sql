USE [TempBD]
GO
/****** Object:  Schema [Admin]    Script Date: 18/03/2021 12:25:42 a. m. ******/
CREATE SCHEMA [Admin]
GO
/****** Object:  Schema [Finance]    Script Date: 18/03/2021 12:25:42 a. m. ******/
CREATE SCHEMA [Finance]
GO
/****** Object:  Table [Admin].[Roles]    Script Date: 18/03/2021 12:25:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Roles](
	[Roleid] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Roleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Users]    Script Date: 18/03/2021 12:25:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Users](
	[Userid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FirstLastName] [nvarchar](50) NOT NULL,
	[SecondLastName] [nvarchar](50) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[Salary] [decimal](10, 2) NOT NULL,
	[BreakFast] [decimal](10, 2) NOT NULL,
	[Savings] [decimal](10, 2) NOT NULL,
	[isActive] [bit] NOT NULL,
	[Roleid] [int] NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[UserLogin] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Finance].[Paysheets]    Script Date: 18/03/2021 12:25:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Finance].[Paysheets](
	[Paysheetid] [int] IDENTITY(1,1) NOT NULL,
	[Userid] [int] NOT NULL,
	[Salary] [decimal](10, 2) NOT NULL,
	[BreakFast] [decimal](10, 2) NOT NULL,
	[Savings] [decimal](10, 2) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Finance.Paysheets] PRIMARY KEY CLUSTERED 
(
	[Paysheetid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Admin].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Roleid])
REFERENCES [Admin].[Roles] ([Roleid])
GO
ALTER TABLE [Admin].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [Finance].[Paysheets]  WITH CHECK ADD  CONSTRAINT [FK_Paysheets_Users] FOREIGN KEY([Userid])
REFERENCES [Admin].[Users] ([Userid])
GO
ALTER TABLE [Finance].[Paysheets] CHECK CONSTRAINT [FK_Paysheets_Users]
GO
