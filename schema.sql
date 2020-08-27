USE [bookstore]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 8/27/2020 12:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ShortDescription] [nvarchar](50) NULL,
	[Status] [nchar](10) NULL,
	[StatusTimestamp] [datetime2](7) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
