SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Configs](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[ConfigKey] [nvarchar](100) NOT NULL,
	[ConfigValue] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Configs] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SMS](
	[SysNo] [bigint] IDENTITY(1000001,1) NOT NULL,
	[UserSysNo] [int] NULL,
	[ReceiveName] [nvarchar](200) NULL,
	[ReceivePhoneNumber] [nvarchar](200) NOT NULL,
	[SMSBody] [nvarchar](1000) NOT NULL,
	[Status] [int] NOT NULL,
	[SendTime] [datetime] NULL,
	[InDate] [datetime] NOT NULL,
	[LastUpdateTime] [datetime] NULL,
	[Note] [nvarchar](1000) NULL,
 CONSTRAINT [PK_SMS] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Emails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Emails](
	[SysNo] [bigint] IDENTITY(1000001,1) NOT NULL,
	[UserSysNo] [int] NULL,
	[ReceiveName] [nvarchar](200) NULL,
	[ReceiveAddress] [nvarchar](2000) NOT NULL,
	[CCAddress] [nvarchar](2000) NULL,
	[EmailTitle] [nvarchar](600) NOT NULL,
	[EmailBody] [nvarchar](max) NOT NULL,
	[IsBodyHtml] [int] NOT NULL,
	[EmailPriority] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[SendTime] [datetime] NULL,
	[InDate] [datetime] NOT NULL,
	[LastUpdateTime] [datetime] NULL,
	[Note] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Emails] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
