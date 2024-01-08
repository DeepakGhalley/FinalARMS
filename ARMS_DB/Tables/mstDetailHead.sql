CREATE TABLE [dbo].[mstDetailHead]
(
	[detailHeadId] INT NOT NULL PRIMARY KEY IDENTITY,
	[minorHeadId] INT NOT NULL ,
	[detailHeadName] VARCHAR(250) NOT NULL, 
    [detailHeadCode] VARCHAR(250) NOT NULL, 
    [detailHeadDescription] VARCHAR(250) NULL, 
    [detailHeadSymbol] VARCHAR(50) NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstDetailHead_ToTable] FOREIGN KEY (minorHeadId) REFERENCES [mstMinorHead](minorHeadId), 
)
