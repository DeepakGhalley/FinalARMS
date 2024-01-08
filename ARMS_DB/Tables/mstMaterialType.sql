CREATE TABLE [dbo].[mstMaterialType]
(
[materialTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [materialType] VARCHAR(150) NOT NULL,
    [materialTypeDescription] VARCHAR(150)  NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, )
