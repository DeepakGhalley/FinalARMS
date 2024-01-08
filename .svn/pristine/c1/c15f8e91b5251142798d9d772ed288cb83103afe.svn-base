CREATE TABLE [dbo].[mstGewog]
(
	[gewogId] INT NOT NULL PRIMARY KEY IDENTITY,
	[dzongkhagId] [int] NOT NULL,
	[gewogName] [varchar](245) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_mstGewog_ToTable] FOREIGN KEY ([dzongkhagId]) REFERENCES [mstDzongkhag]([dzongkhagId]),
)
