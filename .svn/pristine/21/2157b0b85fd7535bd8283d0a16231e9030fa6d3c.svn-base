CREATE TABLE [dbo].[tblInaccessibleWaterMeterDetail]
(
[InaccessibleWaterMeterDetailId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [waterConnectionId] INT NOT NULL, 
	[readingDate] DATE NOT NULL, 
    [remarks] VARCHAR(250) NOT NULL, 
    [photoUrl] VARCHAR(250) NOT NULL,
    [createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_tblInaccessibleWaterMeterDetail_ToTable] FOREIGN KEY ([waterConnectionId]) REFERENCES [mstWaterConnection]([waterConnectionId]), 
    
)
