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
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
