CREATE TABLE [dbo].[mstBank]
(
	[bankId] INT NOT NULL PRIMARY KEY IDENTITY,
	[bankCode] [varchar](50) NULL,
	[bankName] [varchar](245) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)
