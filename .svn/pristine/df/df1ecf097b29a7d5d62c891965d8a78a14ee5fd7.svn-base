CREATE TABLE [dbo].[mstSecondaryAccountHead]
(
	[secondaryAccountHeadId] INT NOT NULL PRIMARY KEY IDENTITY,
    [primaryAccountHeadId] INT NOT NULL ,
	[secondaryAccountHeadName] VARCHAR(250) NOT NULL, 
    [secondaryAccountHeadCode] VARCHAR(250) NULL, 
    [secondaryAccountHeadDescription] VARCHAR(250) NOT NULL, 
    [secondaryAccountHeadSymbol] VARCHAR(50) NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstSecondaryAccountHead_ToTable] FOREIGN KEY ([primaryAccountHeadId]) REFERENCES [mstPrimaryAccountHead]([primaryAccountHeadId])
)

