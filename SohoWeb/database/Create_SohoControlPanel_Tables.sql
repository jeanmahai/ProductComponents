SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleFunctions]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Functions]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFunctions]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleUsers]') AND type in (N'U'))
BEGIN
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
END
