CREATE TABLE [dbo].[mstDzongkhag]
(
	[dzongkhagId] INT NOT NULL PRIMARY KEY IDENTITY,
	[dzongkhagName] [varchar](245) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,

)
