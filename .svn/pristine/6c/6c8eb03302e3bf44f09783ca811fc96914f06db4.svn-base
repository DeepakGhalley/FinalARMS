CREATE TABLE [dbo].[mstMinorHead]
(
	[minorHeadId] INT NOT NULL PRIMARY KEY IDENTITY,
    [majorHeadId] INT NOT NULL,
	[minorHeadName] VARCHAR(250) NOT NULL, 
    [minorHeadCode] VARCHAR(250) NOT NULL, 
    [minorHeadDescription] VARCHAR(250) NULL, 
    [minorHeadSymbol] VARCHAR(50) NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstMinorHead_ToTable] FOREIGN KEY ([majorHeadId]) REFERENCES [mstMajorHead]([majorHeadId])
)
