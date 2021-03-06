USE [bookstore]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 8/27/2020 5:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [uniqueidentifier] NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Summary] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Status] [varchar](20) NOT NULL,
	[StatusTimestamp] [datetime2](7) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ServiceAudit]    Script Date: 15/9/2020 12:48:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceAudit](
	[Id] [uniqueidentifier] NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[Host] [varchar](100) NOT NULL,
	[ServiceName] [varchar](400) NOT NULL,
	[Type] [uniqueidentifier] NOT NULL,
	[Application] [uniqueidentifier] NULL,
	[RequestTextData] [nvarchar](max) NULL,
	[ResponseTextData] [nvarchar](max) NULL,
	[ErrorData] [nvarchar](max) NULL,
	[ExecutionTime] [time](7) NULL,
	[ClientSession] [varchar](100) NULL,
	[ClientUsername] [nvarchar](100) NULL,
	[ClientCustomer] [decimal](18, 0) NULL,
	[ClientIPAdress] [varchar](100) NULL,
	[ClientDetails] [varchar](1000) NULL,
	[ClientRequestPath] [varchar](200) NULL,
	[ClientLongitude] [decimal](18, 6) NULL,
	[ClientLatitude] [decimal](18, 6) NULL,
	[ClientExecutionTime] [time](7) NULL,
	[WebHost] [varchar](100) NULL,
 CONSTRAINT [PK_ServiceAudit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Timestamp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Title', @value=N'ServiceAudit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServiceAudit'
GO
