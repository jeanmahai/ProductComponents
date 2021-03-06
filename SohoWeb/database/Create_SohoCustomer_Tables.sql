USE [SohoCustomer]
GO
/****** Object:  Table [dbo].[CustomerLoginLog]    Script Date: 06/22/2014 15:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerLoginLog](
	[SysNo] [int] IDENTITY(100001,1) NOT NULL,
	[CustomerSysNo] [int] NOT NULL,
	[LoginDate] [datetime] NOT NULL,
	[LoginIP] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_CustomerLoginLog] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerBase]    Script Date: 06/22/2014 15:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerBase](
	[SysNo] [int] IDENTITY(100001,1) NOT NULL,
	[CustomerID] [nvarchar](100) NOT NULL,
	[CustomerName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[AuthCode] [nvarchar](40) NOT NULL,
	[Status] [int] NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[RegIP] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_CustomerBase] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
