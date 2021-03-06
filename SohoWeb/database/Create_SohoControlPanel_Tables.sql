USE [SohoControlPanel]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[UserID] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[UserAuthCode] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserName] [nvarchar](100) NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserName] [nvarchar](100) NULL,
	[EditUserSysNo] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFunctions]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFunctions](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[UserSysNo] [int] NOT NULL,
	[FunctionSysNo] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserName] [nvarchar](100) NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserName] [nvarchar](100) NULL,
	[EditUserSysNo] [int] NULL,
 CONSTRAINT [PK_UserFunctions] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUsers]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUsers](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[RoleSysNo] [int] NOT NULL,
	[UserSysNo] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserName] [nvarchar](100) NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserName] [nvarchar](100) NULL,
	[EditUserSysNo] [int] NULL,
 CONSTRAINT [PK_RoleUsers] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserName] [nvarchar](100) NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserName] [nvarchar](100) NULL,
	[EditUserSysNo] [int] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleFunctions]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleFunctions](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[RoleSysNo] [int] NOT NULL,
	[FunctionSysNo] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserName] [nvarchar](100) NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserName] [nvarchar](100) NULL,
	[EditUserSysNo] [int] NULL,
 CONSTRAINT [PK_RoleFunctions] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[SysNo] [int] IDENTITY(10001,1) NOT NULL,
	[Classes] [int] NOT NULL,
	[Section] [int] NOT NULL,
	[Family] [int] NOT NULL,
	[RefenceSysNo] [int] NOT NULL,
	[Contents] [nvarchar](2000) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[InUserName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogCategorys]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogCategorys](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[ParentSysNo] [int] NOT NULL,
	[CategoryName] [nvarchar](40) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_LogCategorys] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Functions]    Script Date: 05/28/2014 21:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[FunctionName] [nvarchar](200) NULL,
	[FunctionKey] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Status] [int] NULL,
	[InDate] [datetime] NOT NULL,
	[InUserName] [nvarchar](100) NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[EditDate] [datetime] NULL,
	[EditUserName] [nvarchar](100) NULL,
	[EditUserSysNo] [int] NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
