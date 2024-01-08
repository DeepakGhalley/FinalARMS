CREATE TABLE [dbo].[mstDCDSignUpload]
(
	[dcdSignId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[userId] [int] NOT NULL,
	[signPath] [varchar](345) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_mstDCDSignUpload_ToTable] FOREIGN KEY ([userId]) REFERENCES [mstUser]([userId]),
)