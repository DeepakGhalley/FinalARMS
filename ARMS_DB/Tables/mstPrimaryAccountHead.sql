CREATE TABLE [dbo].[mstPrimaryAccountHead]
(
	[primaryAccountHeadId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [primaryAccountHeadName] VARCHAR(250) NOT NULL, 
    [primaryAccountHeadCode] VARCHAR(250) NULL, 
    [primaryAccountHeadDescription] VARCHAR(250) NOT NULL, 
    [primaryAccountHeadSymbol] VARCHAR(50) NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL
)

