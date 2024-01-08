CREATE TABLE [dbo].[mstStructureType]
(
	[structureTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [structureType] VARCHAR(150) NOT NULL,
    [structureTypeDescription] VARCHAR(300) NOT NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)
