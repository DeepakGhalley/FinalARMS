﻿
CREATE TABLE [dbo].[enumTitle](
	[titleId] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NOT NULL,
 CONSTRAINT [PK_enumTitleId] PRIMARY KEY CLUSTERED 
(
	[titleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO