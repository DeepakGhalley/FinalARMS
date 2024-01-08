CREATE TABLE [dbo].[mstTertiaryAccountHead]
(
	[tertiaryAccountHeadId] INT NOT NULL PRIMARY KEY IDENTITY,
	[secondaryAccountHeadId] INT NOT NULL ,
	[tertiaryAccountHeadName] VARCHAR(250) NOT NULL, 
    [tertiaryAccountHeadCode] VARCHAR(250) NULL, 
    [tertiaryAccountHeadDescription] VARCHAR(250) NOT NULL, 
    [tertiaryAccountHeadSymbol] VARCHAR(50) NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    [assetType] VARCHAR(250) NULL, 
    CONSTRAINT [FK_mstTertiaryAccountHead_ToTable] FOREIGN KEY ([secondaryAccountHeadId]) REFERENCES [mstSecondaryAccountHead]([secondaryAccountHeadId]), 
)
