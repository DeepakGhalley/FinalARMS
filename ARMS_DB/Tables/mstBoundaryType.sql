CREATE TABLE [dbo].[mstBoundaryType]
(

[boundaryTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [boundaryType] VARCHAR(150) NOT NULL,
    [boundaryTypeDescription] VARCHAR(150)  NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL,
)
