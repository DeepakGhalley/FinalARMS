CREATE TABLE [dbo].[mstEsSignUpload]
(
	[esSignId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[userId] [int] NOT NULL,
	[signPath] [varchar](345) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_mstEsSignUpload_ToTable] FOREIGN KEY ([userId]) REFERENCES [mstUser]([userId]),
)
