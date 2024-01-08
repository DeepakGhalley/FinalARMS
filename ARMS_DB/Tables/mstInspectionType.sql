CREATE TABLE [dbo].[mstInspectionType]
(
	[inspectionTypeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[inspectionType] VARCHAR(250) NOT NULL, 
    [inspectionTypeDescription] VARCHAR(300) NULL, 
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)

