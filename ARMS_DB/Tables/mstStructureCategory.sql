CREATE TABLE [dbo].[mstStructureCategory]
(
	[structureCategoryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [structureCategory] VARCHAR(150) NOT NULL,
    [structureCategoryDescription] VARCHAR(300) NOT NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)
