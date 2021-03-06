USE [SohoTopic]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 06/22/2014 15:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](40) NULL,
	[Phone] [nvarchar](30) NULL,
	[Email] [nvarchar](60) NULL,
	[Contents] [nvarchar](500) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[IP] [nvarchar](32) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicMaster]    Script Date: 06/22/2014 15:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TopicMaster](
	[SysNo] [int] IDENTITY(1000,1) NOT NULL,
	[CategorySysNo] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Summary] [nvarchar](400) NULL,
	[DefaultImage] [nvarchar](400) NULL,
	[Content] [nvarchar](max) NULL,
	[Keywords] [nvarchar](100) NULL,
	[Tag] [nvarchar](100) NULL,
	[IsRed] [int] NULL,
	[IsTop] [int] NULL,
	[MerchantSysNo] [int] NULL,
	[Status] [int] NOT NULL,
	[PageViews] [bigint] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[InUserSysNo] [int] NULL,
	[InUserName] [nvarchar](50) NULL,
	[InDate] [datetime] NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
	[PublishTime] [datetime] NULL,
 CONSTRAINT [PK__TopicMas__EB33D9B107F6335A] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TopicFile]    Script Date: 06/22/2014 15:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TopicFile](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[TopicMasterSysNo] [int] NULL,
	[FilePath] [nvarchar](400) NULL,
	[IsDefault] [int] NULL,
	[Priority] [int] NULL,
	[FileType] [int] NULL,
	[FileName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TopicFile] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TopicCategoryContentSetting]    Script Date: 06/22/2014 15:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TopicCategoryContentSetting](
	[SysNo] [int] IDENTITY(1000,1) NOT NULL,
	[CategorySysNo] [int] NOT NULL,
	[SettingCode] [char](20) NOT NULL,
	[SettingLabel] [nvarchar](50) NOT NULL,
	[Priority] [int] NOT NULL,
	[MaxLength] [int] NULL,
	[InputType] [int] NOT NULL,
	[IsMustInput] [int] NOT NULL,
	[TipsContent] [nvarchar](50) NULL,
	[RegexContent] [nvarchar](400) NULL,
	[Status] [int] NOT NULL,
	[InUserSysNo] [int] NULL,
	[InUserName] [nvarchar](50) NULL,
	[InDate] [datetime] NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
 CONSTRAINT [PK__TopicCat__EB33D9B17F60ED59] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TopicCategory]    Script Date: 06/22/2014 15:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TopicCategory](
	[SysNo] [int] IDENTITY(1000,1) NOT NULL,
	[CategoryCode] [char](20) NOT NULL,
	[ParentCategoryCode] [char](20) NULL,
	[NodeType] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[CategoryTitle] [nvarchar](100) NOT NULL,
	[Summary] [nvarchar](400) NULL,
	[SectionType] [int] NOT NULL,
	[ShowType] [int] NOT NULL,
	[IsLeaf] [int] NULL,
	[Image] [nvarchar](400) NULL,
	[OnShowMenu] [int] NULL,
	[TreePath] [nvarchar](100) NULL,
	[CustomFlag] [nchar](20) NULL,
	[URL] [nvarchar](100) NULL,
	[Status] [int] NOT NULL,
	[InUserSysNo] [int] NULL,
	[InUserName] [nvarchar](50) NULL,
	[InDate] [datetime] NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
	[LogMemo] [nvarchar](4000) NULL,
 CONSTRAINT [PK__TopicCat__EB33D9B10425A276] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Keywords]    Script Date: 06/22/2014 15:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Keywords](
	[SysNo] [int] IDENTITY(1,1) NOT NULL,
	[PageType] [int] NULL,
	[PageID] [int] NULL,
	[PositionID] [int] NULL,
	[KeywordsType] [int] NOT NULL,
	[KeywordsValue] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Status] [int] NOT NULL,
	[InUserSysNo] [int] NOT NULL,
	[InUserName] [nvarchar](50) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[EditUserSysNo] [int] NULL,
	[EditUserName] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
 CONSTRAINT [PK_Keywords] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[FN_GetNewestTopicCategoryCode]    Script Date: 06/22/2014 15:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FN_GetNewestTopicCategoryCode]
(
	@ParentCode varchar(20)
) 
RETURNS varchar(20)
AS
BEGIN
declare @ChildCodePatten  varchar(20)
declare @MaxChildCode  int
declare @Code  varchar(20)
set @ParentCode =LTRIM(RTRIM(ISNULL(@ParentCode,'')));
set @ChildCodePatten = @ParentCode +'____';
SELECT @MaxChildCode=MAX(ChildCode)
FROM
(
select [CategoryCode],CONVERT(int, SUBSTRING([CategoryCode],LEN(@ParentCode)+1,4)) ChildCode
FROM [SohoTopic].[dbo].[TopicCategory]
where [CategoryCode] like  @ChildCodePatten
) A;
set @MaxChildCode= ISNULL(@MaxChildCode,0);
select @Code = CONVERT(VARCHAR(4),@MaxChildCode+1);

if(@MaxChildCode<=9)
begin
set @Code = '000'+@Code;
end
else if(@MaxChildCode<=99)
begin
set @Code = '00'+@Code;
end
else if(@MaxChildCode<=999)
begin
set @Code = '0'+@Code;
end
return @ParentCode+@Code;
END
GO
/****** Object:  Default [DF__TopicCate__MaxLe__014935CB]    Script Date: 06/22/2014 15:56:20 ******/
ALTER TABLE [dbo].[TopicCategoryContentSetting] ADD  CONSTRAINT [DF__TopicCate__MaxLe__014935CB]  DEFAULT ((8000)) FOR [MaxLength]
GO
/****** Object:  Default [DF__TopicFile__FileN__300424B4]    Script Date: 06/22/2014 15:56:20 ******/
ALTER TABLE [dbo].[TopicFile] ADD  DEFAULT ('') FOR [FileName]
GO
